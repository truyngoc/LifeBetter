Imports MSA.DAO
Imports MSA.INFO
Imports MSA.COMMON
Public Class AccountCommisionDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dao = New MSA_DOANH_SO_DAO
            Dim o As HOA_HONG
            Dim iD As Integer

            Try
                iD = Convert.ToInt32(Request.Params("ID"))

                o = dao.get_by_ID(iD)

                Load_DaTa_To_Form_DOANH_SO(o)
                Load_Data_To_Form_HOA_HONG(o)
            Catch ex As Exception
                Throw ex
            End Try            


        End If
    End Sub


    Public Sub Load_Data_To_Form_HOA_HONG(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            'lblTONG_THU_NHAP_CAC_KY.Text = IIf(o.TONG_THU_NHAP_CAC_KY = 0, 0, o.TONG_THU_NHAP_CAC_KY.ToString("#,###"))
            lblHOA_HONG_TRUC_TIEP.Text = IIf(o.HOA_HONG_TRUC_TIEP = 0, 0, o.HOA_HONG_TRUC_TIEP.ToString("#,###"))
            lblHOA_HONG_GIAN_TIEP.Text = IIf(o.HOA_HONG_GIAN_TIEP = 0, 0, o.HOA_HONG_GIAN_TIEP.ToString("#,###"))
            lblHOA_HONG_CO_BAN.Text = IIf(o.HOA_HONG_CO_BAN = 0, 0, o.HOA_HONG_CO_BAN.ToString("#,###"))
            lblHOA_HONG_CO_BAN_DUOC_TINH.Text = IIf(o.HOA_HONG_CO_BAN_DUOC_TINH = 0, 0, o.HOA_HONG_CO_BAN_DUOC_TINH.ToString("#,###"))
            lblQUY_TIEN_MAT.Text = IIf(o.QUY_TIEN_MAT = 0, 0, o.QUY_TIEN_MAT.ToString("#,###"))
            lblQUY_PHONG_CACH.Text = IIf(o.QUY_PHONG_CACH = 0, 0, o.QUY_PHONG_CACH.ToString("#,###"))
            lblQUY_DAO_TAO.Text = IIf(o.QUY_DAO_TAO = 0, 0, o.QUY_DAO_TAO.ToString("#,###"))

            o.TONG_THU_NHAP_THANG = o.HOA_HONG_CO_BAN_DUOC_TINH + o.HOA_HONG_TRUC_TIEP + o.HOA_HONG_GIAN_TIEP
            lblTONG_CONG_DOANH_SO_THANG.Text = IIf(o.TONG_THU_NHAP_THANG = 0, 0, o.TONG_THU_NHAP_THANG.ToString("#,###"))
        End If
    End Sub

    Public Sub Load_DaTa_To_Form_DOANH_SO(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            o.DOANH_SO_CA_NHAN = o.DOANH_SO_TRAI + o.DOANH_SO_PHAI
            o.DOANH_SO_TICH_LUY = o.DOANH_SO_TICH_LUY_TRAI + o.DOANH_SO_TICH_LUY_PHAI

            lblDOANH_SO_CA_NHAN_THANG.Text = IIf(o.DOANH_SO_CA_NHAN = 0, 0, o.DOANH_SO_CA_NHAN.ToString("#,###"))
            lblDOANH_SO_CA_NHAN_TICH_LUY.Text = IIf(o.DOANH_SO_TICH_LUY = 0, 0, o.DOANH_SO_TICH_LUY.ToString("#,###"))
            lblDOANH_SO_TRAI.Text = IIf(o.DOANH_SO_TRAI = 0, 0, o.DOANH_SO_TRAI.ToString("#,###"))
            lblDOANH_SO_PHAI.Text = IIf(o.DOANH_SO_PHAI = 0, 0, o.DOANH_SO_PHAI.ToString("#,###"))
            lblDOANH_SO_KET_CHUYEN_TRAI.Text = IIf(o.DOANH_SO_KET_CHUYEN_TRAI = 0, 0, o.DOANH_SO_KET_CHUYEN_TRAI.ToString("#,###"))
            lblDOANH_SO_KET_CHUYEN_PHAI.Text = IIf(o.DOANH_SO_KET_CHUYEN_PHAI = 0, 0, o.DOANH_SO_KET_CHUYEN_PHAI.ToString("#,###"))
            lblDOANH_SO_TICH_LUY_TRAI.Text = IIf(o.DOANH_SO_TICH_LUY_TRAI = 0, 0, o.DOANH_SO_TICH_LUY_TRAI.ToString("#,###"))
            lblDOANH_SO_TICH_LUY_PHAI.Text = IIf(o.DOANH_SO_TICH_LUY_PHAI = 0, 0, o.DOANH_SO_TICH_LUY_PHAI.ToString("#,###"))
            'lblTONG_SO_THANH_VIEN_TRAI.Text = IIf(o.TONG_SO_THANH_VIEN_TRAI = 0, 0, o.TONG_SO_THANH_VIEN_TRAI.ToString("#,###"))
            'lblTONG_SO_THANH_VIEN_PHAI.Text = IIf(o.TONG_SO_THANH_VIEN_PHAI = 0, 0, o.TONG_SO_THANH_VIEN_PHAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_TRAI.Text = IIf(o.SO_THANH_VIEN_MOI_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_TRAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_PHAI.Text = IIf(o.SO_THANH_VIEN_MOI_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_PHAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_BAO_TRO_TRAI.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_BAO_TRO_PHAI.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI.ToString("#,###"))
        End If
    End Sub
End Class