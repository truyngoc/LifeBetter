Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO

Public Class Register
    Inherits System.Web.UI.Page

    Protected Property strLink As String
        Get
            Return ViewState("strLink")
        End Get
        Set(value As String)
            ViewState("strLink") = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Singleton(Of MSACurrentSession).Inst.isLoginUser Then
                Dim h1 = Request.Url.Host
                Dim h2 = Request.Url.Authority
                Me.strLink = h2 & "/Account/RegisterEx?ref=" + Singleton(Of MSACurrentSession).Inst.SessionMember.MA_BAO_TRO.MSA_Encrypt(MSA_Constants.ConstEncriptKey.KeyEncriptRef)
            Else
                Response.Redirect("LoginAccount.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Page.IsValid Then
            Try

                Dim _mInfo As New MSA_MemberInfo()
                'pnForm.UpdateSource(Of MSA_MemberInfo)(_mInfo, False)
                _mInfo.MA_KH = ""
                _mInfo.TEN = txtTEN.Text.Trim
                _mInfo.DIEN_THOAI = txtDIEN_THOAI.Text.Trim
                _mInfo.DIA_CHI = txtDIA_CHI.Text
                _mInfo.SO_TAI_KHOAN = txtSO_TAI_KHOAN.Text
                _mInfo.NGAN_HANG = txtNGAN_HANG.Text
                _mInfo.MAT_KHAU = txtMAT_KHAU.Text
                _mInfo.TRANG_THAI = 0
                _mInfo.URL = ""
                _mInfo.NV = 0

                _mInfo.MA_BAO_TRO_TT = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY
                ''Insert vào CSDL:
                Dim da As New MSA_MemberDAO()



                Dim MA_KH As String = da.Insert(_mInfo)
                ''Send mail
                Dim strBuilder As New StringBuilder()
                strBuilder.AppendLine("<b>Xin chào  " + txtTEN.Text + "</b><br/>")
                strBuilder.AppendLine("<b>Chào mừng bạn đến với gia đình LIFE BETTER </b><br/>")
                strBuilder.AppendLine("<b>Mã khách hàng của bạn: " + MA_KH + "</b><br/>")
                strBuilder.AppendLine("<b>Hãy liên hệ với văn phòng LIFE BETTER để được hướng dẫn cách chọn gói tham gia.</b><br/>")
                strBuilder.AppendLine("<b>Bạn có thể đăng nhập vào hệ thống LIFE BETTER theo mã khách hàng theo địa chỉ:.</b><br/>")
                strBuilder.AppendLine("<b><a href='http://lifebetter.org/LoginAccount'>http://lifebetter.org </a></b><br/>")

                strBuilder.AppendLine("<b><br/><br/><br/>Thanks & Best regards!</b><br/>")
                strBuilder.AppendLine("<b><br/>Adminstrator LIFE BETTER!</b><br/>")

                Dim str = MSA_Helper.SendMail(txtDIA_CHI.Text, "LIFE BETTER", strBuilder.ToString())

                lblMessages.Text = "Tạo tài khoản thành công!, thông tin tài khoản vừa tạo:  " + MA_KH + "  sẽ gửi vào email:  " + txtDIA_CHI.Text
                ''
                Me.strLink = "/RegisterEx?ref=" + Singleton(Of MSACurrentSession).Inst.SessionMember.MA_BAO_TRO.MSA_Encrypt(MSA_Constants.ConstEncriptKey.KeyEncriptRef)
            Catch ex As Exception
                Throw New Exception(ex.ToString)
                lblMessages.Text = ""
            End Try


        End If
    End Sub

End Class