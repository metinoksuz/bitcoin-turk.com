Imports System.Text

Public Class Sifreuret

    Public Function sifreuretim() As String
        Dim prefix As String = "TR-"
        Dim randomPart As String = GenerateRandomString(15)
        Return prefix & randomPart
    End Function

    Private Function GenerateRandomString(length As Integer) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim random As New Random()
        Dim result As New StringBuilder(length)

        For i As Integer = 0 To length - 1
            result.Append(chars(random.Next(chars.Length)))
        Next

        Return result.ToString()
    End Function
End Class
