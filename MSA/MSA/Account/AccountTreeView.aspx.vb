Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO
Public Class AccountTreeView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try

                Dim sMA_CAY As String
                Dim oHoaHong As HOA_HONG
                Dim daoDOANH_SO As New MSA_DOANH_SO_DAO

                ' tinh hoa hong
                sMA_CAY = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY

                'If HttpContext.Current.Session("MSA_DOANHSO_HOAHONG") IsNot Nothing Then
                '    oHoaHong = TryCast(HttpContext.Current.Session("MSA_DOANHSO_HOAHONG"), HOA_HONG)
                'Else
                '    oHoaHong = Tinh_Hoa_Hong(sMA_CAY)
                '    HttpContext.Current.Session("MSA_DOANHSO_HOAHONG") = oHoaHong
                'End If
                txtMA_CAY.Text = sMA_CAY
                oHoaHong = daoDOANH_SO.Tinh_Hoa_Hong(sMA_CAY, _
                                                     Singleton(Of MSACurrentSession).Inst.SessionMember.MA_KH, _
                                                     DateTime.Today.Month, DateTime.Today.Year)

                ' gan len form
                Load_DaTa_To_Form(oHoaHong)



            Catch ex As Exception

            End Try
        End If
    End Sub


    <WebMethod> _
    Public Shared Function GetChartData(ma_cay As String) As List(Of Object)
        '
        ' ko nhap ma_cay vao textbox thi mac dinh la root
        'If String.IsNullOrEmpty(ma_cay) Then
        '    ma_cay = "0"
        'End If
        ' bo luon luon hien thi root cua ma_cay dang tim kiem
        'Đổi tên thành mã


        Dim ma_cay_tt As Object
        If String.IsNullOrEmpty(ma_cay) Then
            Return Nothing
        End If
        Dim query As String = get_Chart_Data(ma_cay)

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand(query)
                Dim chartData As New List(Of Object)()
                cmd.CommandType = CommandType.Text
                cmd.Connection = con

                Try
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        While sdr.Read()
                            If sdr("MA_CAY").ToString() = ma_cay Then
                                ma_cay_tt = Nothing
                            Else
                                ma_cay_tt = sdr("MA_CAY_TT")
                            End If

                            chartData.Add(New Object() {sdr("ID"), sdr("MA_KH"), sdr("MA_CAY"), sdr("MA_BAO_TRO"), sdr("TEN"), sdr("MA_BAO_TRO_TT"), _
                                ma_cay_tt, sdr("NHANH_CAY_TT"), sdr("NGAY_THAM_GIA"), sdr("TRANG_THAI"), sdr("MA_GOI_DAU_TU"), sdr("MA_DANH_HIEU")})
                        End While
                    End Using
                    con.Close()

                Catch ex As Exception

                End Try

                Return chartData
            End Using
        End Using
    End Function

    Public Shared Function get_Chart_Data(ma_cay As String) As String
        If ma_cay = "" Then
            ma_cay = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY
        End If
        Dim query As String = "select * from ("
        If ma_cay = "0" Then
            query += "SELECT ID"
            query += ", MA_KH"
            query += ", MA_CAY"
            query += ", MA_BAO_TRO"
            query += ", TEN"
            query += ", MA_BAO_TRO_TT"
            query += ", MA_CAY_TT"
            query += ", NHANH_CAY_TT"
            query += ", NGAY_THAM_GIA"
            query += ", TRANG_THAI"
            query += ", MA_GOI_DAU_TU"
            query += ", MA_DANH_HIEU"
            query += " FROM MEMBERS"
            query += " WHERE ((MA_CAY ='" & ma_cay + "')) "
            query += " UNION "
        End If

        query += "SELECT ID"
        query += ", MA_KH"
        query += ", MA_CAY"
        query += ", MA_BAO_TRO"
        query += ", TEN"
        query += ", MA_BAO_TRO_TT"
        query += ", MA_CAY_TT"
        query += ", NHANH_CAY_TT"
        query += ", NGAY_THAM_GIA"
        query += ", TRANG_THAI"
        query += ", MA_GOI_DAU_TU"
        query += ", MA_DANH_HIEU"
        query += " FROM MEMBERS"
        query += " WHERE ((MA_CAY ='" & ma_cay + "') OR (MA_CAY_TT like '" & ma_cay + "%'))"
        query += " AND TRANG_THAI <> 0 and NV=0 and MA_BAO_TRO_TT is not null and MA_BAO_TRO_TT <> ''"

        query += " UNION "

        query += "select null ID "
        query += ",null MA_KH"
        query += ",case NHANH_CAY_TT when 1 then MA_CAY_TT + '02' else MA_CAY_TT + '01' end MA_CAY"
        query += ",null MA_BAO_TRO"
        query += ",N'Trống' TEN"
        query += ",null MA_BAO_TRO_TT"
        query += ",MA_CAY_TT"
        query += ",case NHANH_CAY_TT when 1 then 2 else 1 end NHANH_CAY_TT"
        query += ",null NGAY_THAM_GIA"
        query += ",null TRANG_THAI"
        query += ",0 MA_GOI_DAU_TU"
        query += ",null MA_DANH_HIEU "
        query += "from members "
        query += "where "
        query += "(ma_cay='" & ma_cay + "' or ma_cay_tt like '" & ma_cay + "%') "
        query += "and ma_cay_tt in ("
        query += "select a.ma_cay_tt "
        query += "from "
        query += "("
        query += "select count(*) col_no, ma_cay_tt "
        query += "from MEMBERS "
        query += "where ma_cay_tt like '" & ma_cay + "%'"
        query += "group by ma_cay_tt "
        query += "having count(*) < 2"
        query += ") a"
        query += ")"
        query += ") k"
        query += " ORDER BY NHANH_CAY_TT"

        Return query
    End Function




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
    '                    oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_TRAI")
    '                    oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_PHAI")
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

    Public Sub Load_DaTa_To_Form(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            lblDOANH_SO_CA_NHAN_THANG.Text = IIf(o.DOANH_SO_CA_NHAN = 0, 0, o.DOANH_SO_CA_NHAN.ToString("#,###"))
            lblDOANH_SO_CA_NHAN_TICH_LUY.Text = IIf(o.DOANH_SO_TICH_LUY = 0, 0, o.DOANH_SO_TICH_LUY.ToString("#,###"))
            lblDOANH_SO_TRAI.Text = IIf(o.DOANH_SO_TRAI = 0, 0, o.DOANH_SO_TRAI.ToString("#,###"))
            lblDOANH_SO_PHAI.Text = IIf(o.DOANH_SO_PHAI = 0, 0, o.DOANH_SO_PHAI.ToString("#,###"))
            lblDOANH_SO_KET_CHUYEN_TRAI.Text = IIf(o.DOANH_SO_KET_CHUYEN_TRAI = 0, 0, o.DOANH_SO_KET_CHUYEN_TRAI.ToString("#,###"))
            lblDOANH_SO_KET_CHUYEN_PHAI.Text = IIf(o.DOANH_SO_KET_CHUYEN_PHAI = 0, 0, o.DOANH_SO_KET_CHUYEN_PHAI.ToString("#,###"))
            lblDOANH_SO_TICH_LUY_TRAI.Text = IIf(o.DOANH_SO_TICH_LUY_TRAI = 0, 0, o.DOANH_SO_TICH_LUY_TRAI.ToString("#,###"))
            lblDOANH_SO_TICH_LUY_PHAI.Text = IIf(o.DOANH_SO_TICH_LUY_PHAI = 0, 0, o.DOANH_SO_TICH_LUY_PHAI.ToString("#,###"))
            lblTONG_SO_THANH_VIEN_TRAI.Text = IIf(o.TONG_SO_THANH_VIEN_TRAI = 0, 0, o.TONG_SO_THANH_VIEN_TRAI.ToString("#,###"))
            lblTONG_SO_THANH_VIEN_PHAI.Text = IIf(o.TONG_SO_THANH_VIEN_PHAI = 0, 0, o.TONG_SO_THANH_VIEN_PHAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_TRAI.Text = IIf(o.SO_THANH_VIEN_MOI_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_TRAI.ToString("#,###"))
            lblSO_THANH_VIEN_MOI_PHAI.Text = IIf(o.SO_THANH_VIEN_MOI_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_PHAI.ToString("#,###"))
            'lblSO_THANH_VIEN_MOI_BAO_TRO_TRAI.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI.ToString("#,###"))
            'lblSO_THANH_VIEN_MOI_BAO_TRO_PHAI.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI.ToString("#,###"))
        End If
    End Sub

    Protected Sub SearchTree_Click(sender As Object, e As EventArgs)
        If txtMa_KH.Text.Trim.Equals("") Then
            txtMA_CAY.Text = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY
        Else
            Dim obj As MSA_MemberInfo = Singleton(Of MSA_MemberDAO).Inst.SEARCH_BY_MA_KH_DOWNLINE(txtMa_KH.Text, Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY)
            If obj Is Nothing Then
                txtMA_CAY.Text = Singleton(Of MSACurrentSession).Inst.SessionMember.MA_CAY
                txtMa_KH.Text = ""
            Else
                txtMA_CAY.Text = obj.MA_CAY
                txtMa_KH.Text = ""
            End If
        End If
    End Sub
End Class
