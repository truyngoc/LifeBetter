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
            bindDDL_Month()
            ThongKeHeThong()
        End If
    End Sub

    Private Sub btnChotHoaHong_Click(sender As Object, e As EventArgs) Handles btnChotHoaHong.Click
        Dim SelectedValue As String = ddlMonth.SelectedValue
        Dim thang As Integer = Integer.Parse(SelectedValue.Substring(0, SelectedValue.Length - 4))
        Dim nam As Integer = Integer.Parse(SelectedValue.Substring(thang.ToString.Length, 4))
        Chot_Doanh_So(thang, nam)

        ThongKeHeThong()
    End Sub


    Public Sub Chot_Doanh_So(ByVal thang As Integer, ByVal nam As Integer)
        Try

            Dim daoMem As New MSA_MemberDAO
            Dim daoThanhKhoan As New THANH_KHOAN_DAO

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

                    Dim oThanhKhoan As New THANH_KHOAN_Info
                    'TUNGND THANH KHOẢN QUỸ TIỀN MẶT
                    oThanhKhoan.ID = 0
                    oThanhKhoan.MA_KH = ds.MA_KH
                    oThanhKhoan.MA_CAY = ds.MA_KH
                    oThanhKhoan.MA_DAU_TU = ds.MA_DAU_TU
                    oThanhKhoan.NGAY_RUT = DateTime.Now
                    oThanhKhoan.TEN_KH = ds.TEN
                    oThanhKhoan.QUY_TIEN_MAT = ds.QUY_TIEN_MAT
                    oThanhKhoan.QUY_PHONG_CACH = ds.QUY_PHONG_CACH
                    oThanhKhoan.QUY_DAO_TAO = ds.QUY_DAO_TAO
                    oThanhKhoan.QUY_PHONG_CACH_TK = 0
                    oThanhKhoan.QUY_DAO_TAO_TK = 0
                    oThanhKhoan.isTK_QUY_PHONG_CACH = 0
                    oThanhKhoan.isTK_QUY_DAO_TAO = 0
                    If ds.QUY_TIEN_MAT >= 3000000 Then   'Thanh khoản 100%
                        oThanhKhoan.QUY_TIEN_MAT_TK = ds.QUY_TIEN_MAT
                        ds.QUY_TIEN_MAT = 0
                        oThanhKhoan.isTK_QUY_TIEN_MAT = 1
                        daoThanhKhoan.Insert(oThanhKhoan)
                        'Else
                        '    oThanhKhoan.QUY_TIEN_MAT_TK = 0
                        '    oThanhKhoan.isTK_QUY_TIEN_MAT = 0
                    End If
                    daoDOANH_SO.Insert(ds)
                Next

                ' cap nhat vao db
                'For Each d As HOA_HONG In lstDS

                'Next

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
        'lblTHUONG_THANH_TICH.Text = IIf(oTK.TONG_THUONG_THANH_TICH = 0, 0, oTK.TONG_THUONG_THANH_TICH.ToString("#,###"))
        lblTHUONG_THANH_TICH_DUOC_TINH.Text = IIf(oTK.TONG_THUONG_THANH_TICH_DUOC_TINH = 0, 0, oTK.TONG_THUONG_THANH_TICH_DUOC_TINH.ToString("#,###"))
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

    Public Sub bindDDL_Month()
        Dim lstMonth As New List(Of THANG_DOANH_SO)
        Dim o As New THANG_DOANH_SO
        o.DS_Value = DateTime.Now.Month.ToString + DateTime.Now.Year.ToString
        o.DS_Text = "Tháng " + DateTime.Now.Month.ToString + "-" + DateTime.Now.Year.ToString
        lstMonth.Add(o)

        Dim near As New THANG_DOANH_SO
        Dim nearMonth As Integer
        Dim nearYear As Integer

        If DateTime.Now.Month = 1 Then
            nearMonth = 12
            nearYear = Date.Now.Year - 1
        Else
            nearMonth = DateTime.Now.Month - 1
            nearYear = DateTime.Now.Year
        End If
        near.DS_Value = nearMonth.ToString + nearYear.ToString
        near.DS_Text = "Tháng " + nearMonth.ToString + "-" + nearYear.ToString

        Dim lstDS As List(Of THANG_DOANH_SO)
        lstDS = daoDOANH_SO.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            If Not lstDS.Exists(Function(x) x.DS_Value.Contains(near.DS_Value)) Then
                lstMonth.Add(near)  'ADD THÁNG TRƯỚC ĐỂ TÍNH DS NẾU BỊ QUA THÁNG
            End If
        End If


        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            ddlMonth.DataSource = lstMonth
            ddlMonth.DataValueField = "DS_Value"
            ddlMonth.DataTextField = "DS_Text"
            ddlMonth.DataBind()
        Else
            ddlMonth.DataSource = Nothing
            ddlMonth.DataBind()
        End If
    End Sub
    Private Sub ddlMonthDS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonthDS.SelectedIndexChanged
        ThongKeHeThong()
    End Sub
End Class