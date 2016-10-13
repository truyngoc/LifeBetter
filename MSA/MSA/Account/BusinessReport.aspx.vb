Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class BusinessReport
    Inherits System.Web.UI.Page

    Private daoDOANH_SO As New MSA_DOANH_SO_DAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            bindDDL_Month_DanhHieu()
            bindDDL_Month_DoanhSo()

            bindDDL_DanhHieu()

            txtDoanhSoTrai.Attributes.Add("type", "number")
            txtDoanhSoPhai.Attributes.Add("type", "number")
        End If
    End Sub

    Public Sub bindDDL_Month_DanhHieu()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = daoDOANH_SO.get_All_Thang_Doanh_so

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            lstMonth.Insert(0, New THANG_DOANH_SO With {.DS_Text = "Tất cả", .DS_Value = " "})

            ddlDanhHieu_THANG.DataSource = lstMonth
            ddlDanhHieu_THANG.DataValueField = "DS_Value"
            ddlDanhHieu_THANG.DataTextField = "DS_Text"
            ddlDanhHieu_THANG.DataBind()
        Else
            ddlDanhHieu_THANG.DataSource = Nothing
            ddlDanhHieu_THANG.DataBind()
        End If
    End Sub

    Public Sub bindDDL_Month_DoanhSo()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = daoDOANH_SO.get_All_Thang_Doanh_so

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            'lstMonth.Insert(0, New THANG_DOANH_SO With {.DS_Text = "Tất cả", .DS_Value = " "})

            ddlDoanhSo_THANG.DataSource = lstMonth
            ddlDoanhSo_THANG.DataValueField = "DS_Value"
            ddlDoanhSo_THANG.DataTextField = "DS_Text"
            ddlDoanhSo_THANG.DataBind()
        Else
            ddlDoanhSo_THANG.DataSource = Nothing
            ddlDoanhSo_THANG.DataBind()
        End If
    End Sub

    Public Sub bindDDL_DanhHieu()
        Dim daGOI_DAU_TU As New MSA_GOI_DAU_TU_HIS_DAO
        Dim lstGOI_DAU_TU As List(Of GOI_DAU_TU_Info)

        lstGOI_DAU_TU = daGOI_DAU_TU.GOI_DAU_TU_GetAll()

        If (lstGOI_DAU_TU IsNot Nothing AndAlso lstGOI_DAU_TU.Count > 0) Then
            'lstGOI_DAU_TU.Insert(0, New GOI_DAU_TU_Info With {.TEN = "Tất cả", .MA_DAU_TU = 0})

            ddlDanhHieu.DataSource = lstGOI_DAU_TU
            ddlDanhHieu.DataValueField = "MA_DAU_TU"
            ddlDanhHieu.DataTextField = "TEN"
            ddlDanhHieu.DataBind()
        Else
            ddlDanhHieu.DataSource = Nothing
            ddlDanhHieu.DataBind()
        End If
    End Sub

    Public Sub search_DANH_HIEU()
        Try
            Dim ds As New DataSet

            'ds = Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.report_UpgradePackage(ddlMonthDS.SelectedValue, txtSearch.Text.Trim, ddlDieuKien.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Visible = False
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Visible = True
            End If

        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub search_DOANH_SO()
        Try
            Dim ds As New DataSet

            'ds = Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.report_UpgradePackage(ddlMonthDS.SelectedValue, txtSearch.Text.Trim, ddlDieuKien.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Visible = False
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Visible = True
            End If

        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub search_NGAY_THAM_GIA()
        Try
            Dim ds As New DataSet

            'ds = Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.report_UpgradePackage(ddlMonthDS.SelectedValue, txtSearch.Text.Trim, ddlDieuKien.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Visible = False
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Visible = True
            End If

        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub search_MA_THANH_VIEN()
        Try
            Dim ds As New DataSet

            'ds = Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.report_UpgradePackage(ddlMonthDS.SelectedValue, txtSearch.Text.Trim, ddlDieuKien.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Visible = False
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Visible = True
            End If

        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        datagrid.PageIndex = e.NewPageIndex

        Select Case hidTypeSearch.Value
            Case 1
                search_DANH_HIEU()
            Case 2
                search_DOANH_SO()
            Case 3
                search_NGAY_THAM_GIA()
            Case 4
                search_MA_THANH_VIEN()
        End Select

    End Sub

    Protected Sub btnSearchDanhHieu_Click(sender As Object, e As EventArgs) Handles btnSearchDanhHieu.Click
        hidTypeSearch.Value = 1
        search_DANH_HIEU()
    End Sub

    Protected Sub btnSearch_DOANH_SO_Click(sender As Object, e As EventArgs) Handles btnSearch_DOANH_SO.Click
        hidTypeSearch.Value = 2
        search_DOANH_SO()
    End Sub

    Protected Sub btnSearch_NGAY_THAM_GIA_Click(sender As Object, e As EventArgs) Handles btnSearch_NGAY_THAM_GIA.Click
        hidTypeSearch.Value = 3
        search_NGAY_THAM_GIA()
    End Sub

    Protected Sub btnSearch_MA_THANH_VIEN_Click(sender As Object, e As EventArgs) Handles btnSearch_MA_THANH_VIEN.Click
        hidTypeSearch.Value = 4
        search_MA_THANH_VIEN()
    End Sub
End Class