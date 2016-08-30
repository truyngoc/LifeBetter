Imports MSA.INFO
Imports MSA.DAO
Imports MSA.COMMON
Imports System.Threading

Public Class AccountCommisionCommit
    Inherits System.Web.UI.Page

    Private daoDOANH_SO As New MSA_DOANH_SO_DAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindDDL_MonthDS()

            ThongKeHeThong()
        End If
    End Sub

    Private Sub btnChotHoaHong_Click(sender As Object, e As EventArgs) Handles btnChotHoaHong.Click

        Chot_Doanh_So(DateTime.Today.Month, DateTime.Today.Year)

        ThongKeHeThong()
    End Sub


    Public Sub Chot_Doanh_So(ByVal thang As Integer, ByVal nam As Integer)
        Try
            Dim daoMem As New MSA_MemberDAO

            Dim lstMem As List(Of MSA_MemberInfo)
            Dim lstDS As New List(Of HOA_HONG)

            Dim check As Boolean

            check = daoDOANH_SO.Check_Exist(thang, nam)

            If Not check Then
                ' lay tat ca thanh vien
                lstMem = daoMem.get_All()

                ' tinh doanh so - hoa hong        
                For Each o As MSA_MemberInfo In lstMem
                    Dim ds As HOA_HONG
                    ds = daoDOANH_SO.Tinh_Hoa_Hong(o.MA_CAY, o.MA_KH, thang, nam)

                    ds.MA_KH = o.MA_KH
                    ds.MA_DAU_TU = o.MA_GOI_DAU_TU
                    ds.NAM = nam
                    ds.THANG = thang

                    lstDS.Add(ds)
                Next

                ' cap nhat vao db
                For Each d As HOA_HONG In lstDS
                    daoDOANH_SO.Insert(d)
                Next

                lblResult.ForeColor = Drawing.Color.Blue
                lblResult.Text = String.Format("Chốt DOANH SỐ - HOA HỒNG cho tháng {0} - {1} thành công", DateTime.Today.Month, DateTime.Today.Year)

            Else
                lblResult.ForeColor = Drawing.Color.Blue
                lblResult.Text = String.Format("Đã thực hiện chốt DOANH SỐ - HOA HỒNG cho tháng {0} - {1}", DateTime.Today.Month, DateTime.Today.Year)
            End If

        Catch ex As Exception
            lblResult.ForeColor = Drawing.Color.Red
            lblResult.Text = String.Format("Đã có lỗi khi thực hiện")
        End Try
    End Sub

    Public Sub ThongKeHeThong()
        Dim oTK As THONG_KE_HE_THONG

        oTK = daoDOANH_SO.ThongKeHeThong(ddlMonthDS.SelectedValue)

        lblTONG_SO_THANH_VIEN.Text = IIf(oTK.TONG_SO_THANH_VIEN = 0, 0, oTK.TONG_SO_THANH_VIEN.ToString("#,###"))
        lblTONG_DOANH_SO.Text = IIf(oTK.TONG_DOANH_SO = 0, 0, oTK.TONG_DOANH_SO.ToString("#,###"))
        lblHOA_HONG_TRUC_TIEP.Text = IIf(oTK.TONG_HOA_HONG_TRUC_TIEP = 0, 0, oTK.TONG_HOA_HONG_TRUC_TIEP.ToString("#,###"))
        lblHOA_HONG_GIAN_TIEP.Text = IIf(oTK.TONG_HOA_HONG_GIAN_TIEP = 0, 0, oTK.TONG_HOA_HONG_GIAN_TIEP.ToString("#,###"))
        lblHOA_HONG_CO_BAN_DUOC_TINH.Text = IIf(oTK.TONG_HOA_HONG_CO_BAN_DUOC_TINH = 0, 0, oTK.TONG_HOA_HONG_CO_BAN_DUOC_TINH.ToString("#,###"))
        lblQUY_TIEN_MAT.Text = IIf(oTK.TONG_QUY_TIEN_MAT = 0, 0, oTK.TONG_QUY_TIEN_MAT.ToString("#,###"))
        lblQUY_PHONG_CACH.Text = IIf(oTK.TONG_QUY_PHONG_CACH = 0, 0, oTK.TONG_QUY_PHONG_CACH.ToString("#,###"))
        lblQUY_DAO_TAO.Text = IIf(oTK.TONG_QUY_DAO_TAO = 0, 0, oTK.TONG_QUY_DAO_TAO.ToString("#,###"))
        lblTONG_CONG_DOANH_SO_THANG.Text = IIf(oTK.TONG_HOA_HONG = 0, 0, oTK.TONG_HOA_HONG.ToString("#,###"))
    End Sub

    Public Sub bindDDL_MonthDS()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = daoDOANH_SO.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            ddlMonthDS.DataSource = lstMonth
            ddlMonthDS.DataValueField = "DS_Value"
            ddlMonthDS.DataTextField = "DS_Text"
            ddlMonthDS.DataBind()
        Else
            ddlMonthDS.DataSource = Nothing
            ddlMonthDS.DataBind()
        End If
    End Sub

    Private Sub ddlMonthDS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonthDS.SelectedIndexChanged
        ThongKeHeThong()
    End Sub
End Class