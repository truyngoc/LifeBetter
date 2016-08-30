Public Class SignOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MSACurrentSession.SignOut()
        Response.Redirect("../Home")
    End Sub

End Class