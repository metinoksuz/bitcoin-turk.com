Imports FluentFTP
Imports System.IO
Imports System.Text

Public Class Web_txt_Sil
    Private ReadOnly server As String = Degiskenler.Ftp_Sunucu
    Private ReadOnly username As String = Degiskenler.Ftp_kullanici_adi
    Private ReadOnly password As String = Degiskenler.Ftp_password
    Private ReadOnly remoteFilePath As String = "/iplist.txt" ' FTP sunucusundaki dosya yolu
    Private ReadOnly localTempFilePath As String = Path.Combine(Path.GetTempPath(), "iplist.txt") ' Geçici yerel dosya yolu

    Private ReadOnly client As New FtpClient()

    Public Function Sil(silinecekIp As String, form As Form) As Boolean
        Try
            ' FTP bağlantısı sağla
            client.Host = server
            client.Credentials = New System.Net.NetworkCredential(username, password)

            ' FTP sunucusuna bağlan
            client.Connect()

            ' Mevcut içeriği indir
            Dim mevcutIcerik As String = String.Empty
            If client.FileExists(remoteFilePath) Then
                Using stream = client.OpenRead(remoteFilePath)
                    Using reader As New StreamReader(stream)
                        mevcutIcerik = reader.ReadToEnd()
                    End Using
                End Using
            Else
                Throw New FileNotFoundException("Dosya bulunamadı.")
            End If

            ' Mevcut içeriği satır bazında işle
            Dim satirlar As List(Of String) = mevcutIcerik.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList()
            satirlar.RemoveAll(Function(s) s.Contains(silinecekIp)) ' IP adresine sahip satırı sil

            ' Güncellenmiş içeriği oluştur
            Dim guncellenmisIcerik As String = String.Join(Environment.NewLine, satirlar)

            ' Güncellenmiş içeriği geçici dosyaya yaz
            File.WriteAllText(localTempFilePath, guncellenmisIcerik, Encoding.UTF8)

            ' Güncellenmiş dosyayı FTP'ye yükle
            client.UploadFile(localTempFilePath, remoteFilePath, FtpRemoteExists.Overwrite)

            ' Sunucular listesinde IP adresine sahip olan sunucuya da ulaşarak sil
            Mevcut_sunucular_listesi.sunucularListesi.RemoveAll(Function(s) s.Yeni_SunucuIpAdres = silinecekIp)

            ' Bağlantıyı kapat
            client.Disconnect()

            Return True
        Catch ex As Exception
            form.Invoke(New Action(Sub() Form1.list_websocketdurum.Items.Add($"Hata: {ex.Message}")))
            Return False
        End Try
    End Function
End Class
