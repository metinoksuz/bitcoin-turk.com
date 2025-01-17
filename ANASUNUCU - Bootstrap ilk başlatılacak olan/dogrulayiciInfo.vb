Imports System.Net.WebSockets

Public Class DogrulayiciInfo


    Public Property Yeni_DogrulayiciKullaniciAdi As String
    Public Property Yeni_DogrulayiciSifre As String
    Public Property Yeni_DogrulayiciIpAdres As String
    Public Property Yeni_DogrulayiciCuzdanNo As String
    Public Property Yeni_DogrulayiciWebSocket As WebSocket

    Public Sub New(Yeni_DogrulayiciKullaniciAdi As String, Yeni_DogrulayiciSifre As String, Yeni_DogrulayiciIpAdres As String, Yeni_DogrulayiciCuzdanNo As String)



        Me.Yeni_DogrulayiciKullaniciAdi = Yeni_DogrulayiciKullaniciAdi
        Me.Yeni_DogrulayiciSifre = Yeni_DogrulayiciSifre
        Me.Yeni_DogrulayiciIpAdres = Yeni_DogrulayiciIpAdres
        Me.Yeni_DogrulayiciCuzdanNo = Yeni_DogrulayiciCuzdanNo
    End Sub

End Class
