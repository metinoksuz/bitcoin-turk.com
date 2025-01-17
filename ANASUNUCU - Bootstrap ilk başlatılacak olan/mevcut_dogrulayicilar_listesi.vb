Public Class Mevcut_dogrulayicilar_listesi
    Public Shared DogrulayicilarListesi As New List(Of DogrulayiciInfo)()

    Public Shared Sub Dogrulayicilar_Listesi()

        For Each dogrulayici As DogrulayiciInfo In DogrulayicilarListesi
            Form1.list_websocketdurum.Items.Add($"Kullanıcı Adı: {dogrulayici.Yeni_DogrulayiciKullaniciAdi}, Şifre: {dogrulayici.Yeni_DogrulayiciSifre}, IP Adresi: {dogrulayici.Yeni_DogrulayiciIpAdres}, Cüzdan No: {dogrulayici.Yeni_DogrulayiciCuzdanNo}")
        Next
    End Sub
End Class
