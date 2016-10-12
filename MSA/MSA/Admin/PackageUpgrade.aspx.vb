Public Class PackageUpgrade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUpgrade_Click(sender As Object, e As EventArgs) Handles btnUpgrade.Click
        If (Page.IsValid) Then
            If ddlGOI_DAU_TU_HIEN_TAI.SelectedValue < ddlGOI_DAU_TU_NANG_CAP.SelectedValue Then
                lblMsgPackageUpgrade.Text = "Gói nâng cấp phải lớn hơn gói hiện tại"
                lblMsgPackageUpgrade.Visible = True
            Else
                ' upgrade
            End If
        End If
    End Sub
End Class