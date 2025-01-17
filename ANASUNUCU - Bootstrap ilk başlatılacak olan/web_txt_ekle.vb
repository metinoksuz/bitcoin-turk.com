Imports FluentFTP
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class WebTxtEkle

    Private ReadOnly remoteFilePath As String = "/iplist.txt"
    Private ReadOnly localTempFilePath As String = Path.Combine(Path.GetTempPath(), "iplist.txt") ' Geçici yerel dosya yolu

    Private ReadOnly client As New FtpClient()


    Public Function Ekle(eklenecekIcerik As String, form As Form) As Boolean
        Try
            client.Host = Degiskenler.Ftp_Sunucu ' Sunucu adresi
            client.Credentials = New System.Net.NetworkCredential(Degiskenler.Ftp_kullanici_adi, Degiskenler.Ftp_password) ' Kullanıcı adı ve şifre

            client.Connect()

            Dim mevcutIcerik As String = String.Empty
            If client.FileExists(remoteFilePath) Then
                Using stream = client.OpenRead(remoteFilePath)
                    Using reader As New StreamReader(stream)
                        mevcutIcerik = reader.ReadToEnd()
                    End Using
                End Using
            End If

            Dim guncellenmisIcerik As String = mevcutIcerik
            If Not String.IsNullOrWhiteSpace(mevcutIcerik) Then
                guncellenmisIcerik &= Environment.NewLine
            End If
            guncellenmisIcerik &= eklenecekIcerik
            File.WriteAllText(localTempFilePath, guncellenmisIcerik, Encoding.UTF8)

            client.UploadFile(localTempFilePath, remoteFilePath, FtpRemoteExists.Overwrite)
            form.Invoke(New Action(Sub() Form1.list_websocketdurum.Items.Add("IP Adresi başarıyla eklendi.")))

            client.Disconnect()

            Return True
        Catch ex As Exception
            form.Invoke(New Action(Sub() Form1.list_websocketdurum.Items.Add($"Hata: {ex.Message}")))
            Return False
        End Try
    End Function

End Class
