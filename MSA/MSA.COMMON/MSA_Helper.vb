Imports System.Net.Mail
Imports System.Configuration
Imports System.Text

Public Class MSA_Helper
    Public Shared Function RandomString(length As Integer) As String
        Const chars As String = "0123456789" ' "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim random = New Random()
        Return New String(Enumerable.Repeat(chars, length).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
    End Function

    Public Shared Function SendMail(toAddress As String, subject As String, body As String) As String

        Dim sendMailFrom = ConfigurationManager.AppSettings("MailFrom")
        Dim PasssendMailFrom = ConfigurationManager.AppSettings("PassMailFrom")

        Dim result As String = "Message Sent Successfully..!!"
        Dim senderID As String = sendMailFrom
        ' use sender’s email id here..
        Dim senderMAT_KHAU As String = PasssendMailFrom
        ' sender MAT_KHAU here…
        Try
            ' smtp server address here…
            Dim smtp As New SmtpClient() With { _
                 .Host = "smtp.gmail.com", _
                 .Port = 578, _
                 .EnableSsl = True, _
                 .DeliveryMethod = SmtpDeliveryMethod.Network, _
                 .Timeout = 30000, _
                 .UseDefaultCredentials = False _
            }
            smtp.Credentials = New System.Net.NetworkCredential()

          

            Dim message As New MailMessage(senderID & "LIFE-BETTER", toAddress, subject, body)
            message.IsBodyHtml = True
            message.BodyEncoding = System.Text.UTF8Encoding.UTF8

            smtp.Send(message)
        Catch ex As Exception
            result = "Error sending email.!!!"
        End Try

        Return result
    End Function

End Class
