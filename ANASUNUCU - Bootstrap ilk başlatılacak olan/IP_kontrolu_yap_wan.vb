Public Class IP_kontrolu_yap_wan
    ' IP adresini kontrol eden metod
    Public Shared Function IsIPInList(ipList As ListBox, publicIP As String) As Boolean
        ' IP boşsa direkt false döner
        If String.IsNullOrWhiteSpace(publicIP) Then
            Throw New ArgumentException("IP adresi boş olamaz.")
        End If

        ' ListBox öğelerini kontrol et
        For Each item As String In ipList.Items
            If item.Trim().Equals(publicIP.Trim(), StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next

        Return False
    End Function
End Class
