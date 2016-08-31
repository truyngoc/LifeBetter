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

            If String.IsNullOrEmpty(info.MA_BAO_TRO) Then
                txtBaoTro.Enabled = True
                btnCheckBaoTro.Enabled = True
                lblError.Text = "Không tìm thấy mã người bảo trợ"
                lblError.Visible = True
            Else
                Dim infoBaoTro As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_BAO_TRO(info.MA_BAO_TRO)
                txtTEN_BAO_TRO.Text = infoBaoTro.TEN
                txtBaoTro.Text = infoBaoTro.MA_KH
                txtMA_BAO_TRO.Text = info.MA_BAO_TRO
                txtBaoTro.Enabled = False
                btnCheckBaoTro.Enabled = False
            End If

            lblError.Visible = False
            EnableForm()
        End If

    End Sub


    Protected Sub btnCheckBaoTro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckBaoTro.Click
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtBaoTro.Text.Trim)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã người chỉ định"
            lblError.Visible = True
        Else
            txtTEN_BAO_TRO.Text = info.TEN
            txtMA_BAO_TRO.Text = info.MA_CAY
        End If
    End Sub

    Protected Sub btnKICHHOAT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKichHoat.Click
        If lstVITRI.Visible = False Then
            lblError.Text = "Người chỉ định đã đủ hai nhánh, hãy chọn người chỉ định khác"
            lblError.Visible = True
            Exit Sub
        End If
        If txtMA_BAO_TRO.Text.Equals("") Then
            lblError.Text = "Người bảo trợ không tồn tại."
            lblError.Visible = True
            Exit Sub
        End If
        Dim info As New MSA_MemberInfo
        info.MA_KH = txtMa_KH.Text
        info.MA_CAY_TT = txtMA_UPLINE.Text
        If lstVITRI.SelectedIndex = 0 Then
            info.MA_CAY = txtMA_UPLINE.Text + "01"
            info.NHANH_CAY_TT = 1
        Else
            info.MA_CAY = txtMA_UPLINE.Text + "02"
            info.NHANH_CAY_TT = 2
        End If
        info.MA_BAO_TRO = txtMA_BAO_TRO.Text
        info.MA_GOI_DAU_TU = lstGOI_DAU_TU.SelectedIndex + 1
        If chkCtyHoTro.Checked = True Then
            info.TRANG_THAI = 2
        Else
            info.TRANG_THAI = 1
        End If
        Singleton(Of MSA_MemberDAO).Inst.Update_KICH_HOAT(info)
        Response.Redirect("AccountTreeView")
    End Sub

    Protected Sub btnUPLINE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchUpline.Click
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtUPLINE.Text.Trim)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã người chỉ định"
            lblError.Visible = True
        Else
            txtTEN_UPLINE.Text = info.TEN
            txtMA_UPLINE.Text = info.MA_CAY
            'CHECK VỊ TRÍ
            Dim i As Integer = Singleton(Of MSA_MemberDAO).Inst.CHECK_VI_TRI_TRONG(txtMA_UPLINE.Text.Trim)
            If i = 0 Then
                lblError.Text = "Người chỉ định đã bảo trợ đủ hai nhánh"
                lblError.Visible = True
                Exit Sub
            ElseIf i = 1 Then
                lstVITRI.SelectedIndex = 0
                lstVITRI.Visible = True
                lstVITRI.Enabled = False
            ElseIf i = 2 Then
                lstVITRI.SelectedIndex = 1
                lstVITRI.Visible = True
                lstVITRI.Enabled = False
            Else
                lstVITRI.Visible = True
                lstVITRI.Enabled = True
            End If
            lblError.Visible = False
        End If
    End Sub
End Class