Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO


Public Class MSA_Admin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                Dim _mInfo As MSA_MemberInfo = Singleton(Of MSACurrentSession).Inst.SessionMember
                If (_mInfo IsNot Nothing) Then
                    lblMaKH.Text = _mInfo.MA_KH
                    lblTEN_GOI.Text = _mInfo.TEN_GOI_DAU_TU
                    lblName.Text = _mInfo.TEN
                    lblCMND.Text = _mInfo.CMND
                    'lblNGAY_SINH.Text = _mInfo.NGAY_SINH.Value.Date.ToString("dd/MM/yyyy")
                    lblDIEN_THOAI.Text = _mInfo.DIEN_THOAI
                    lblDIA_CHI.Text = _mInfo.DIA_CHI
                    lblSO_TAI_KHOAN.Text = _mInfo.SO_TAI_KHOAN
                    lblNGAN_HANG.Text = _mInfo.NGAN_HANG
                    ''lblMST.Text = _mInfo.MST
                    lblNGAY_THAM_GIA.Text = _mInfo.NGAY_THAM_GIA.Value.Date.ToString("dd/MM/yyyy")
                    'Dim ngay, gio, phut As Integer
                    'phut = DateDiff("n", _mInfo.NGAY_THAM_GIA, Date.Now)
                    'ngay = phut / 1440
                    'phut = phut - ngay * 1440
                    'gio = phut / 60
                    'phut = phut - gio * 60
                    'lblCountDown.Text = ngay & " ngày " & gio & " giờ " & phut & " phút "
                    lblMabaotro.Text = _mInfo.MA_BAO_TRO_TT & " - " & _mInfo.TEN_BAO_TRO_TT
                    lblCAY_TT.Text = _mInfo.MA_CAY_TT & " - " & _mInfo.TEN_CAY_TT
                    If _mInfo.NHANH_CAY_TT = 0 Then
                        lblNhanh.Text = "TRÁI"
                    Else
                        lblNhanh.Text = "PHẢI"
                    End If


                    'truyBN
                    imgAnhDaiDien.ImageUrl = _mInfo.URL

                    If (_mInfo.MA_KH = "admin") Then
                        mnuQuantri.Visible = True
                    Else
                        mnuQuantri.Visible = False
                    End If
                End If
                
            End If
        End If
    End Sub



    Private Sub imgAnhDaiDien_Click(sender As Object, e As Web.UI.ImageClickEventArgs) Handles imgAnhDaiDien.Click
        Response.Redirect("~/Account/Avatar")
    End Sub
End Class