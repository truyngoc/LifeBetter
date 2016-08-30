Imports MSA.COMMON
Imports MSA.DAO
Public Class MSA
    Inherits System.Web.UI.MasterPage

    'Dim _numberMSG As Integer
    Dim _newMSG As String
    Public Shared Property NumberMSG As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'If Not Singleton(Of MSACurrentSession).Inst.isLoginUser Then

            '    Response.Redirect("/LoginAccount.aspx")
            'Else
            '    lblNotification.Text = "(" & Singleton(Of MSA_REPORTDAO).Inst.GetReportNew(Singleton(Of MSACurrentSession).Inst.SessionMember.Username).ToString & ") Messages"
            'End If

        End If
    End Sub

End Class