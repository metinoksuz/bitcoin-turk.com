﻿Imports FluentFTP
Imports System.Net
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private websocketServer As WebSocketServer



    ' Form açıldığında IP adreslerini alacak
    Private Async Sub Netten_ipadreslerini_al()
        'İp adreslerini al
        '************************************
        Dim localIp As String = IP_al.GetLocalIPAddress() ' Yerel IP adresini al
        Dim publicIp As String = Await IP_al.GetPublicIPAddressAsync() ' Halka açık IP adresini al
        TextBox_local_ip.Text = localIp
        TextBox_public_ip.Text = publicIp
        '************************************

        Try
            ' URL'yi Degiskenler sınıfından al
            Dim url As String = Degiskenler.IPListUrl

            ' Sınıfı kullanarak IP adreslerini al
            Dim ipList As List(Of String) = Await IP_Adresler_Siteden_Gelen.FetchIPListAsync(url)

            ' IP adreslerini ListBox'a ekle
            Site_IP_List.Items.Clear()
            Site_IP_List_test_icin.Items.Clear()
            For Each ip In ipList
                Site_IP_List.Items.Add(ip)
                Site_IP_List_test_icin.Items.Add(ip)
            Next
        Catch ex As Exception
            MessageBox.Show($"Hata oluştu: {ex.Message}")
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Netten_ipadreslerini_al()

    End Sub

    ' Login butonuna tıklanınca IP adresi doğrulaması yapılır
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            ' TextBox içeriğini al
            Dim ipadresilan As String = TextBox_local_ip.Text.Trim()

            ' Ağ türüne göre kontrol yap
            Dim aktif_ipadres As String = ipadresilan

            ' ****
            ' Seçilen IP adresini Degiskenler sınıfına atıyoruz
            Degiskenler.IpAddress = aktif_ipadres

            ' Eğer WebSocket sunucusu ilk başlatan kişiyseniz, sunucuyu başlatıyoruz
            websocketServer = New WebSocketServer()
            Task.Run(Sub() WebSocketServer.StartServer()) ' WebSocket sunucusunu async olarak başlatıyoruz
            list_websocketdurum.Items.Add("IP adresi bulundu")
            list_websocketdurum.Items.Add("WebSocket Sunucu Başlatıldı")
            list_websocketdurum.Items.Add("IP=" & Degiskenler.IpAddress & "  Port=" & Degiskenler.Port)
            Group_MainMenu.Enabled = True


        Catch ex As ArgumentException
            MessageBox.Show($"Hata: {ex.Message}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' WebSocket sunucusunu durdurmak için buton
    Private Sub Websocketdurdur_Click(sender As Object, e As EventArgs) Handles websocketdurdur.Click
        If websocketServer IsNot Nothing Then
            ' WebSocket sunucusunu durdur
            WebSocketServer.StopServer()
            list_websocketdurum.Items.Add("WebSocket Sunucusu Durduruldu.")
        Else
            list_websocketdurum.Items.Add("Sunucu zaten başlatılmamış")
        End If
    End Sub

    ' ListBox'a mesaj eklemek için kullanılan metod
    Public Sub AddMessageToListBox(message As String)
        If list_websocketdurum.InvokeRequired Then
            ' UI thread'inde çalıştırmak için Invoke kullanılır
            list_websocketdurum.Invoke(New Action(Of String)(AddressOf AddMessageToListBox), message)
        Else
            ' ListBox'a mesaj ekle
            list_websocketdurum.Items.Add(message)
            ' En son eklenen öğeye scroll yap
            list_websocketdurum.SelectedIndex = list_websocketdurum.Items.Count - 1
        End If
    End Sub


    Private Sub Btn_Yeni_Sunucnu_Ekle_Click(sender As Object, e As EventArgs) Handles Btn_Yeni_Sunucnu_Ekle.Click

        Call Websockete_yeni_sunucu_ekle()
        Call Nete_yeni_ip_adresi_ekle()

    End Sub


    Private Sub Nete_yeni_ip_adresi_ekle()
        ' WebTxtEkle sınıfından bir nesne oluşturun
        Dim webTxtEkle As New WebTxtEkle()

        ' Kullanıcıdan eklenecek metni alın (örneğin TextBox'tan)
        Dim eklenecekMetin As String = Text_new_sunucu_ip.Text.Trim()

        ' Ekle fonksiyonunu çağırın
        Dim basarili As Boolean = webTxtEkle.Ekle(eklenecekMetin, Me)

        ' Sonucu kullanıcıya bildirin
        If basarili Then
            list_websocketdurum.Items.Add("IP Adresi başarıyla eklendi.")
            Call Netten_ipadreslerini_al()
        Else
            list_websocketdurum.Items.Add("IP Adresi eklenirken hata oluştu.")
        End If
    End Sub


    Private Sub Websockete_yeni_sunucu_ekle()
        ' Kullanıcıdan bilgileri al ve listeye ekle
        Dim yeni_sunucu_kullaniciAdi As String = Text_new_sunucu_user.Text.Trim()
        Dim yeni_sunucu_sifre As String = Text_new_sunucu_password.Text.Trim()
        Dim yeni_sunucu_ipAdres As String = Text_new_sunucu_ip.Text.Trim()
        Dim yeni_sunucu_cuzdanNo As String = Text_new_sunucu_cuzdan.Text.Trim()

        ' Bilgiler geçerliyse ekle
        If Not String.IsNullOrEmpty(yeni_sunucu_kullaniciAdi) AndAlso Not String.IsNullOrEmpty(yeni_sunucu_sifre) AndAlso Not String.IsNullOrEmpty(yeni_sunucu_ipAdres) AndAlso Not String.IsNullOrEmpty(yeni_sunucu_cuzdanNo) Then
            ' Yeni ServerInfo nesnesi oluşturuluyor
            Dim newsunucu As New ServerInfo(yeni_sunucu_kullaniciAdi, yeni_sunucu_sifre, yeni_sunucu_ipAdres, yeni_sunucu_cuzdanNo)

            ' Sunucu bilgilerini Mevcut_sunucular_listesi'ne ekle
            Mevcut_sunucular_listesi.sunucularListesi.Add(newsunucu)

            ' ListBox'a mesaj ekle
            list_websocketdurum.Items.Add("********************************************")
            list_websocketdurum.Items.Add("Yeni sunucu Kullanıcı Adı: " & yeni_sunucu_kullaniciAdi)
            list_websocketdurum.Items.Add("Yeni sunucu Şifre: " & yeni_sunucu_sifre)
            list_websocketdurum.Items.Add("Yeni sunucu IP Adresi: " & yeni_sunucu_ipAdres)
            list_websocketdurum.Items.Add("Yeni sunucu Cüzdan No: " & yeni_sunucu_cuzdanNo)
            list_websocketdurum.Items.Add("********************************************")
        Else
            MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Websockete_yeni_dogrulayici_ekle()
        ' Kullanıcıdan bilgileri al ve listeye ekle
        Dim yeni_dogrulayici_kullaniciAdi As String = Text_new_dogrulayici_user.Text.Trim()
        Dim yeni_dogrulayici_sifre As String = Text_new_dogrulayici_password.Text.Trim()
        Dim yeni_dogrulayici_ipAdres As String = Text_new_dogrulayici_ip.Text.Trim()
        Dim yeni_dogrulayici_cuzdanNo As String = Text_new_dogrulayici_cuzdan.Text.Trim()

        ' Bilgiler geçerliyse ekle
        If Not String.IsNullOrEmpty(yeni_dogrulayici_kullaniciAdi) AndAlso Not String.IsNullOrEmpty(yeni_dogrulayici_sifre) AndAlso Not String.IsNullOrEmpty(yeni_dogrulayici_ipAdres) AndAlso Not String.IsNullOrEmpty(yeni_dogrulayici_cuzdanNo) Then
            ' Yeni DogrulayiciInfo nesnesi oluşturuluyor
            Dim newdogrulayici As New dogrulayiciInfo(yeni_dogrulayici_kullaniciAdi, yeni_dogrulayici_sifre, yeni_dogrulayici_ipAdres, yeni_dogrulayici_cuzdanNo)

            ' Sunucu bilgilerini Mevcut_dogrulayici_listesi'ne ekle
            Mevcut_dogrulayicilar_listesi.dogrulayicilarListesi.Add(newdogrulayici)

            ' ListBox'a mesaj ekle
            list_websocketdurum.Items.Add("********************************************")
            list_websocketdurum.Items.Add("Yeni dogrulayici Kullanıcı Adı: " & yeni_dogrulayici_kullaniciAdi)
            list_websocketdurum.Items.Add("Yeni dogrulayici Şifre: " & yeni_dogrulayici_sifre)
            list_websocketdurum.Items.Add("Yeni dogrulayici IP Adresi: " & yeni_dogrulayici_ipAdres)
            list_websocketdurum.Items.Add("Yeni dogrulayici Cüzdan No: " & yeni_dogrulayici_cuzdanNo)
            list_websocketdurum.Items.Add("********************************************")
        Else
            MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub Button_sunucu_list_Click(sender As Object, e As EventArgs) Handles Button_sunucu_list.Click
        Mevcut_sunucular_listesi.SunuculariListele()
    End Sub

    Private Sub Button_secili_sunucu_sil_Click(sender As Object, e As EventArgs) Handles Button_secili_sunucu_sil.Click
        ' Seçili öğe varsa işlemi başlat
        If Site_IP_List_test_icin.SelectedItem IsNot Nothing Then
            ' Seçili öğeyi al
            Dim silinecekIp As String = Site_IP_List_test_icin.SelectedItem.ToString()

            ' WebTxtSil sınıfından bir nesne oluştur
            Dim webTxtSil As New Web_txt_Sil()

            ' Silme işlemini gerçekleştir ve sonucu al
            Dim basarili As Boolean = webTxtSil.Sil(silinecekIp, Me)

            ' Sonuç bildirimi
            If basarili Then
                ' ListBox'tan seçili öğeyi sil
                Site_IP_List_test_icin.Items.Remove(silinecekIp)
                list_websocketdurum.Items.Add("Seçili IP Adresi başarıyla silindi ve dosya güncellendi.")
                Call Netten_ipadreslerini_al()

            Else
                list_websocketdurum.Items.Add("IP Adresi silinirken veya dosya güncellenirken hata oluştu.")
            End If
        Else
            ' Seçili bir öğe yoksa kullanıcıyı uyar
            MessageBox.Show("Lütfen silinecek bir IP adresi seçin.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mevcut_dogrulayicilar_listesi.dogrulayicilar_Listesi()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Websockete_yeni_dogrulayici_ekle()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim cuzdanuret As New cuzdanno_uret()
        Dim cuzdanAdres As String = cuzdanuret.cuzdannouretim()
        Text_new_sunucu_cuzdan.Text = cuzdanAdres
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sifre_uret As New Sifreuret()
        Dim sifre As String = sifre_uret.sifreuretim()
        Text_new_sunucu_password.Text = sifre
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim sifre_uret As New Sifreuret()
        Dim sifre As String = sifre_uret.sifreuretim()
        Text_new_dogrulayici_password.Text = sifre
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim cuzdanuret As New Cuzdanno_uret()
        Dim cuzdanAdres As String = cuzdanuret.cuzdannouretim()
        Text_new_dogrulayici_cuzdan.Text = cuzdanAdres
    End Sub
End Class



