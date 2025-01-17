Imports FluentFTP
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class WebTxtEkle

    Private ReadOnly remoteFilePath As String = "/iplist.txt" ' FTP sunucusundaki dosya yolu
    Private ReadOnly localTempFilePath As String = Path.Combine(Path.GetTempPath(), "iplist.txt") ' Geçici yerel dosya yolu

    ' FluentFTP Client'i başlat
    Private ReadOnly client As New FtpClient()


    Public Function Ekle(eklenecekIcerik As String, form As Form) As Boolean
        Try
            ' FTP bağlantısı sağla
            client.Host = Degiskenler.Ftp_Sunucu ' Sunucu adresi
            client.Credentials = New System.Net.NetworkCredential(Degiskenler.Ftp_kullanici_adi, Degiskenler.Ftp_password) ' Kullanıcı adı ve şifre

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
            End If

            ' Yeni içeriği mevcut içeriğin sonuna ekle
            Dim guncellenmisIcerik As String = mevcutIcerik
            If Not String.IsNullOrWhiteSpace(mevcutIcerik) Then
                guncellenmisIcerik &= Environment.NewLine
            End If
            guncellenmisIcerik &= eklenecekIcerik

            ' Güncellenmiş içeriği geçici dosyaya yaz
            File.WriteAllText(localTempFilePath, guncellenmisIcerik, Encoding.UTF8)

            ' Güncellenmiş dosyayı FTP'ye yükle
            client.UploadFile(localTempFilePath, remoteFilePath, FtpRemoteExists.Overwrite)
            form.Invoke(New Action(Sub() Form1.list_websocketdurum.Items.Add("IP Adresi başarıyla eklendi.")))

            ' Bağlantıyı kapat
            client.Disconnect()

            Return True
        Catch ex As Exception
            form.Invoke(New Action(Sub() Form1.list_websocketdurum.Items.Add($"Hata: {ex.Message}")))
            Return False
        End Try
    End Function

End Class
