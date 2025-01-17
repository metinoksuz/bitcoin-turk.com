Imports System.Net.Http

Public Class IP_Adresler_Siteden_Gelen

    Public Shared Async Function FetchIPListAsync(url As String) As Task(Of List(Of String))
        Dim ipList As New List(Of String)()

        Try
            Using client As New HttpClient()
                Dim response As String = Await client.GetStringAsync(url)

                Dim lines As String() = response.Split(New String() {Environment.NewLine, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)

                For Each line In lines
                    If Not String.IsNullOrWhiteSpace(line) Then
                        ipList.Add(line.Trim())
                    End If
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("IP listesini alırken hata oluştu.", ex)
        End Try

        Return ipList
    End Function
End Class

