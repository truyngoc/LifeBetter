Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class AccountManager
    Inherits System.Web.UI.Page

    'Protected Property objSearch as MSA_MemberInfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadThangNam()
            LoadAllAcc()
        End If
    End Sub

    Sub LoadAllAcc()
        Dim lst As List(Of MSA_MemberInfo) = Singleton(Of MSA_MemberDAO).Inst.SEARCH_ALL()
        grdMEMBERS.DataSource = lst
        grdMEMBERS.DataBind()

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim objSearch As New MSA_MemberInfo
        Dim lst As List(Of MSA_MemberInfo)
        Dim ctl As New MSA_MemberDAO
        lblError.Visible = True
        If txtSearch.Text.Trim.Equals("") Then
            LoadAllAcc()
            Exit Sub
        End If

        Select Case ddlDieuKien.SelectedIndex
            Case 0
                objSearch.MA_KH = txtSearch.Text
                lst = ctl.SEARCH_BY_MA_KH(txtSearch.Text.Trim)
            Case 1
                objSearch.TEN = txtSearch.Text
                lst = ctl.SEARCH_BY_TEN(txtSearch.Text.Trim)
            Case 2
                Try
                    objSearch.MA_GOI_DAU_TU = Integer.Parse(txtSearch.Text)
                    lst = ctl.SEARCH_BY_MA_GOI_DAU_TU(txtSearch.Text.Trim)
                Catch ex As Exception
                    lblError.Text = "Mã gói đầu tư từ 1 --> 5"
                    lblError.Visible = True
                End Try
            Case 3
                'Mã khách hàng bảo trợ
                objSearch.MA_BAO_TRO_TT = txtSearch.Text
                lst = ctl.SEARCH_BY_MA_KH_BAO_TRO_TT(txtSearch.Text.Trim)
            Case 4
                objSearch.TEN_BAO_TRO_TT = txtSearch.Text
                lst = ctl.SEARCH_BY_TEN_KH_BAO_TRO_TT(txtSearch.Text.Trim)
            Case 5
                'Mã khách hàng chỉ định
                objSearch.MA_CAY_TT = txtSearch.Text
                lst = ctl.SEARCH_BY_MA_KH_CHI_DINH_TT(txtSearch.Text.Trim)
            Case 6
                objSearch.NHANH_CAY_TT = txtSearch.Text
            Case 7
                objSearch.DIEN_THOAI = txtSearch.Text
                lst = ctl.SEARCH_BY_DIEN_THOAI(txtSearch.Text.Trim)
            Case 8
                objSearch.DIA_CHI = txtSearch.Text
                lst = ctl.SEARCH_BY_DIA_CHI(txtSearch.Text.Trim)
            Case 9
                objSearch.SO_TAI_KHOAN = txtSearch.Text
                lst = ctl.SEARCH_BY_STK(txtSearch.Text.Trim)
            Case 10
                objSearch.NGAN_HANG = txtSearch.Text
                lst = ctl.SEARCH_BY_NGAN_HANG(txtSearch.Text.Trim)
            Case 11
                Try
                    objSearch.NGAY_THAM_GIA = Date.Parse(txtSearch.Text)
                    lst = ctl.SEARCH_BY_NGAY_THAM_GIA(txtSearch.Text.Trim)
                Catch ex As Exception
                    lblError.Text = "Ngày có định dáng tháng/ngày/năm. VD 12/30/2016"
                    lblError.Visible = True
                End Try

            Case 12
                Try
                    objSearch.NGAY_NANG_CAP = Date.Parse(txtSearch.Text)
                    lst = ctl.SEARCH_BY_NGAY_NANG_CAP(txtSearch.Text.Trim)
                    lblError.Text = "Ngày có định dáng tháng/ngày/năm. VD 12/30/2016"
                    lblError.Visible = True
                Catch ex As Exception

                End Try
            Case 13
                lblError.Text = "Mã gói đầu tư từ 1 --> 5"
                lblError.Visible = True
                lst = ctl.SEARCH_BY_TRANG_THAI(txtSearch.Text.Trim)
            Case Else

        End Select

        grdMEMBERS.DataSource = lst
        grdMEMBERS.DataBind()
    End Sub

    Protected Sub grdMEMBERS_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

    Protected Sub grdMEMBERS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdMEMBERS.PageIndex = e.NewPageIndex
        LoadAllAcc()
    End Sub

    Protected Sub ddlDieuKien_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Function LoadGoiDauTu(ByVal MA_DAU_TU As Integer) As String
        Select Case MA_DAU_TU
            Case 1
                Return "KHỞI ĐỘNG"
            Case 2
                Return "KINH DOANH"
            Case 3
                Return "CHUYÊN NGHIỆP"
            Case 4
                Return "KIM CƯƠNG"
            Case 5
                Return "CHỦ TỊCH"
            Case Else
                Return ""
        End Select
    End Function

    Protected Function LoadDanhHieu(ByVal MA_DANH_HIEU As Integer) As String
        Select Case MA_DANH_HIEU
            Case 0
                Return ""
            Case 1
                Return "KIM CƯƠNG"
            Case 2
                Return "CHỦ TỊCH"
            Case Else
                Return ""
        End Select
    End Function

    Protected Sub dllHOA_HONG_THANG_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadThangNam()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = Singleton(Of MSA_DOANH_SO_DAO).Inst.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            dllHOA_HONG_THANG.DataSource = lstMonth
            dllHOA_HONG_THANG.DataValueField = "DS_Value"
            dllHOA_HONG_THANG.DataTextField = "DS_Text"
            dllHOA_HONG_THANG.DataBind()
        Else
            dllHOA_HONG_THANG.DataSource = Nothing
            dllHOA_HONG_THANG.DataBind()
        End If


    End Sub
End Class