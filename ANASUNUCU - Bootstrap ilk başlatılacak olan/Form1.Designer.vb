<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnLogin = New Button()
        list_websocketdurum = New ListBox()
        Site_IP_List = New ListBox()
        TextBox_local_ip = New TextBox()
        TextBox_public_ip = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label6 = New Label()
        websocketdurdur = New Button()
        Group_MainMenu = New GroupBox()
        GroupBox2 = New GroupBox()
        Button6 = New Button()
        Button7 = New Button()
        Button1 = New Button()
        Text_new_dogrulayici_cuzdan = New TextBox()
        Label13 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Text_new_dogrulayici_ip = New TextBox()
        Text_new_dogrulayici_password = New TextBox()
        Text_new_dogrulayici_user = New TextBox()
        Button2 = New Button()
        GroupBox1 = New GroupBox()
        Button5 = New Button()
        Button4 = New Button()
        Button_sunucu_list = New Button()
        Label14 = New Label()
        Text_new_sunucu_cuzdan = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Text_new_sunucu_ip = New TextBox()
        Text_new_sunucu_password = New TextBox()
        Text_new_sunucu_user = New TextBox()
        Btn_Yeni_Sunucnu_Ekle = New Button()
        GroupBox3 = New GroupBox()
        Button_secili_sunucu_sil = New Button()
        Button3 = New Button()
        Site_IP_List_test_icin = New ListBox()
        Group_MainMenu.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(12, 236)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(220, 44)
        btnLogin.TabIndex = 2
        btnLogin.Text = "Giriş"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' list_websocketdurum
        ' 
        list_websocketdurum.FormattingEnabled = True
        list_websocketdurum.HorizontalScrollbar = True
        list_websocketdurum.ItemHeight = 15
        list_websocketdurum.Location = New Point(255, 37)
        list_websocketdurum.Name = "list_websocketdurum"
        list_websocketdurum.Size = New Size(914, 439)
        list_websocketdurum.TabIndex = 3
        ' 
        ' Site_IP_List
        ' 
        Site_IP_List.FormattingEnabled = True
        Site_IP_List.ItemHeight = 15
        Site_IP_List.Location = New Point(12, 91)
        Site_IP_List.Name = "Site_IP_List"
        Site_IP_List.Size = New Size(214, 139)
        Site_IP_List.TabIndex = 4
        ' 
        ' TextBox_local_ip
        ' 
        TextBox_local_ip.Location = New Point(12, 37)
        TextBox_local_ip.Name = "TextBox_local_ip"
        TextBox_local_ip.Size = New Size(100, 23)
        TextBox_local_ip.TabIndex = 7
        TextBox_local_ip.Text = "Local IP"
        ' 
        ' TextBox_public_ip
        ' 
        TextBox_public_ip.Location = New Point(126, 37)
        TextBox_public_ip.Name = "TextBox_public_ip"
        TextBox_public_ip.Size = New Size(100, 23)
        TextBox_public_ip.TabIndex = 8
        TextBox_public_ip.Text = "Public IP"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(26, 15)
        Label1.TabIndex = 9
        Label1.Text = "Lan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(126, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(31, 15)
        Label2.TabIndex = 10
        Label2.Text = "Wan"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(150, 15)
        Label3.TabIndex = 11
        Label3.Text = "Sitede BootStrap Sunucular"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(324, 19)
        Label6.Name = "Label6"
        Label6.Size = New Size(106, 15)
        Label6.TabIndex = 17
        Label6.Text = "WebSocket Durum"
        ' 
        ' websocketdurdur
        ' 
        websocketdurdur.Location = New Point(12, 286)
        websocketdurdur.Name = "websocketdurdur"
        websocketdurdur.Size = New Size(220, 23)
        websocketdurdur.TabIndex = 18
        websocketdurdur.Text = "Websocket Durdur"
        websocketdurdur.UseVisualStyleBackColor = True
        ' 
        ' Group_MainMenu
        ' 
        Group_MainMenu.Controls.Add(GroupBox2)
        Group_MainMenu.Controls.Add(GroupBox1)
        Group_MainMenu.Location = New Point(255, 480)
        Group_MainMenu.Name = "Group_MainMenu"
        Group_MainMenu.Size = New Size(930, 238)
        Group_MainMenu.TabIndex = 19
        Group_MainMenu.TabStop = False
        Group_MainMenu.Text = "Ana Menu"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = SystemColors.GradientInactiveCaption
        GroupBox2.Controls.Add(Button6)
        GroupBox2.Controls.Add(Button7)
        GroupBox2.Controls.Add(Button1)
        GroupBox2.Controls.Add(Text_new_dogrulayici_cuzdan)
        GroupBox2.Controls.Add(Label13)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Controls.Add(Text_new_dogrulayici_ip)
        GroupBox2.Controls.Add(Text_new_dogrulayici_password)
        GroupBox2.Controls.Add(Text_new_dogrulayici_user)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Location = New Point(437, 22)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(477, 209)
        GroupBox2.TabIndex = 26
        GroupBox2.TabStop = False
        GroupBox2.Text = "Doğrulayıcı Ekle"
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(428, 62)
        Button6.Name = "Button6"
        Button6.Size = New Size(45, 23)
        Button6.TabIndex = 31
        Button6.Text = "Üret"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(428, 121)
        Button7.Name = "Button7"
        Button7.Size = New Size(45, 23)
        Button7.TabIndex = 30
        Button7.Text = "Üret"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(108, 174)
        Button1.Name = "Button1"
        Button1.Size = New Size(132, 23)
        Button1.TabIndex = 28
        Button1.Text = "Doğrulayıcıları Listele"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Text_new_dogrulayici_cuzdan
        ' 
        Text_new_dogrulayici_cuzdan.Location = New Point(108, 121)
        Text_new_dogrulayici_cuzdan.Name = "Text_new_dogrulayici_cuzdan"
        Text_new_dogrulayici_cuzdan.Size = New Size(314, 23)
        Text_new_dogrulayici_cuzdan.TabIndex = 27
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(36, 130)
        Label13.Name = "Label13"
        Label13.Size = New Size(66, 15)
        Label13.TabIndex = 26
        Label13.Text = "Cüzdan No"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(52, 95)
        Label10.Name = "Label10"
        Label10.Size = New Size(50, 15)
        Label10.TabIndex = 24
        Label10.Text = "IP Adres"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(72, 66)
        Label11.Name = "Label11"
        Label11.Size = New Size(30, 15)
        Label11.TabIndex = 23
        Label11.Text = "Şifre"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(29, 37)
        Label12.Name = "Label12"
        Label12.Size = New Size(73, 15)
        Label12.TabIndex = 20
        Label12.Text = "Kullanıcı Adı"
        ' 
        ' Text_new_dogrulayici_ip
        ' 
        Text_new_dogrulayici_ip.Location = New Point(108, 92)
        Text_new_dogrulayici_ip.Name = "Text_new_dogrulayici_ip"
        Text_new_dogrulayici_ip.Size = New Size(314, 23)
        Text_new_dogrulayici_ip.TabIndex = 22
        ' 
        ' Text_new_dogrulayici_password
        ' 
        Text_new_dogrulayici_password.Location = New Point(108, 63)
        Text_new_dogrulayici_password.Name = "Text_new_dogrulayici_password"
        Text_new_dogrulayici_password.Size = New Size(314, 23)
        Text_new_dogrulayici_password.TabIndex = 21
        ' 
        ' Text_new_dogrulayici_user
        ' 
        Text_new_dogrulayici_user.Location = New Point(108, 34)
        Text_new_dogrulayici_user.Name = "Text_new_dogrulayici_user"
        Text_new_dogrulayici_user.Size = New Size(314, 23)
        Text_new_dogrulayici_user.TabIndex = 20
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(108, 150)
        Button2.Name = "Button2"
        Button2.Size = New Size(132, 23)
        Button2.TabIndex = 19
        Button2.Text = "Ekle"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.GradientInactiveCaption
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(Button4)
        GroupBox1.Controls.Add(Button_sunucu_list)
        GroupBox1.Controls.Add(Label14)
        GroupBox1.Controls.Add(Text_new_sunucu_cuzdan)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Text_new_sunucu_ip)
        GroupBox1.Controls.Add(Text_new_sunucu_password)
        GroupBox1.Controls.Add(Text_new_sunucu_user)
        GroupBox1.Controls.Add(Btn_Yeni_Sunucnu_Ekle)
        GroupBox1.Location = New Point(6, 22)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(425, 209)
        GroupBox1.TabIndex = 25
        GroupBox1.TabStop = False
        GroupBox1.Text = "Yeni Sunucu Ekle"
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(374, 62)
        Button5.Name = "Button5"
        Button5.Size = New Size(45, 23)
        Button5.TabIndex = 29
        Button5.Text = "Üret"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(374, 121)
        Button4.Name = "Button4"
        Button4.Size = New Size(45, 23)
        Button4.TabIndex = 28
        Button4.Text = "Üret"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button_sunucu_list
        ' 
        Button_sunucu_list.Location = New Point(230, 159)
        Button_sunucu_list.Name = "Button_sunucu_list"
        Button_sunucu_list.Size = New Size(138, 39)
        Button_sunucu_list.TabIndex = 27
        Button_sunucu_list.Text = "Sunucuları Listele"
        Button_sunucu_list.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(11, 124)
        Label14.Name = "Label14"
        Label14.Size = New Size(66, 15)
        Label14.TabIndex = 26
        Label14.Text = "Cüzdan No"
        ' 
        ' Text_new_sunucu_cuzdan
        ' 
        Text_new_sunucu_cuzdan.Location = New Point(89, 121)
        Text_new_sunucu_cuzdan.Name = "Text_new_sunucu_cuzdan"
        Text_new_sunucu_cuzdan.Size = New Size(279, 23)
        Text_new_sunucu_cuzdan.TabIndex = 25
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(27, 95)
        Label9.Name = "Label9"
        Label9.Size = New Size(50, 15)
        Label9.TabIndex = 24
        Label9.Text = "IP Adres"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(47, 66)
        Label8.Name = "Label8"
        Label8.Size = New Size(30, 15)
        Label8.TabIndex = 23
        Label8.Text = "Şifre"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(4, 37)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 15)
        Label7.TabIndex = 20
        Label7.Text = "Kullanıcı Adı"
        ' 
        ' Text_new_sunucu_ip
        ' 
        Text_new_sunucu_ip.Location = New Point(89, 92)
        Text_new_sunucu_ip.Name = "Text_new_sunucu_ip"
        Text_new_sunucu_ip.Size = New Size(279, 23)
        Text_new_sunucu_ip.TabIndex = 22
        ' 
        ' Text_new_sunucu_password
        ' 
        Text_new_sunucu_password.Location = New Point(89, 63)
        Text_new_sunucu_password.Name = "Text_new_sunucu_password"
        Text_new_sunucu_password.Size = New Size(279, 23)
        Text_new_sunucu_password.TabIndex = 21
        ' 
        ' Text_new_sunucu_user
        ' 
        Text_new_sunucu_user.Location = New Point(89, 34)
        Text_new_sunucu_user.Name = "Text_new_sunucu_user"
        Text_new_sunucu_user.Size = New Size(279, 23)
        Text_new_sunucu_user.TabIndex = 20
        ' 
        ' Btn_Yeni_Sunucnu_Ekle
        ' 
        Btn_Yeni_Sunucnu_Ekle.Location = New Point(89, 159)
        Btn_Yeni_Sunucnu_Ekle.Name = "Btn_Yeni_Sunucnu_Ekle"
        Btn_Yeni_Sunucnu_Ekle.Size = New Size(138, 39)
        Btn_Yeni_Sunucnu_Ekle.TabIndex = 19
        Btn_Yeni_Sunucnu_Ekle.Text = "Ekle"
        Btn_Yeni_Sunucnu_Ekle.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = SystemColors.GradientInactiveCaption
        GroupBox3.Controls.Add(Button_secili_sunucu_sil)
        GroupBox3.Controls.Add(Button3)
        GroupBox3.Controls.Add(Site_IP_List_test_icin)
        GroupBox3.Location = New Point(12, 322)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(220, 402)
        GroupBox3.TabIndex = 27
        GroupBox3.TabStop = False
        GroupBox3.Text = "Sunucuları Test Et"
        ' 
        ' Button_secili_sunucu_sil
        ' 
        Button_secili_sunucu_sil.Location = New Point(6, 337)
        Button_secili_sunucu_sil.Name = "Button_secili_sunucu_sil"
        Button_secili_sunucu_sil.Size = New Size(208, 23)
        Button_secili_sunucu_sil.TabIndex = 29
        Button_secili_sunucu_sil.Text = "Seçili Sunucuyu Sil"
        Button_secili_sunucu_sil.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(6, 308)
        Button3.Name = "Button3"
        Button3.Size = New Size(208, 23)
        Button3.TabIndex = 28
        Button3.Text = "Test Et"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Site_IP_List_test_icin
        ' 
        Site_IP_List_test_icin.FormattingEnabled = True
        Site_IP_List_test_icin.ItemHeight = 15
        Site_IP_List_test_icin.Location = New Point(6, 28)
        Site_IP_List_test_icin.Name = "Site_IP_List_test_icin"
        Site_IP_List_test_icin.Size = New Size(208, 274)
        Site_IP_List_test_icin.TabIndex = 20
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1197, 730)
        Controls.Add(GroupBox3)
        Controls.Add(Group_MainMenu)
        Controls.Add(Label6)
        Controls.Add(Label3)
        Controls.Add(websocketdurdur)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox_public_ip)
        Controls.Add(TextBox_local_ip)
        Controls.Add(Site_IP_List)
        Controls.Add(list_websocketdurum)
        Controls.Add(btnLogin)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        Group_MainMenu.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnLogin As Button
    Friend WithEvents list_websocketdurum As ListBox
    Friend WithEvents Site_IP_List As ListBox
    Friend WithEvents TextBox_local_ip As TextBox
    Friend WithEvents TextBox_public_ip As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents websocketdurdur As Button
    Friend WithEvents Group_MainMenu As GroupBox
    Friend WithEvents Btn_Yeni_Sunucnu_Ekle As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Text_new_sunucu_ip As TextBox
    Friend WithEvents Text_new_sunucu_password As TextBox
    Friend WithEvents Text_new_sunucu_user As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Text_new_dogrulayici_ip As TextBox
    Friend WithEvents Text_new_dogrulayici_password As TextBox
    Friend WithEvents Text_new_dogrulayici_user As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button_secili_sunucu_sil As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Site_IP_List_test_icin As ListBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Text_new_sunucu_cuzdan As TextBox
    Friend WithEvents Button_sunucu_list As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Text_new_dogrulayici_cuzdan As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button

End Class
