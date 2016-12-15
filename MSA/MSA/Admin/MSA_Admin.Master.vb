Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO


Public Class MSA_Admin
    Inherits System.Web.UI.MasterPage

    Public Property Seconds As Integer
    Public Property Seconds2 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Not Page.IsPostBack) Then
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



                If _mInfo.MA_DANH_HIEU = 0 Then
                    If _mInfo.MA_CAY Is Nothing Then
                        divDanhHieu.Visible = False
                        divKichHoat.Visible = False
                    End If
                    If _mInfo.NGAY_NANG_CAP Is Nothing Then
                        If DateDiff("d", _mInfo.NGAY_THAM_GIA, Date.Now) < 60 Then
                            Seconds = DateDiff("s", Date.Now, DateAdd("d", 60, _mInfo.NGAY_THAM_GIA))
                        ElseIf DateDiff("d", _mInfo.NGAY_THAM_GIA, Date.Now) < 150 Then
                            Seconds = DateDiff("s", Date.Now, DateAdd("d", 150, _mInfo.NGAY_THAM_GIA))
                        Else
                            Seconds = 0
                        End If
                    Else
                        If DateDiff("d", _mInfo.NGAY_NANG_CAP, Date.Now) < 60 Then
                            Seconds = DateDiff("s", Date.Now, DateAdd("d", 60, _mInfo.NGAY_NANG_CAP))
                        ElseIf DateDiff("d", _mInfo.NGAY_NANG_CAP, Date.Now) < 150 Then
                            Seconds = DateDiff("s", Date.Now, DateAdd("d", 150, _mInfo.NGAY_NANG_CAP))
                        Else
                            Seconds = 0
                        End If
                    End If
                Else
                    divDanhHieu.Visible = False
                    lblDanhHieu.Text = "CHÚC MỪNG BẠN ĐẠT DANH HIỆU KIM CƯƠNG"

                End If

                If _mInfo.NGAY_NANG_CAP Is Nothing Then
                    Seconds2 = DateDiff("s", Date.Now, DateAdd("d", 365, _mInfo.NGAY_THAM_GIA))
                Else
                    Seconds2 = DateDiff("s", Date.Now, DateAdd("d", 365, _mInfo.NGAY_NANG_CAP))
                End If

                'phut = DateDiff("n", _mInfo.NGAY_THAM_GIA, Date.Now)
                'ngay = phut / 1440
                'phut = phut - ngay * 1440
                'gio = phut / 60
                'phut = phut - gio * 60
                'lblCountDown.Text = ngay & " ngày " & gio & " giờ " & phut & " phút "
                Try
                    lblMabaotro.Text = Singleton(Of MSA_MemberDAO).Inst.FindByMA_CAY(_mInfo.MA_BAO_TRO_TT).MA_KH & " - " & _mInfo.TEN_BAO_TRO_TT
                Catch ex As Exception

                End Try

                If _mInfo.MA_CAY_TT IsNot Nothing Then
                    lblCAY_TT.Text = Singleton(Of MSA_MemberDAO).Inst.FindByMA_CAY(_mInfo.MA_CAY_TT).MA_KH & " - " & _mInfo.TEN_CAY_TT
                End If


                If _mInfo.NHANH_CAY_TT = 1 Then
                    lblNhanh.Text = "TRÁI"
                ElseIf _mInfo.NHANH_CAY_TT = 2 Then
                    lblNhanh.Text = "PHẢI"
                End If


                'truyBN
                imgAnhDaiDien.ImageUrl = _mInfo.URL

                If (_mInfo.NV = 1) Then
                    mnuQuantri.Visible = True
                Else
                    mnuQuantri.Visible = False
                End If
            End If

        End If
        'End If
    End Sub



    Private Sub imgAnhDaiDien_Click(sender As Object, e As Web.UI.ImageClickEventArgs) Handles imgAnhDaiDien.Click
        Response.Redirect("~/Account/Avatar")
    End Sub
End Class