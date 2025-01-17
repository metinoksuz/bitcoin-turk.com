Public Class Degiskenler

    Public Shared ReadOnly Property IPListUrl As String
        Get
            Return "http://bitcoin-turk.com/iplist.txt"  ' IP listesini çekebileceğiniz URL
        End Get
    End Property

    Public Shared Property IpAddress As String

    Public Shared Property Port As Integer = 3410

    Public Shared Property Ftp_Sunucu As String = "ftpsunucusu"

    Public Shared Property Ftp_kullanici_adi As String = "Ftp_kullanici_adi"
    Public Shared Property Ftp_password As String = "Iv=Ftp_password"


End Class
