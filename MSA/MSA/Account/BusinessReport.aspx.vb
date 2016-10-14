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

            ds = Singleton(Of MSA_DOANH_SO_DAO).Inst.business_report_DANH_HIEU(ddlDanhHieu_THANG.SelectedValue, ddlDanhHieu.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Text = String.Format("Có {0} kết quả tìm kiếm", ds.Tables(0).Rows.Count)
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Text = "Không có kết quả thỏa mãn điều kiện tìm kiếm"
            End If
            lblNotify.Visible = True
        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub search_DOANH_SO()
        Try
            Dim ds As New DataSet

            ds = Singleton(Of MSA_DOANH_SO_DAO).Inst.business_report_DOANH_SO(BuildWhereDoanhSO, ddlDoanhSo_THANG.SelectedValue)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Text = String.Format("Có {0} kết quả tìm kiếm", ds.Tables(0).Rows.Count)
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Text = "Không có kết quả thỏa mãn điều kiện tìm kiếm"
            End If
            lblNotify.Visible = True
        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub
    Public Function BuildWhereDoanhSO() As String
        Dim buildWhereText As String = String.Empty
        Dim dk_ds_left As String = String.Empty
        Dim dk_ds_right As String = String.Empty

        If Not String.IsNullOrEmpty(txtDoanhSoTrai.Text) Then
            dk_ds_left = " DOANH_SO_TRAI " + ddlToanTuTrai.SelectedValue + txtDoanhSoTrai.Text
        End If

        If Not String.IsNullOrEmpty(txtDoanhSoPhai.Text) Then
            dk_ds_right = " DOANH_SO_PHAI " + ddlToanTuPhai.SelectedValue + txtDoanhSoPhai.Text
        End If

        If Not String.IsNullOrEmpty(dk_ds_left) AndAlso Not String.IsNullOrEmpty(dk_ds_right) Then
            buildWhereText = dk_ds_left + " AND " + dk_ds_right
        ElseIf Not String.IsNullOrEmpty(dk_ds_left) AndAlso String.IsNullOrEmpty(dk_ds_right) Then
            buildWhereText = dk_ds_left
        ElseIf String.IsNullOrEmpty(dk_ds_left) AndAlso Not String.IsNullOrEmpty(dk_ds_right) Then
            buildWhereText = dk_ds_right
        End If

        Return buildWhereText
    End Function

    Public Sub search_NGAY_THAM_GIA()
        Try
            Dim ds As New DataSet

            ds = Singleton(Of MSA_DOANH_SO_DAO).Inst.business_report_NGAY_THAM_GIA(txtTuNgay.Text, txtDenNgay.Text)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Text = String.Format("Có {0} kết quả tìm kiếm", ds.Tables(0).Rows.Count)
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Text = "Không có kết quả thỏa mãn điều kiện tìm kiếm"
            End If
            lblNotify.Visible = True
        Catch ex As Exception
            lblNotify.Visible = False
        End Try
    End Sub

    Public Sub search_MA_THANH_VIEN()
        Try
            Dim ds As New DataSet

            ds = Singleton(Of MSA_DOANH_SO_DAO).Inst.business_report_MA_THANH_VIEN(txtMA_THANH_VIEN.Text.Trim)

            If ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                datagrid.DataSource = ds.Tables(0)
                datagrid.DataBind()

                lblNotify.Text = String.Format("Có {0} kết quả tìm kiếm", ds.Tables(0).Rows.Count)
            Else

                datagrid.DataSource = Nothing
                datagrid.DataBind()

                lblNotify.Text = "Không có kết quả thỏa mãn điều kiện tìm kiếm"
            End If
            lblNotify.Visible = True
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















    Protected Sub datagrid_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagrid.DataBound
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        Dim cbHeader As CheckBox = CType(datagrid.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)

        'Run the ChangeCheckBoxState client-side function whenever the
        'header checkbox is checked/unchecked
        cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"

        'Add the CheckBox's ID to the client-side CheckBoxIDs array
        Dim ArrayValues As New List(Of String)
        ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))

        For Each gvr As GridViewRow In datagrid.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

            'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
            cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
        Next


        'Output the array to the Literal control (CheckBoxIDsArray)
        CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                "<!--" & vbCrLf & _
                                String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                "// -->" & vbCrLf & _
                                "</script>"

    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=BaoCaoKinhDoanh_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New System.IO.StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            datagrid.AllowPaging = False

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

            datagrid.HeaderRow.BackColor = Drawing.Color.White
            For Each cell As TableCell In datagrid.HeaderRow.Cells
                cell.BackColor = datagrid.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In datagrid.Rows
                row.BackColor = Drawing.Color.White

                'Apply text style to each Row
                'row.Attributes.Add("class", "textmode")

                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = datagrid.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = datagrid.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            datagrid.RenderControl(hw)
            'style to format numbers to string
            'Dim style As String = "<style> .textmode { } </style>"
            'style to format numbers to string
            Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 
    End Sub
End Class