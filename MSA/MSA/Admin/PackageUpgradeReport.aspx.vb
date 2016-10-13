Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class PackageUpgradeReport
    Inherits System.Web.UI.Page

    Private daoDOANH_SO As New MSA_DOANH_SO_DAO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            bindDDL_MonthDS()

            bindNANG_CAP_GOI()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        bindNANG_CAP_GOI()
    End Sub

    Public Sub bindNANG_CAP_GOI()

        Try
            Dim ds As DataSet

            ds = Singleton(Of MSA_GOI_DAU_TU_HIS_DAO).Inst.report_UpgradePackage(ddlMonthDS.SelectedValue, txtSearch.Text.Trim, ddlDieuKien.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Visible = False
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Visible = True
            End If

            lblError.Visible = False
        Catch ex As Exception
            lblError.Text = "Kiểm tra dữ liệu tìm kiếm (Mã gói đầu tư từ 1 --> 5)"
            lblError.Visible = True
            lblNotify.Visible = False
        End Try
        
    End Sub

    Public Sub bindDDL_MonthDS()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = daoDOANH_SO.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            lstMonth.Insert(0, New THANG_DOANH_SO With {.DS_Text = "Tất cả", .DS_Value = " "})

            ddlMonthDS.DataSource = lstMonth
            ddlMonthDS.DataValueField = "DS_Value"
            ddlMonthDS.DataTextField = "DS_Text"
            ddlMonthDS.DataBind()
        Else
            ddlMonthDS.DataSource = Nothing
            ddlMonthDS.DataBind()
        End If
    End Sub


    Public Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        datagrid.PageIndex = e.NewPageIndex
        bindNANG_CAP_GOI()
    End Sub

End Class