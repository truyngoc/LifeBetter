Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO
Public Class AccountReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadThangNam()
            LoadAllAcc()
        End If
    End Sub

    Sub LoadAllAcc()        
        Dim searchText As String = txtSearch.Text
        Dim iType As Integer = ddlDieuKien.SelectedValue
        Dim thoigian As String = dllHOA_HONG_THANG.SelectedValue
        Dim iTrangThai As Integer = ddlTrangThai.SelectedValue

        lblError.Visible = False
        Try
            Dim lst As List(Of MSA_MemberInfo) = Singleton(Of MSA_MemberDAO).Inst.SEARCH_NEW(searchText, iType, thoigian, iTrangThai)

            If (lst IsNot Nothing AndAlso lst.Count > 0) Then
                lblMsgInfo.Text = String.Format("Có {0} kết quả thỏa mãn điều kiện tìm kiếm", lst.Count)
            Else
                lblMsgInfo.Text = "Không có kết quả thỏa mãn điều kiện tìm kiếm"
            End If

            grdMEMBERS.DataSource = lst
            grdMEMBERS.DataBind()
        Catch ex As Exception
            lblError.Text = "Kiểm tra dữ liệu tìm kiếm (Mã gói đầu tư từ 1 --> 5, Ngày có định dạng tháng/ngày/năm. VD 12/30/2016)"
            lblError.Visible = True
        End Try


    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        LoadAllAcc
    End Sub

    Protected Sub grdMEMBERS_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim daoMem As New MSA_MemberDAO
        If (e.CommandName = "cmdDelete") Then
            daoMem.DELETE(e.CommandArgument)

            LoadAllAcc()
        ElseIf (e.CommandName = "cmdLock") Then
            daoMem.LOCK_AND_UNLOCK(e.CommandArgument, 3)

            LoadAllAcc()
        ElseIf (e.CommandName = "cmdUnLock") Then
            daoMem.LOCK_AND_UNLOCK(e.CommandArgument, 1)

            LoadAllAcc()
        ElseIf (e.CommandName = "cmdEdit") Then
            Response.Redirect("EditAccount?MA_KH=" + e.CommandArgument)
        End If
    End Sub

    Protected Sub grdMEMBERS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdMEMBERS.PageIndex = e.NewPageIndex
        LoadAllAcc()
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

    Public Function VisibleByStatus(ByVal trang_thai As Integer, ByVal type As Integer) As Boolean
        If trang_thai = 1 And type = 1 Then
            Return True
        ElseIf trang_thai = 3 And type = 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub LoadThangNam()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = Singleton(Of MSA_DOANH_SO_DAO).Inst.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            lstMonth.Insert(0, New THANG_DOANH_SO With {.DS_Text = "Tất cả", .DS_Value = " "})
            dllHOA_HONG_THANG.DataSource = lstMonth
            dllHOA_HONG_THANG.DataValueField = "DS_Value"
            dllHOA_HONG_THANG.DataTextField = "DS_Text"

            dllHOA_HONG_THANG.Items.Add(New ListItem("Tất cả", " "))

            dllHOA_HONG_THANG.DataBind()
        Else
            dllHOA_HONG_THANG.DataSource = Nothing
            dllHOA_HONG_THANG.DataBind()
        End If


    End Sub

End Class