Public Class Mevcut_sunucular_listesi
    Public Shared sunucularListesi As New List(Of ServerInfo)()

    Public Shared Sub SunuculariListele()

        For Each sunucu As ServerInfo In sunucularListesi
            Form1.list_websocketdurum.Items.Add($"Kullanıcı Adı: {sunucu.Yeni_SunucuKullaniciAdi}, Şifre: {sunucu.Yeni_SunucuSifre}, IP Adresi: {sunucu.Yeni_SunucuIpAdres}, Cüzdan No: {sunucu.Yeni_SunucuCuzdanNo}")
        Next
    End Sub
End Class
