Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class RegisterEx
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim a = Request.Params
            If Request.QueryString("ref") IsNot Nothing Then
                Dim strMa_CAY = Request.QueryString("ref").ToString().MSA_Decrypt(MSA_Constants.ConstEncriptKey.KeyEncriptRef)
                If Singleton(Of MSA_MemberDAO).Inst.FindByMA_CAY(strMa_CAY) Is Nothing Then
                    Response.Redirect("LoginAccount.aspx")
                Else
                    lblMA_BAO_TRO_TT.Text = strMa_CAY
                End If

            Else
                'Response.Redirect("/ErrorPages/Oops.aspx")
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
                _mInfo.SO_TAI_KHOAN = ""
                _mInfo.NGAN_HANG = ""
                _mInfo.MAT_KHAU = txtMAT_KHAU.Text
                _mInfo.TRANG_THAI = 0
                _mInfo.URL = ""
                _mInfo.NV = 0

                _mInfo.MA_BAO_TRO_TT = IIf(lblMA_BAO_TRO_TT.Text.Trim.Equals(""), String.Empty, lblMA_BAO_TRO_TT.Text)
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
                strBuilder.AppendLine("<b><a href='http://lifebetter.com.vn/LoginAccount'>http://lifebetter.com.vn </a></b><br/>")

                strBuilder.AppendLine("<b><br/><br/><br/>Thanks & Best regards!</b><br/>")
                strBuilder.AppendLine("<b><br/>Adminstrator LIFE BETTER!</b><br/>")

                Dim str = MSA_Helper.SendMail(txtDIA_CHI.Text, "LIFE BETTER", strBuilder.ToString())

                lblMessages.Text = "Chúc mừng bạn đã đăng ký thành công! "
                lblMessages2.Text = " Mã số thành viên của bạn là: "
                lblMaKHMOI.Text = MA_KH
                ''

            Catch ex As Exception
                Throw New Exception(ex.ToString)
                lblMessages.Text = ""
                lblMaKHMOI.Text = ""
            End Try



        End If
    End Sub
End Class