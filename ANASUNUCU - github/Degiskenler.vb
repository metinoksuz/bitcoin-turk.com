Public Class Degiskenler

    ' IP listesinin bulunduğu URL'yi belirler.
    ' Bu URL, WebSocket bağlantılarının geçerli IP listesine sahip olup olmadığını kontrol etmek için kullanılabilir.
    '*******************************
    Public Shared ReadOnly Property IPListUrl As String
        Get
            Return "http://bitcoin-turk.com/iplist.txt"  ' IP listesini çekebileceğiniz URL
        End Get
    End Property
    '*******************************

    ' Bu değer, ağ türüne göre Form1'de seçilen IP adresi ile güncellenir.
    Public Shared Property IpAddress As String

    ' WebSocket sunucusunun port numarası.
    Public Shared Property Port As Integer = 3410

    ' FTP kullanıcı adı ve şifre
    Public Shared Property Ftp_Sunucu As String = "ftpsunucusu"

    Public Shared Property Ftp_kullanici_adi As String = "Ftp_kullanici_adi"
    Public Shared Property Ftp_password As String = "Iv=Ftp_password"


End Class
