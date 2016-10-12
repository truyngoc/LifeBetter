Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO

Public Class EditAccount
    Inherits System.Web.UI.Page

    Public ReadOnly Property MA_KH As String
        Get
            Return Request("MA_KH")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                LoadAccountInfo(MA_KH)
            Else
                Response.Redirect("~/Account/LoginAccount.aspx")
            End If
        End If
    End Sub

    Public Sub LoadAccountInfo(ByVal ma_kh As String)
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(ma_kh)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã khách hàng"
            lblError.Visible = True            
        Else
            txtMa_KH.Text = info.MA_KH
            txtTEN.Text = info.TEN
            txtCMND.Text = info.CMND
            txtDIEN_THOAI.Text = info.DIEN_THOAI
            txtEMAIL.Text = info.DIA_CHI
            txtNGAN_HANG.Text = info.NGAN_HANG
            txtSO_TAI_KHOAN.Text = info.SO_TAI_KHOAN


            If Not String.IsNullOrEmpty(info.MA_BAO_TRO) Then
                Dim infoBaoTro As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_BAO_TRO(info.MA_BAO_TRO)
                txtTEN_BAO_TRO.Text = infoBaoTro.TEN
                txtBaoTro.Text = infoBaoTro.MA_KH
                txtMA_BAO_TRO.Text = info.MA_BAO_TRO
            End If

            'If Not String.IsNullOrEmpty(info.MA_CAY_TT) Then
            '    Dim infoCay_TT As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_CAY(info.MA_CAY_TT)
            '    txtUPLINE.Text = infoCay_TT.MA_KH
            '    txtTEN_UPLINE.Text = infoCay_TT.TEN
            '    txtMA_UPLINE.Text = infoCay_TT.MA_CAY

            '    'CHECK VỊ TRÍ
            '    Dim i As Integer = info.NHANH_CAY_TT
            '    If  i = 1 Then
            '        lstVITRI.SelectedIndex = 0
            '        lstVITRI.Visible = True
            '        lstVITRI.Enabled = False
            '    ElseIf i = 2 Then
            '        lstVITRI.SelectedIndex = 1
            '        lstVITRI.Visible = True
            '        lstVITRI.Enabled = False
            '    End If
            'End If

            'If info.TRANG_THAI = 2 Then
            '    chkCtyHoTro.Checked = True
            'ElseIf (info.TRANG_THAI = 1 Or info.TRANG_THAI = 0) Then
            '    chkCtyHoTro.Checked = False
            'End If

            lblError.Visible = False
        End If
    End Sub


    Protected Sub btnCheckBaoTro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckBaoTro.Click
        Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtBaoTro.Text.Trim)
        If info Is Nothing Then
            lblError.Text = "Không tìm thấy mã người bảo trợ"
            lblError.Visible = True
        Else
            txtTEN_BAO_TRO.Text = info.TEN
            txtMA_BAO_TRO.Text = info.MA_CAY
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>0: Không có, 1: Kim cương, 2: chủ tịch</returns>
    ''' <remarks></remarks>
    Private Function checkDanhHieu(ByVal MA_CAY As String) As List(Of String)
        Dim lstKimCuong As New List(Of String)
        Dim objMember As MSA_MemberInfo
        Dim oHoaHong As HOA_HONG
        While MA_CAY.Length > 2
            Try
                MA_CAY = MA_CAY.Substring(0, MA_CAY.Length - 2)
                oHoaHong = Singleton(Of MSA_DOANH_SO_DAO).Inst.Tinh_Hoa_Hong(MA_CAY, _
                                                     Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH, _
                                                     DateTime.Today.Month, DateTime.Today.Year)
                Dim DOANH_SO_NHANH_YEU As Long = IIf(oHoaHong.DOANH_SO_TICH_LUY_TRAI >= oHoaHong.DOANH_SO_TICH_LUY_PHAI, oHoaHong.DOANH_SO_TICH_LUY_PHAI, oHoaHong.DOANH_SO_TICH_LUY_TRAI)
                objMember = Singleton(Of MSA_MemberDAO).Inst.FindByMA_CAY(MA_CAY)
                If DateDiff("d", objMember.NGAY_THAM_GIA, DateTime.Now) <= 60 Then
                    If DOANH_SO_NHANH_YEU >= 180000000 Then
                        lstKimCuong.Add(MA_CAY)
                    End If
                ElseIf DateDiff("d", objMember.NGAY_THAM_GIA, DateTime.Now) <= 150 Then
                    If DOANH_SO_NHANH_YEU >= 300000000 Then
                        lstKimCuong.Add(MA_CAY)
                    End If
                Else
                    If DOANH_SO_NHANH_YEU >= 3000000000 Then
                        lstKimCuong.Add(MA_CAY)
                    End If
                End If

            Catch ex As Exception

            End Try
        End While


        Return lstKimCuong
    End Function
    Protected Sub btnKICHHOAT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKichHoat.Click
        'If lstVITRI.Visible = False Then
        '    lblError.Text = "Người chỉ định đã đủ hai nhánh, hãy chọn người chỉ định khác"
        '    lblError.Visible = True
        '    Exit Sub
        'End If
        If txtMA_BAO_TRO.Text.Equals("") Then
            lblError.Text = "Người bảo trợ không tồn tại."
            lblError.Visible = True
            Exit Sub
        End If
        Dim info As New MSA_MemberInfo
        info.MA_KH = txtMa_KH.Text
        'info.MA_CAY_TT = txtMA_UPLINE.Text
        'If lstVITRI.SelectedIndex = 0 Then
        '    info.MA_CAY = txtMA_UPLINE.Text + "01"
        '    info.NHANH_CAY_TT = 1
        'Else
        '    info.MA_CAY = txtMA_UPLINE.Text + "02"
        '    info.NHANH_CAY_TT = 2
        'End If
        info.MA_BAO_TRO = txtMA_BAO_TRO.Text

        'If chkCtyHoTro.Checked = True Then
        '    info.TRANG_THAI = 2
        'Else
        '    info.TRANG_THAI = 1
        'End If

        info.TEN = txtTEN.Text.Trim
        info.CMND = txtCMND.Text.Trim
        info.DIEN_THOAI = txtDIEN_THOAI.Text.Trim
        info.DIA_CHI = txtEMAIL.Text.Trim
        info.SO_TAI_KHOAN = txtSO_TAI_KHOAN.Text.Trim
        info.NGAN_HANG = txtNGAN_HANG.Text.Trim


        Singleton(Of MSA_MemberDAO).Inst.Admin_Update(info)

        Response.Redirect("AccountReport.aspx")
    End Sub

    'Protected Sub btnUPLINE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchUpline.Click
    '    Dim info As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(txtUPLINE.Text.Trim)
    '    If info Is Nothing Then
    '        lblError.Text = "Không tìm thấy mã người chỉ định"
    '        lblError.Visible = True
    '    Else
    '        txtTEN_UPLINE.Text = info.TEN
    '        txtMA_UPLINE.Text = info.MA_CAY
    '        'CHECK VỊ TRÍ
    '        Dim i As Integer = Singleton(Of MSA_MemberDAO).Inst.CHECK_VI_TRI_TRONG(txtMA_UPLINE.Text.Trim)
    '        If i = 0 Then
    '            lblError.Text = "Người chỉ định đã bảo trợ đủ hai nhánh"
    '            lblError.Visible = True

    '            lstVITRI.Visible = False
    '            Exit Sub
    '        ElseIf i = 1 Then
    '            lstVITRI.SelectedIndex = 0
    '            lstVITRI.Visible = True
    '            lstVITRI.Enabled = False
    '        ElseIf i = 2 Then
    '            lstVITRI.SelectedIndex = 1
    '            lstVITRI.Visible = True
    '            lstVITRI.Enabled = False
    '        Else
    '            lstVITRI.Visible = True
    '            lstVITRI.Enabled = True
    '        End If
    '        lblError.Visible = False
    '    End If
    'End Sub

End Class