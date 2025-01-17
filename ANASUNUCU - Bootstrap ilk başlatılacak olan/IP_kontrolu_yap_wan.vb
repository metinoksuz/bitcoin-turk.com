Public Class IP_kontrolu_yap_wan
    Public Shared Function IsIPInList(ipList As ListBox, publicIP As String) As Boolean
        If String.IsNullOrWhiteSpace(publicIP) Then
            Throw New ArgumentException("IP adresi boş olamaz.")
        End If

        For Each item As String In ipList.Items
            If item.Trim().Equals(publicIP.Trim(), StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next

        Return False
    End Function
End Class
