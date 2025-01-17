Public Class Mevcut_dogrulayicilar_listesi
    ' Sunucular listesini tutan statik liste
    Public Shared DogrulayicilarListesi As New List(Of DogrulayiciInfo)()

    ' Sunucuları ListBox'a yazdırma metodu
    Public Shared Sub Dogrulayicilar_Listesi()


        ' Sunucular listesini ListBox'a ekle
        For Each dogrulayici As DogrulayiciInfo In dogrulayicilarListesi
            Form1.list_websocketdurum.Items.Add($"Kullanıcı Adı: {dogrulayici.Yeni_DogrulayiciKullaniciAdi}, Şifre: {dogrulayici.Yeni_DogrulayiciSifre}, IP Adresi: {dogrulayici.Yeni_DogrulayiciIpAdres}, Cüzdan No: {dogrulayici.Yeni_DogrulayiciCuzdanNo}")
        Next
    End Sub
End Class
