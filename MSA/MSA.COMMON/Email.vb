Imports System.Net.Mail

Public Class Email
    Public Shared Sub SendMail(ByVal Subject As String, ByVal Body As String, ByVal mailTo As String)

        Dim message As New MailMessage
        message.From = New MailAddress("admin@bit-invest-asia.com", "admin@bit-invest-asia.com")
        message.To.Add(mailTo)
        message.Subject = Subject
        message.IsBodyHtml = True

        message.Body += Environment.NewLine
        message.Body += Body
        message.Body += Environment.NewLine

        Dim client As New SmtpClient
        client.Credentials = New System.Net.NetworkCredential("admin@bit-invest-asia.com", "endless@123", 25)
        client.Port = 578
        client.Host = "smtp.gmail.com"
        client.EnableSsl = True
        Try
            client.Send(message)
        Catch ex As Exception

        End Try

    End Sub
End Class
