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
        ElseIf info.NV = 1 Then
            lblError.Text = "Tài khoản nhân viên không được kích hoạt"
            lblError.Visible = True
            VisbleForm()
        ElseIf info.TRANG_THAI = 1 Or info.TRANG_THAI = 2 Then
            lblError.Text = "Tài khoản đã được kích hoạt"
            lblError.Visible = True
            VisbleForm()
        Else
            txtTEN.Text = info.TEN
            txtCMND.Text = info.CMND
            txtDIEN_THOAI.Text = info.DIEN_THOAI

            If String.IsNullOrEmpty(info.MA_BAO_TRO) Then
                txtBaoTro.Enabled = True
                btnCheckBaoTro.Enabled = True
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
            txtMA_KH_BAO_TRO.Text = info.MA_KH
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

        If chkDungQuyDaoTao.Checked Then
            Dim oThanhKhoan As THANH_KHOAN_Info = TKQuyDaoTao()
            If oThanhKhoan Is Nothing Then
                Exit Sub
            Else
                Singleton(Of THANH_KHOAN_DAO).Inst.Insert(oThanhKhoan)
            End If
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

        'Lưu vào GÓI ĐẦU TƯ HIS
        If ((info.NV = 0) And (info.TRANG_THAI = 1)) Then
            Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.Insert(info.MA_KH, info.TEN, info.MA_GOI_DAU_TU, DateTime.Now, 1, info.MA_CAY, 0, info.TEN_GOI_DAU_TU, "", 0, Singleton(Of MSACurrentSession).Inst.SessionMember.TEN, "Kích hoạt mã số")
        End If

        Dim objPackage As New GOI_DAU_TU_HIS_Info

        objPackage.MA_KH = info.MA_KH
        objPackage.TEN = info.TEN
        objPackage.MA_CAY = info.MA_CAY
        objPackage.MA_DAU_TU_HIS = Nothing
        objPackage.GOI_DAU_TU_HIS = Nothing
        objPackage.MA_DAU_TU = info.MA_GOI_DAU_TU
        objPackage.GOI_DAU_TU = info.TEN_GOI_DAU_TU
        objPackage.NGUOI_CAP_NHAT = Singleton(Of MSACurrentSession).Inst.SessionMember.TEN
        objPackage.NGAY = DateTime.Now
        objPackage.GHI_CHU = "ĐĂNG KÝ MỚI"
        objPackage.MOI_NHAT = 0

        Dim hoahongDAO As New MSA_DOANH_SO_DAO
        Dim packageDAO As New MSA_GOI_DAU_TU_HIS_DAO

        Dim objHoaHong As HOA_HONG = hoahongDAO.Tinh_Hoa_Hong(objPackage.MA_CAY, objPackage.MA_KH, DateTime.Today.Month, DateTime.Today.Year)
        objPackage.THUONG_THANH_TICH = objHoaHong.THUONG_THANH_TICH

        packageDAO.Insert(objPackage.MA_KH, objPackage.TEN, objPackage.MA_DAU_TU, objPackage.NGAY, objPackage.MOI_NHAT, objPackage.MA_CAY, objPackage.THUONG_THANH_TICH, objPackage.GOI_DAU_TU, objPackage.GOI_DAU_TU_HIS, objPackage.MA_DAU_TU_HIS, objPackage.NGUOI_CAP_NHAT, objPackage.GHI_CHU)


        Dim lstDanhHieu As List(Of String) = checkDanhHieu(info.MA_CAY)
        If lstDanhHieu IsNot Nothing AndAlso lstDanhHieu.Count > 0 Then
            For Each MA_CAY As String In lstDanhHieu
                Singleton(Of MSA_MemberDAO).Inst.UpdateDanhHieuKimCuong(MA_CAY)
                'CHECK DANH HIEU CHU TICH
                Dim objMember As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindBaoTro(MA_CAY)
                If objMember.MA_DANH_HIEU < 2 Then
                    'CHECK DOANH SO TICH LUY
                    Dim oHoaHong As HOA_HONG
                    Dim daoDOANH_SO As New MSA_DOANH_SO_DAO
                    oHoaHong = daoDOANH_SO.Tinh_Hoa_Hong(objMember.MA_CAY, _
                                     Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH, _
                                     DateTime.Today.Month, DateTime.Today.Year)
                    Dim DOANH_SO_NHANH_YEU As Long = IIf(oHoaHong.DOANH_SO_TICH_LUY_TRAI >= oHoaHong.DOANH_SO_TICH_LUY_PHAI, oHoaHong.DOANH_SO_TICH_LUY_PHAI, oHoaHong.DOANH_SO_TICH_LUY_TRAI)
                    If DOANH_SO_NHANH_YEU >= 9000000000 Then
                        Singleton(Of MSA_MemberDAO).Inst.UpdateDanhHieuChuTich(objMember.MA_CAY)
                    End If
                End If

            Next
        End If
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

    Private Function TKQuyDaoTao() As THANH_KHOAN_Info
        Dim rtn As Boolean = True
        Dim TK As Decimal
        Dim oThanhKhoan As New THANH_KHOAN_Info
        Dim o As HOA_HONG
        If chkDungQuyDaoTao.Checked Then
            If txtMA_BAO_TRO.Text.Trim.Equals("") Then
                lblError.Text = "Người bảo trợ không tồn tại."
                rtn = False
            End If
            o = Singleton(Of MSA_DOANH_SO_DAO).Inst.Tinh_Hoa_Hong(txtMA_BAO_TRO.Text, _
                                                 txtMA_KH_BAO_TRO.Text, _
                                                 DateTime.Today.Month, DateTime.Today.Year)
            If Not o Is Nothing Then
                o.MA_KH = txtMA_KH_BAO_TRO.Text
                Select Case (lstGOI_DAU_TU.SelectedIndex + 1)
                    Case 1
                        lblError.Text = "Chỉ được sử dụng quỹ đào tạo kích hoạt các gói CHUYÊN NGHIỆP, KIM CƯƠNG, CHỦ TỊCH"
                        rtn = False
                    Case 2
                        lblError.Text = "Chỉ được sử dụng quỹ đào tạo kích hoạt các gói CHUYÊN NGHIỆP, KIM CƯƠNG, CHỦ TỊCH"
                        rtn = False
                    Case 3
                        If o.QUY_DAO_TAO < 12300000 Then
                            lblError.Text = "Quỹ đào tạo của người bảo trợ đang có " & o.QUY_DAO_TAO.ToString("") & " không đủ kích hoạt gói CHUYÊN NGHIỆP"
                            rtn = False
                        Else
                            TK = 12300000
                        End If
                    Case 4
                        If o.QUY_DAO_TAO < 24300000 Then
                            lblError.Text = "Quỹ đào tạo của người bảo trợ đang có " & o.QUY_DAO_TAO.ToString("") & " không đủ kích hoạt gói KIM CƯƠNG"
                            rtn = False
                        Else
                            TK = 24300000
                        End If
                    Case 5
                        If o.QUY_DAO_TAO < 36300000 Then
                            lblError.Text = "Quỹ đào tạo của người bảo trợ đang có " & o.QUY_DAO_TAO.ToString("") & " không đủ kích hoạt gói CHỦ TỊCH"
                            rtn = False
                        Else
                            TK = 36300000
                        End If
                End Select
            End If
        Else
            lblError.Text = "Người bảo trợ không tồn tại."
            rtn = False
        End If

        If rtn Then
            lblError.Visible = False
            'TUNGND THANH KHOẢN QUỸ TIỀN MẶT
            oThanhKhoan.ID = 0
            oThanhKhoan.MA_KH = o.MA_KH
            oThanhKhoan.MA_CAY = o.MA_KH
            oThanhKhoan.MA_DAU_TU = o.MA_DAU_TU
            oThanhKhoan.NGAY_RUT = DateTime.Now
            oThanhKhoan.TEN_KH = txtTEN.Text 'Luu ten nguoi duoc nang cap bang tien quy dao tao trong bang thanh khoan
            oThanhKhoan.QUY_TIEN_MAT = o.QUY_TIEN_MAT
            oThanhKhoan.QUY_PHONG_CACH = o.QUY_PHONG_CACH
            oThanhKhoan.QUY_DAO_TAO = o.QUY_DAO_TAO
            oThanhKhoan.QUY_TIEN_MAT_TK = 0
            oThanhKhoan.QUY_PHONG_CACH_TK = 0
            oThanhKhoan.QUY_DAO_TAO_TK = TK
            oThanhKhoan.isTK_QUY_TIEN_MAT = 0
            oThanhKhoan.isTK_QUY_PHONG_CACH = 0
            oThanhKhoan.isTK_QUY_DAO_TAO = 1

            Return oThanhKhoan
        Else
            lblError.Visible = True
            Return Nothing
        End If

    End Function
    Protected Sub chkDungQuyDaoTao_CheckedChanged(sender As Object, e As EventArgs)
        If chkDungQuyDaoTao.Checked Then
            chkCtyHoTro.Checked = False
        End If
    End Sub

    Protected Sub chkCtyHoTro_CheckedChanged(sender As Object, e As EventArgs)
        If chkCtyHoTro.Checked Then
            chkDungQuyDaoTao.Checked = False
        End If
    End Sub
End Class