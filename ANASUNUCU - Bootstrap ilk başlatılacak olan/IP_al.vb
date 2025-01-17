Imports System.Net
Imports System.Net.Http
Imports System.Net.Sockets
Public Class IP_al
    Public Shared Function GetLocalIPAddress() As String
        Try
            Dim host As String = Dns.GetHostName()
            Dim ipAddresses = Dns.GetHostAddresses(host)

            For Each ip In ipAddresses
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
        Catch ex As Exception
            Return $"Hata: {ex.Message}"
        End Try

        Return "Yerel IP bulunamadı."
    End Function

    Public Shared Async Function GetPublicIPAddressAsync() As Task(Of String)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(10) ' Zaman aşımı süresi
                Dim response = Await client.GetStringAsync("https://api.ipify.org")
                Return response.Trim()
            End Using
        Catch ex As Exception
            Return $"Hata: {ex.Message}"
        End Try
    End Function
End Class
