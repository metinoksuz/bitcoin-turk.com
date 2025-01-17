Imports System.Net
Imports System.Net.WebSockets
Imports System.Text
Imports System.Threading

Public Class WebSocketServer
    Public Shared sunucularListesi As New List(Of ServerInfo)()
    Public Shared dogrulayanlarListesi As New List(Of WebSocket)()

    ' WebSocket sunucu IP ve port ayarı Degiskenler sınıfından alınacak
    Public Shared listener As HttpListener
    Public Shared serverUri As String = $"http://{Degiskenler.IpAddress}:{Degiskenler.Port}/"

    ' Durdurma işlemi için bir token
    Private Shared cts As CancellationTokenSource


    ' Sunucu başlatma
    Public Shared Sub StartServer()
        listener = New HttpListener()
        listener.Prefixes.Add(serverUri)
        listener.Start()

        ' Form üzerinden bilgi ekleyin
        Form1.AddMessageToListBox($"WebSocket Sunucu Başlatıldı. Bağlantı bekleniyor... {serverUri}")

        ' Durdurma için token'ı kaydet
        cts = New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token

        ' Bağlantı bekleyen bir döngü
        While Not token.IsCancellationRequested
            Try
                ' GetContext() çağrısının beklenmesi sırasında hata olursa, döngüyü sonlandır
                If listener.IsListening Then
                    Dim context As HttpListenerContext = listener.GetContext() ' İstemci bağlantısını al
                    If context.Request.IsWebSocketRequest Then
                        HandleWebSocketRequest(context)
                    End If
                End If
            Catch ex As ObjectDisposedException
                ' Listener durdurulmuşsa (başka bir işlem tarafından)
                Form1.AddMessageToListBox("Listener durduruldu.")
            Catch ex As Exception
                ' Diğer hataları burada yakalayabilirsiniz
                Form1.AddMessageToListBox($"Beklenmeyen hata: {ex.Message}")
            End Try
        End While
    End Sub

    ' WebSocket bağlantı işleme
    ' WebSocket bağlantı işleme
    Private Shared Async Sub HandleWebSocketRequest(context As HttpListenerContext)
        ' Uzak IP adresini almak için HttpListenerContext kullanıyoruz
        Dim remoteIp As String = context.Request.RemoteEndPoint.Address.ToString()

        ' Bağlantıyı kabul et
        Dim websocketContext As WebSocketContext = Await context.AcceptWebSocketAsync(Nothing)
        Dim socket As WebSocket = websocketContext.WebSocket

        Form1.AddMessageToListBox("Yeni bağlantı: " & remoteIp)

        ' Kullanıcıdan gelen bilgileri al
        Dim kullaniciAdi As String = Form1.Text_new_sunucu_user.Text
        Dim sifre As String = Form1.Text_new_sunucu_password.Text
        Dim cuzdanNo As String = Form1.Text_new_sunucu_cuzdan.Text
        Dim IPadres As String = Form1.Text_new_sunucu_ip.Text

        ' Sunucu eklemeden önce kontrol
        If sunucularListesi.Any(Function(s) s.Yeni_SunucuIpAdres = IPadres) Then
            Form1.AddMessageToListBox("Bu IP adresi zaten listede.")
            Return
        End If

        ' Yeni bir ServerInfo nesnesi oluştur
        Dim newServer As New ServerInfo(kullaniciAdi, sifre, IPadres, cuzdanNo)

        ' Listeye ekle
        sunucularListesi.Add(newServer)

        ' WebSocket'i ServerInfo nesnesine atama işlemi
        newServer.Yeni_SunucuWebSocket = socket

        ' Gelen mesajları dinlemeye başla
        Dim buffer As Byte() = New Byte(1024) {}
        Dim result As WebSocketReceiveResult
        While socket.State = WebSocketState.Open
            result = Await socket.ReceiveAsync(New ArraySegment(Of Byte)(buffer), CancellationToken.None)
            If result.MessageType = WebSocketMessageType.Text Then
                ' Gelen mesajı string'e çevir
                Dim message As String = Encoding.UTF8.GetString(buffer, 0, result.Count)
                Form1.AddMessageToListBox("Mesaj alındı: " & message)

                ' Doğrulama işlemi yapılırsa, "Doğrulayıcılar Listesi"ne ekle
                If message.StartsWith("DOĞRULA") Then
                    dogrulayanlarListesi.Add(socket)
                    Await SendMessage(socket, "Doğrulama başarılı!")
                Else
                    ' Normal mesaj işlemleri burada yapılabilir
                    Await SendMessage(socket, "Mesaj alındı.")
                End If
            End If
        End While

        ' Bağlantı kapandığında, listelerden istemciyi çıkar
        sunucularListesi.RemoveAll(Function(item) item.Yeni_SunucuWebSocket.Equals(socket))
        dogrulayanlarListesi.Remove(socket)

        ' Bağlantı kapatıldı mesajı
        Form1.AddMessageToListBox("Bağlantı kapatıldı: " & remoteIp)
    End Sub


    ' Mesaj gönderme fonksiyonu
    Private Shared Async Function SendMessage(socket As WebSocket, message As String) As Task
        Dim buffer As Byte() = Encoding.UTF8.GetBytes(message)
        Await socket.SendAsync(New ArraySegment(Of Byte)(buffer), WebSocketMessageType.Text, True, CancellationToken.None)
    End Function

    ' Sunucuyu durdurma fonksiyonu
    Public Shared Sub StopServer()
        ' Durdurma işlemi için CancellationToken kullanıyoruz
        Form1.AddMessageToListBox("WebSocket Sunucusu Durduruluyor...")

        ' Durdurulma işlemi için token'ı tetikle, sadece bir kez yapılması gerektiğini kontrol ediyoruz
        If Not cts.Token.IsCancellationRequested Then
            cts?.Cancel()
        End If

        ' Sunucuyu durdur
        ' Listener durdurma sırasında hataların düzgün işlenmesi
        If listener IsNot Nothing Then
            Try
                listener.Stop()
                Form1.AddMessageToListBox("Listener durduruldu.")
            Catch ex As Exception
                Form1.AddMessageToListBox($"Listener durdurulurken hata oluştu: {ex.Message}")
            End Try
        End If


        ' Tüm açık WebSocket bağlantılarını kapat
        For Each item As ServerInfo In sunucularListesi
            ' Bağlantı kapatma işlemi burada yapılacak
            Dim socket As WebSocket = item.Yeni_SunucuWebSocket
            If socket.State = WebSocketState.Open Then
                socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Sunucu kapatılıyor", CancellationToken.None).Wait()
                Form1.AddMessageToListBox("Bağlantı kapatıldı: " & item.Yeni_SunucuIpAdres)
            End If
        Next

        ' Listeyi temizle
        sunucularListesi.Clear()
        dogrulayanlarListesi.Clear()

        Form1.AddMessageToListBox("WebSocket Sunucusu Durduruldu.")
    End Sub

End Class
