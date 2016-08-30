
Imports MSA.INFO
Imports MSA.DAO
Imports MSA.COMMON
Public Class LoginAcount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        If (Page.IsValid) Then
            Dim _mInfo As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.Find(txtMA_KH.Text, txtMAT_KHAU.Text)
            If (_mInfo IsNot Nothing) Then
                If _mInfo.TRANG_THAI = 2 Then
                    lblMessage.Text = "Mã khách hàng đang bị khóa."
                    lblMessage.Visible = True

                Else
                    Singleton(Of MSACurrentSession).Inst.SessionMember = _mInfo
                    lblMessage.Visible = False
                    Response.Redirect("AccountTreeView.aspx")
                    ''Response.Redirect("~/default.aspx")
                End If
            Else
                lblMessage.Text = "*Mã khách hàng hoặc mật khẩu không đúng"
                lblMessage.Visible = True
            End If
        End If
    End Sub
End Class