Imports System.Net
Imports System.Net.WebSockets
Imports System.Text
Imports System.Threading

Public Class WebSocketServer
    Public Shared sunucularListesi As New List(Of ServerInfo)()
    Public Shared dogrulayanlarListesi As New List(Of WebSocket)()

    Public Shared listener As HttpListener
    Public Shared serverUri As String = $"http://{Degiskenler.IpAddress}:{Degiskenler.Port}/"

    Private Shared cts As CancellationTokenSource


    Public Shared Sub StartServer()
        listener = New HttpListener()
        listener.Prefixes.Add(serverUri)
        listener.Start()

        Form1.AddMessageToListBox($"WebSocket Sunucu Başlatıldı. Bağlantı bekleniyor... {serverUri}")

        cts = New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token

        While Not token.IsCancellationRequested
            Try
                If listener.IsListening Then
                    Dim context As HttpListenerContext = listener.GetContext() '
                    If context.Request.IsWebSocketRequest Then
                        HandleWebSocketRequest(context)
                    End If
                End If
            Catch ex As ObjectDisposedException
                Form1.AddMessageToListBox("Listener durduruldu.")
            Catch ex As Exception
                Form1.AddMessageToListBox($"Beklenmeyen hata: {ex.Message}")
            End Try
        End While
    End Sub

    Private Shared Async Sub HandleWebSocketRequest(context As HttpListenerContext)
        Dim remoteIp As String = context.Request.RemoteEndPoint.Address.ToString()

        Dim websocketContext As WebSocketContext = Await context.AcceptWebSocketAsync(Nothing)
        Dim socket As WebSocket = websocketContext.WebSocket

        Form1.AddMessageToListBox("Yeni bağlantı: " & remoteIp)

        Dim kullaniciAdi As String = Form1.Text_new_sunucu_user.Text
        Dim sifre As String = Form1.Text_new_sunucu_password.Text
        Dim cuzdanNo As String = Form1.Text_new_sunucu_cuzdan.Text
        Dim IPadres As String = Form1.Text_new_sunucu_ip.Text

        If sunucularListesi.Any(Function(s) s.Yeni_SunucuIpAdres = IPadres) Then
            Form1.AddMessageToListBox("Bu IP adresi zaten listede.")
            Return
        End If

        Dim newServer As New ServerInfo(kullaniciAdi, sifre, IPadres, cuzdanNo)

        sunucularListesi.Add(newServer)

        newServer.Yeni_SunucuWebSocket = socket

        Dim buffer As Byte() = New Byte(1024) {}
        Dim result As WebSocketReceiveResult
        While socket.State = WebSocketState.Open
            result = Await socket.ReceiveAsync(New ArraySegment(Of Byte)(buffer), CancellationToken.None)
            If result.MessageType = WebSocketMessageType.Text Then
                Dim message As String = Encoding.UTF8.GetString(buffer, 0, result.Count)
                Form1.AddMessageToListBox("Mesaj alındı: " & message)

                If message.StartsWith("DOĞRULA") Then
                    dogrulayanlarListesi.Add(socket)
                    Await SendMessage(socket, "Doğrulama başarılı!")
                Else
                    Await SendMessage(socket, "Mesaj alındı.")
                End If
            End If
        End While

        sunucularListesi.RemoveAll(Function(item) item.Yeni_SunucuWebSocket.Equals(socket))
        dogrulayanlarListesi.Remove(socket)

        Form1.AddMessageToListBox("Bağlantı kapatıldı: " & remoteIp)
    End Sub

    Private Shared Async Function SendMessage(socket As WebSocket, message As String) As Task
        Dim buffer As Byte() = Encoding.UTF8.GetBytes(message)
        Await socket.SendAsync(New ArraySegment(Of Byte)(buffer), WebSocketMessageType.Text, True, CancellationToken.None)
    End Function

    Public Shared Sub StopServer()
        Form1.AddMessageToListBox("WebSocket Sunucusu Durduruluyor...")

        If Not cts.Token.IsCancellationRequested Then
            cts?.Cancel()
        End If

        If listener IsNot Nothing Then
            Try
                listener.Stop()
                Form1.AddMessageToListBox("Listener durduruldu.")
            Catch ex As Exception
                Form1.AddMessageToListBox($"Listener durdurulurken hata oluştu: {ex.Message}")
            End Try
        End If


        For Each item As ServerInfo In sunucularListesi
            Dim socket As WebSocket = item.Yeni_SunucuWebSocket
            If socket.State = WebSocketState.Open Then
                socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Sunucu kapatılıyor", CancellationToken.None).Wait()
                Form1.AddMessageToListBox("Bağlantı kapatıldı: " & item.Yeni_SunucuIpAdres)
            End If
        Next

        sunucularListesi.Clear()
        dogrulayanlarListesi.Clear()

        Form1.AddMessageToListBox("WebSocket Sunucusu Durduruldu.")
    End Sub

End Class
