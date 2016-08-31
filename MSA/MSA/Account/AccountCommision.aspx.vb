Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class AccountCommision
    Inherits System.Web.UI.Page

    Private daoDOANH_SO As New MSA_DOANH_SO_DAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim sMA_CAY As String
            Dim oHoaHong As HOA_HONG

            ' tinh hoa hong
            sMA_CAY = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY

            'If HttpContext.Current.Session("MSA_DOANHSO_HOAHONG") IsNot Nothing Then
            '    oHoaHong = TryCast(HttpContext.Current.Session("MSA_DOANHSO_HOAHONG"), HOA_HONG)
            'Else            
            '    oHoaHong = Tinh_Hoa_Hong(sMA_CAY)
            '    HttpContext.Current.Session("MSA_DOANHSO_HOAHONG") = oHoaHong
            'End If

            oHoaHong = daoDOANH_SO.Tinh_Hoa_Hong(sMA_CAY, _
                                                 Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH, _
                                                 DateTime.Today.Month, DateTime.Today.Year)

            ' gan len form
            Load_Data_To_Form(oHoaHong)

            bindDOANH_SO()
        End If
        
    End Sub


    'Public Sub BindDropDownList()
    '    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
    '    Dim com As String = "Select ID, Thang + ' - ' + Nam Name from DOANH_SO order by ID desc"
    '    Dim adpt As New SqlDataAdapter(com, con)
    '    Dim dt As New DataTable()
    '    adpt.Fill(dt)

    '    dllHOA_HONG_THANG.DataSource = dt
    '    dllHOA_HONG_THANG.DataBind()
    '    dllHOA_HONG_THANG.DataTextField = "Name"
    '    dllHOA_HONG_THANG.DataValueField = "ID"
    '    dllHOA_HONG_THANG.DataBind()
    'End Sub

    'Public Function Tinh_Hoa_Hong(ByVal MA_CAY As String) As HOA_HONG
    '    Dim oHoaHong = New HOA_HONG

    '    Dim param = New SqlParameter(
    '            "@_ma_cay", SqlDbType.NVarChar, 250)
    '    param.Value = MA_CAY


    '    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
    '        Using cmd As New SqlCommand("sp_TINH_DOANH_SO_HOA_HONG")
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.Parameters.Add(param)
    '            cmd.Connection = con
    '            con.Open()
    '            Using dr As SqlDataReader = cmd.ExecuteReader()
    '                While dr.Read()
    '                    oHoaHong.TONG_SO_THANH_VIEN_TRAI = dr("TONG_SO_THANH_VIEN_TRAI")
    '                    oHoaHong.TONG_SO_THANH_VIEN_PHAI = dr("TONG_SO_THANH_VIEN_PHAI")
    '                    oHoaHong.SO_THANH_VIEN_MOI_TRAI = dr("SO_THANH_VIEN_MOI_TRAI")
    '                    oHoaHong.SO_THANH_VIEN_MOI_PHAI = dr("SO_THANH_VIEN_MOI_PHAI")
    '                    oHoaHong.DOANH_SO_TRAI = dr("DOANH_SO_TRAI")
    '                    oHoaHong.DOANH_SO_PHAI = dr("DOANH_SO_PHAI")
    '                    oHoaHong.DOANH_SO_TICH_LUY_TRAI = dr("DOANH_SO_TICH_LUY_TRAI")
    '                    oHoaHong.DOANH_SO_TICH_LUY_PHAI = dr("DOANH_SO_TICH_LUY_PHAI")
    '                    oHoaHong.DOANH_SO_KET_CHUYEN_TRAI = dr("DOANH_SO_KET_CHUYEN_TRAI")
    '                    oHoaHong.DOANH_SO_KET_CHUYEN_PHAI = dr("DOANH_SO_KET_CHUYEN_PHAI")
    '                    oHoaHong.DOANH_SO_CA_NHAN = dr("DOANH_SO_CA_NHAN")
    '                    oHoaHong.DOANH_SO_TICH_LUY = dr("DOANH_SO_TICH_LUY")
    '                    oHoaHong.HOA_HONG_TRUC_TIEP = dr("HOA_HONG_TRUC_TIEP")
    '                    oHoaHong.HOA_HONG_GIAN_TIEP = dr("HOA_HONG_GIAN_TIEP")
    '                    oHoaHong.HOA_HONG_CO_BAN = dr("HOA_HONG_CO_BAN")
    '                    oHoaHong.HOA_HONG_CO_BAN_DUOC_TINH = dr("HOA_HONG_CO_BAN_DUOC_TINH")
    '                    oHoaHong.TONG_THU_NHAP_THANG = dr("TONG_THU_NHAP_THANG")
    '                    oHoaHong.TONG_THU_NHAP_CAC_KY = dr("TONG_THU_NHAP_CAC_KY")
    '                    oHoaHong.QUY_TIEN_MAT = dr("QUY_TIEN_MAT")
    '                    oHoaHong.QUY_PHONG_CACH = dr("QUY_PHONG_CACH")
    '                    oHoaHong.QUY_DAO_TAO = dr("QUY_DAO_TAO")
    '                End While
    '            End Using
    '            con.Close()

    '        End Using
    '    End Using

    '    Return oHoaHong
    'End Function

    Public Sub Load_Data_To_Form(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            lblTONG_THU_NHAP_CAC_KY.Text = IIf(o.TONG_THU_NHAP_CAC_KY = 0, 0, o.TONG_THU_NHAP_CAC_KY.ToString("#,###"))
            lblHOA_HONG_TRUC_TIEP.Text = IIf(o.HOA_HONG_TRUC_TIEP = 0, 0, o.HOA_HONG_TRUC_TIEP.ToString("#,###"))
            lblHOA_HONG_GIAN_TIEP.Text = IIf(o.HOA_HONG_GIAN_TIEP = 0, 0, o.HOA_HONG_GIAN_TIEP.ToString("#,###"))
            'lblHOA_HONG_CO_BAN.Text = IIf(o.HOA_HONG_CO_BAN = 0, 0, o.HOA_HONG_CO_BAN.ToString("#,###"))
            lblHOA_HONG_CO_BAN_DUOC_TINH.Text = IIf(o.HOA_HONG_CO_BAN_DUOC_TINH = 0, 0, o.HOA_HONG_CO_BAN_DUOC_TINH.ToString("#,###"))
            lblQUY_TIEN_MAT.Text = IIf(o.QUY_TIEN_MAT = 0, 0, o.QUY_TIEN_MAT.ToString("#,###"))
            lblQUY_PHONG_CACH.Text = IIf(o.QUY_PHONG_CACH = 0, 0, o.QUY_PHONG_CACH.ToString("#,###"))
            lblQUY_DAO_TAO.Text = IIf(o.QUY_DAO_TAO = 0, 0, o.QUY_DAO_TAO.ToString("#,###"))
            'lblTONG_CONG_DOANH_SO_THANG.Text = IIf(o.TONG_THU_NHAP_THANG = 0, 0, o.TONG_THU_NHAP_THANG.ToString("#,###"))

            lblTHUONG_THANH_TICH.Text = IIf(o.THUONG_THANH_TICH = 0, 0, o.THUONG_THANH_TICH.ToString("#,###"))
            'lblTHUONG_THANH_TICH_DUOC_TINH.Text = IIf(o.THUONG_THANH_TICH_DUOC_TINH = 0, 0, o.THUONG_THANH_TICH_DUOC_TINH.ToString("#,###"))
        End If
    End Sub

    Public Sub bindDOANH_SO()
        Dim sMA_KH As String

        sMA_KH = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH

        Dim lstDOANH_SO As List(Of HOA_HONG)
        lstDOANH_SO = daoDOANH_SO.get_by_MA_KH(sMA_KH)

        If lstDOANH_SO IsNot Nothing Then
            datagrid.DataSource = lstDOANH_SO
            datagrid.DataBind()
        Else
            datagrid.DataSource = Nothing
            datagrid.DataBind()
        End If



        
    End Sub

    Public Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        datagrid.PageIndex = e.NewPageIndex
        bindDOANH_SO()
    End Sub

    Protected Sub datagrid_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles datagrid.RowCommand
        Try
            If e.CommandName = "cmdView" Then
                'RaiseEvent pEvtSua(e.CommandArgument)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


'Public Class HOA_HONG
'    Public Property ID As Integer
'    Public Property MA_KH As String
'    Public Property MA_DAU_TU As Integer
'    Public Property THANG As Integer
'    Public Property NAM As Integer
'    Public Property DOANH_SO_TRAI As Decimal    '
'    Public Property DOANH_SO_PHAI As Decimal    '
'    Public Property DOANH_SO_KET_CHUYEN_TRAI As Decimal '
'    Public Property DOANH_SO_KET_CHUYEN_PHAI As Decimal '
'    Public Property DOANH_SO_TICH_LUY_TRAI As Decimal   '
'    Public Property DOANH_SO_TICH_LUY_PHAI As Decimal   '
'    Public Property SO_THANH_VIEN_MOI_TRAI As Integer   '
'    Public Property SO_THANH_VIEN_MOI_PHAI As Integer   '
'    Public Property HOA_HONG_TRUC_TIEP As Decimal   '
'    Public Property HOA_HONG_GIAN_TIEP As Decimal   '
'    Public Property HOA_HONG_CO_BAN As Decimal  '
'    Public Property HOA_HONG_CO_BAN_DUOC_TINH As Decimal  '
'    Public Property QUY_TIEN_MAT As Decimal
'    Public Property QUY_PHONG_CACH As Decimal
'    Public Property QUY_DAO_TAO As Decimal

'    '
'    Public Property DOANH_SO_CA_NHAN As Decimal     '
'    Public Property DOANH_SO_TICH_LUY As Decimal    '
'    Public Property TONG_SO_THANH_VIEN_TRAI As Integer  '
'    Public Property TONG_SO_THANH_VIEN_PHAI As Integer  '
'    Public Property TONG_THU_NHAP_THANG As Decimal
'    Public Property TONG_THU_NHAP_CAC_KY As Decimal
'    Public Property SO_THANH_VIEN_MOI_BAO_TRO_TRAI As Integer
'    Public Property SO_THANH_VIEN_MOI_BAO_TRO_PHAI As Integer
'End Class