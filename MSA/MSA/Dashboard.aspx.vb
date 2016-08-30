Imports MSA.COMMON

Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Not Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                Response.Redirect("Account/LoginAccount.aspx")
            End If
        End If
    End Sub

    Protected Sub CreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Create_User.Click
        Response.Redirect("Account/Register.aspx")
    End Sub
End Class