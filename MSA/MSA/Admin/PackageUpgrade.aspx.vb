Imports MSA.COMMON
Imports MSA.INFO
Imports MSA.DAO

Public Class PackageUpgrade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUpgrade_Click(sender As Object, e As EventArgs) Handles btnUpgrade.Click
        If (Page.IsValid) Then
            If ddlGOI_DAU_TU_NANG_CAP.SelectedValue <= ddlGOI_DAU_TU_HIEN_TAI.SelectedValue Then
                lblMsgPackageUpgrade.Text = "Gói nâng cấp phải lớn hơn gói hiện tại"
                lblMsgPackageUpgrade.Visible = True
            Else
                ' upgrade
                Try
                    Dim objPackage As New GOI_DAU_TU_HIS_Info

                    objPackage.MA_KH = txtMA_KH.Text.Trim
                    objPackage.TEN = txtTEN.Text.Trim
                    objPackage.MA_CAY = hidMA_CAY.Value
                    objPackage.MA_DAU_TU_HIS = ddlGOI_DAU_TU_HIEN_TAI.SelectedValue
                    objPackage.GOI_DAU_TU_HIS = ddlGOI_DAU_TU_HIEN_TAI.SelectedItem.Text
                    objPackage.MA_DAU_TU = ddlGOI_DAU_TU_NANG_CAP.SelectedValue
                    objPackage.GOI_DAU_TU = ddlGOI_DAU_TU_NANG_CAP.SelectedItem.Text
                    objPackage.NGUOI_CAP_NHAT = Singleton(Of MSACurrentSession).Inst.SessionMember.TEN
                    objPackage.NGAY = DateTime.Now
                    objPackage.GHI_CHU = txtGHI_CHU.Text
                    objPackage.MOI_NHAT = 2

                    Dim hoahongDAO As New MSA_DOANH_SO_DAO
                    Dim packageDAO As New MSA_GOI_DAU_TU_HIS_DAO

                    Dim objHoaHong As HOA_HONG = hoahongDAO.Tinh_Hoa_Hong(objPackage.MA_CAY, objPackage.MA_KH, DateTime.Today.Month, DateTime.Today.Year)
                    objPackage.THUONG_THANH_TICH = objHoaHong.THUONG_THANH_TICH

                    packageDAO.Insert(objPackage.MA_KH, objPackage.TEN, objPackage.MA_DAU_TU, objPackage.NGAY, objPackage.MOI_NHAT, objPackage.MA_CAY, objPackage.THUONG_THANH_TICH, objPackage.GOI_DAU_TU, objPackage.GOI_DAU_TU_HIS, objPackage.MA_DAU_TU_HIS, objPackage.NGUOI_CAP_NHAT, objPackage.GHI_CHU)

                    Response.Redirect("PackageUpgradeReport.aspx")
                Catch ex As Exception
                    lblMsgPackageUpgrade.Text = ex.Message
                    lblMsgPackageUpgrade.Visible = True
                End Try

            End If
        End If
    End Sub

    Protected Sub btnCheckMA_KH_Click(sender As Object, e As EventArgs) Handles btnCheckMA_KH.Click
        Dim ma_KH As String

        ma_KH = txtMA_KH.Text.Trim

        Dim objMember As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.FindByMA_KH(ma_KH)

        If objMember IsNot Nothing Then
            txtTEN.Text = objMember.TEN
            hidMA_CAY.Value = objMember.MA_CAY
            ddlGOI_DAU_TU_HIEN_TAI.SelectedValue = objMember.MA_GOI_DAU_TU
        Else
            txtTEN.Text = String.Empty
            hidMA_CAY.Value = String.Empty
            ddlGOI_DAU_TU_HIEN_TAI.SelectedValue = ""
        End If
        
    End Sub
End Class