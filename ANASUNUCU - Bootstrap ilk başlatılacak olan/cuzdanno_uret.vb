Imports System
Imports System.Text
Public Class Cuzdanno_uret
    Public Function cuzdannouretim() As String
        Dim prefix As String = "TRx0"
        Dim randomPart As String = GenerateRandomString(37)
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
