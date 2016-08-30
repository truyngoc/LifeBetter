Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO
Imports System.IO
Imports System.Collections.Generic
Public Class Avatar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                LoadProfile()
            Else
                Response.Redirect("LoginAccount.aspx")
            End If
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If (Page.IsValid) Then
            Dim ctlMem = New MSA_MemberDAO

            If FileUpload1.HasFile Then
                Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)

                Dim pathFile = "~/Avatar/" + Guid.NewGuid.ToString() + "_" + fileName
                FileUpload1.PostedFile.SaveAs(Server.MapPath(pathFile))

                ctlMem.UpdateImageProfileURL(Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH, pathFile)

                lblMsgAvatar.Text = "Cập nhật hình đại diện thành công"
                lblMsgAvatar.Visible = True

                ReloadSessionVal()

                Response.Redirect("~/Account/Avatar")
            End If

        End If
    End Sub

    Private Sub btnChangePwd_Click(sender As Object, e As EventArgs) Handles btnChangePwd.Click
        If (Page.IsValid) Then
            Dim ctlMem = New MSA_MemberDAO
            Dim ma_KH As String

            ma_KH = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH

            If (ctlMem.Check_OldPassword(ma_KH, txtCurrentPwd.Text)) Then
                ctlMem.ChangePassword(ma_KH, txtNewPwd.Text)

                lblMsgChangePass.Text = "Đổi mật khẩu thành công"
                lblMsgChangePass.Visible = True

                txtCurrentPwd.Text = String.Empty
                txtNewPwd.Text = String.Empty
                txtConfirmNewPwd.Text = String.Empty

                ReloadSessionVal()
            Else
                lblMsgChangePass.Text = "Mật khẩu cũ không đúng"
                lblMsgChangePass.Visible = True
            End If
            
        End If
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        If (Page.IsValid) Then
            Dim ctlMem = New MSA_MemberDAO
            Dim ma_KH As String = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH

            ctlMem.UpdateProfile(ma_KH, txtEmail.Text.Trim, txtDIEN_THOAI.Text.Trim, txtSO_TAI_KHOAN.Text.Trim, txtNGAN_HANG.Text.Trim)

            lblMsgUpdateProfile.Text = "Cập nhật thông tin cá nhân thành công"
            lblMsgUpdateProfile.Visible = True

            ReloadSessionVal()
        End If
    End Sub

    Public Sub LoadProfile()
        Dim ctlMem = New MSA_MemberDAO
        Dim oMem As MSA_MemberInfo
        Dim ma_KH As String = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH

        oMem = ctlMem.FindByMA_KH(ma_KH)

        txtEmail.Text = oMem.DIA_CHI
        txtDIEN_THOAI.Text = oMem.DIEN_THOAI
        txtSO_TAI_KHOAN.Text = oMem.SO_TAI_KHOAN
        txtNGAN_HANG.Text = oMem.NGAN_HANG
    End Sub

    Public Sub ReloadSessionVal()
        Dim ma_KH As String = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH
        Dim _mInfo As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(ma_KH)

        Singleton(Of MSACurrentSession).Inst.SessionMember = _mInfo
    End Sub
End Class