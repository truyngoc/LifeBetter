Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO

Public Class ActiveUsers
    Inherits System.Web.UI.Page

    Private Sub VisbleForm()
        pnDetail.Visible = False
    End Sub

    Private Sub EnableForm()
        pnDetail.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                VisbleForm()
            Else
                Response.Redirect("LoginAccount.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtMa_KH.Text.Trim)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã khách hàng"
            lblError.Visible = True
            VisbleForm()
        Else
            txtTEN.Text = info.TEN
            txtCMND.Text = info.CMND
            txtDIEN_THOAI.Text = info.DIEN_THOAI

            lblError.Visible = False
            EnableForm()
        End If

    End Sub

    Protected Sub btnKICHHOAT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKichHoat.Click
        Dim info As New MSA_MemberInfo
        info.MA_KH = txtMa_KH.Text
        info.MA_CAY_TT = txtMA_UPLINE.Text
        If lstVITRI.SelectedIndex = 0 Then
            info.MA_CAY = txtMA_UPLINE.Text + "01"
            info.NHANH_CAY_TT = 0
        Else
            info.MA_CAY = txtMA_UPLINE.Text + "02"
            info.NHANH_CAY_TT = 1
        End If

        info.MA_GOI_DAU_TU = lstGOI_DAU_TU.SelectedIndex + 1
        Singleton(Of MSA_MemberDAO).Inst.Update_KICH_HOAT(info)
    End Sub

    Protected Sub btnUPLINE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchUpline.Click
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtUPLINE.Text.Trim)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã người chỉ định"
            lblError.Visible = True
        Else
            txtTEN_UPLINE.Text = info.TEN
            txtMA_UPLINE.Text = info.MA_CAY
            lblError.Visible = False
        End If
    End Sub
End Class