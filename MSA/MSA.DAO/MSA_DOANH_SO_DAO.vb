﻿Imports MSA.INFO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Dapper
Public Class MSA_DOANH_SO_DAO
    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)

    Public Function Tinh_Hoa_Hong(ByVal MA_CAY As String, ByVal MA_KH As String, ByVal THANG As Integer, ByVal NAM As Integer) As HOA_HONG
        Dim oHoaHong = New HOA_HONG

        Dim param = New SqlParameter("@_ma_cay", SqlDbType.NVarChar, 250)
        param.Value = MA_CAY

        Dim param_MA_KH = New SqlParameter("@_ma_kh", SqlDbType.NVarChar, 250)
        param_MA_KH.Value = MA_KH

        Dim param_THANG = New SqlParameter("@_month", SqlDbType.Int)
        param_THANG.Value = THANG

        Dim param_NAM = New SqlParameter("@_year", SqlDbType.Int)
        param_NAM.Value = NAM


        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_TINH_DOANH_SO_HOA_HONG")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param_MA_KH)
                cmd.Parameters.Add(param_THANG)
                cmd.Parameters.Add(param_NAM)
                cmd.Connection = con
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        oHoaHong.TONG_SO_THANH_VIEN_TRAI = dr("TONG_SO_THANH_VIEN_TRAI")
                        oHoaHong.TONG_SO_THANH_VIEN_PHAI = dr("TONG_SO_THANH_VIEN_PHAI")
                        oHoaHong.SO_THANH_VIEN_MOI_TRAI = dr("SO_THANH_VIEN_MOI_TRAI")
                        oHoaHong.SO_THANH_VIEN_MOI_PHAI = dr("SO_THANH_VIEN_MOI_PHAI")
                        oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_TRAI")
                        oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_PHAI")
                        oHoaHong.DOANH_SO_TRAI = dr("DOANH_SO_TRAI")
                        oHoaHong.DOANH_SO_PHAI = dr("DOANH_SO_PHAI")
                        oHoaHong.DOANH_SO_TICH_LUY_TRAI = dr("DOANH_SO_TICH_LUY_TRAI")
                        oHoaHong.DOANH_SO_TICH_LUY_PHAI = dr("DOANH_SO_TICH_LUY_PHAI")
                        oHoaHong.DOANH_SO_KET_CHUYEN_TRAI = dr("DOANH_SO_KET_CHUYEN_TRAI")
                        oHoaHong.DOANH_SO_KET_CHUYEN_PHAI = dr("DOANH_SO_KET_CHUYEN_PHAI")
                        oHoaHong.DOANH_SO_CA_NHAN = dr("DOANH_SO_CA_NHAN")
                        oHoaHong.DOANH_SO_TICH_LUY = dr("DOANH_SO_TICH_LUY")
                        oHoaHong.HOA_HONG_TRUC_TIEP = dr("HOA_HONG_TRUC_TIEP")
                        oHoaHong.HOA_HONG_GIAN_TIEP = dr("HOA_HONG_GIAN_TIEP")
                        oHoaHong.HOA_HONG_CO_BAN = dr("HOA_HONG_CO_BAN")
                        oHoaHong.HOA_HONG_CO_BAN_DUOC_TINH = dr("HOA_HONG_CO_BAN_DUOC_TINH")
                        oHoaHong.TONG_THU_NHAP_THANG = dr("TONG_THU_NHAP_THANG")
                        oHoaHong.TONG_THU_NHAP_CAC_KY = dr("TONG_THU_NHAP_CAC_KY")
                        oHoaHong.QUY_TIEN_MAT = dr("QUY_TIEN_MAT")
                        oHoaHong.QUY_PHONG_CACH = dr("QUY_PHONG_CACH")
                        oHoaHong.QUY_DAO_TAO = dr("QUY_DAO_TAO")

                        oHoaHong.THUONG_THANH_TICH = dr("THUONG_THANH_TICH")
                        oHoaHong.THUONG_THANH_TICH_DUOC_TINH = dr("THUONG_THANH_TICH_DUOC_TINH")

                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return oHoaHong
    End Function

#Region "Tinh lai hoa hong"
    Public Function Tinh_Hoa_Hong_Recalculate(ByVal MA_CAY As String, ByVal MA_KH As String, ByVal THANG As Integer, ByVal NAM As Integer) As HOA_HONG
        Dim oHoaHong = New HOA_HONG

        Dim param = New SqlParameter("@_ma_cay", SqlDbType.NVarChar, 250)
        param.Value = MA_CAY

        Dim param_MA_KH = New SqlParameter("@_ma_kh", SqlDbType.NVarChar, 250)
        param_MA_KH.Value = MA_KH

        Dim param_THANG = New SqlParameter("@_month", SqlDbType.Int)
        param_THANG.Value = THANG

        Dim param_NAM = New SqlParameter("@_year", SqlDbType.Int)
        param_NAM.Value = NAM


        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_TINH_DOANH_SO_HOA_HONG_RECALCULATE")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param_MA_KH)
                cmd.Parameters.Add(param_THANG)
                cmd.Parameters.Add(param_NAM)
                cmd.Connection = con
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        oHoaHong.TONG_SO_THANH_VIEN_TRAI = dr("TONG_SO_THANH_VIEN_TRAI")
                        oHoaHong.TONG_SO_THANH_VIEN_PHAI = dr("TONG_SO_THANH_VIEN_PHAI")
                        oHoaHong.SO_THANH_VIEN_MOI_TRAI = dr("SO_THANH_VIEN_MOI_TRAI")
                        oHoaHong.SO_THANH_VIEN_MOI_PHAI = dr("SO_THANH_VIEN_MOI_PHAI")
                        oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_TRAI")
                        oHoaHong.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = dr("SO_THANH_VIEN_MOI_BAO_TRO_PHAI")
                        oHoaHong.DOANH_SO_TRAI = dr("DOANH_SO_TRAI")
                        oHoaHong.DOANH_SO_PHAI = dr("DOANH_SO_PHAI")
                        oHoaHong.DOANH_SO_TICH_LUY_TRAI = dr("DOANH_SO_TICH_LUY_TRAI")
                        oHoaHong.DOANH_SO_TICH_LUY_PHAI = dr("DOANH_SO_TICH_LUY_PHAI")
                        oHoaHong.DOANH_SO_KET_CHUYEN_TRAI = dr("DOANH_SO_KET_CHUYEN_TRAI")
                        oHoaHong.DOANH_SO_KET_CHUYEN_PHAI = dr("DOANH_SO_KET_CHUYEN_PHAI")
                        oHoaHong.DOANH_SO_CA_NHAN = dr("DOANH_SO_CA_NHAN")
                        oHoaHong.DOANH_SO_TICH_LUY = dr("DOANH_SO_TICH_LUY")
                        oHoaHong.HOA_HONG_TRUC_TIEP = dr("HOA_HONG_TRUC_TIEP")
                        oHoaHong.HOA_HONG_GIAN_TIEP = dr("HOA_HONG_GIAN_TIEP")
                        oHoaHong.HOA_HONG_CO_BAN = dr("HOA_HONG_CO_BAN")
                        oHoaHong.HOA_HONG_CO_BAN_DUOC_TINH = dr("HOA_HONG_CO_BAN_DUOC_TINH")
                        oHoaHong.TONG_THU_NHAP_THANG = dr("TONG_THU_NHAP_THANG")
                        oHoaHong.TONG_THU_NHAP_CAC_KY = dr("TONG_THU_NHAP_CAC_KY")
                        oHoaHong.QUY_TIEN_MAT = dr("QUY_TIEN_MAT")
                        oHoaHong.QUY_PHONG_CACH = dr("QUY_PHONG_CACH")
                        oHoaHong.QUY_DAO_TAO = dr("QUY_DAO_TAO")

                        oHoaHong.THUONG_THANH_TICH = dr("THUONG_THANH_TICH")
                        oHoaHong.THUONG_THANH_TICH_DUOC_TINH = dr("THUONG_THANH_TICH_DUOC_TINH")

                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return oHoaHong
    End Function
#End Region

    Public Function ThongKeHeThong(ByVal thangnam As String) As THONG_KE_HE_THONG
        Dim tk = New THONG_KE_HE_THONG

        Dim param = New SqlParameter("@thangnam", SqlDbType.VarChar, 50)
        param.Value = thangnam

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_ThongKeTongHop")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)

                cmd.Connection = con
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        tk.TONG_SO_THANH_VIEN = dr("TONG_SO_THANH_VIEN")
                        tk.TONG_DOANH_SO = dr("TONG_DOANH_SO")
                        tk.TONG_HOA_HONG_TRUC_TIEP = dr("TONG_HOA_HONG_TRUC_TIEP")
                        tk.TONG_HOA_HONG_GIAN_TIEP = dr("TONG_HOA_HONG_GIAN_TIEP")
                        tk.TONG_HOA_HONG_CO_BAN_DUOC_TINH = dr("TONG_HOA_HONG_CO_BAN_DUOC_TINH")
                        tk.TONG_QUY_TIEN_MAT = dr("TONG_QUY_TIEN_MAT")
                        tk.TONG_QUY_PHONG_CACH = dr("TONG_QUY_PHONG_CACH")
                        tk.TONG_QUY_DAO_TAO = dr("TONG_QUY_DAO_TAO")
                        tk.TONG_HOA_HONG = dr("TONG_HOA_HONG")
                        tk.TONG_THUONG_THANH_TICH = dr("TONG_THUONG_THANH_TICH")
                        tk.TONG_THUONG_THANH_TICH_DUOC_TINH = dr("TONG_THUONG_THANH_TICH_DUOC_TINH")
                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return tk
    End Function



    Public Function get_All() As List(Of HOA_HONG)

        Return db.Query(Of HOA_HONG)("sp_DOANH_SO_get_All", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function


    Public Function get_by_ID(ID As Integer) As HOA_HONG

        Return DirectCast(db.Query(Of HOA_HONG)("sp_DOANH_SO_get_By_ID", New With {Key .ID = ID}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), HOA_HONG)
    End Function
    Public Function get_Item(MA_KH As String, ByVal Thang As Integer, ByVal Nam As Integer) As HOA_HONG

        Return DirectCast(db.Query(Of HOA_HONG)("sp_DOANH_SO_get_Item", New With {Key .MA_KH = MA_KH, Key .Thang = Thang, Key .Nam = Nam}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), HOA_HONG)
    End Function
    Public Function get_by_MA_KH(MA_KH As String) As List(Of HOA_HONG)

        Return db.Query(Of HOA_HONG)("sp_DOANH_SO_get_By_MA_KH", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function get_by_Thang(ByVal THANG As Integer, ByVal NAM As Integer) As List(Of HOA_HONG)

        Return db.Query(Of HOA_HONG)("sp_DOANH_SO_get_By_THANG", New With {Key .THANG = THANG, Key .NAM = NAM}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function get_by_Thang_ddl(ByVal thangnam As String) As List(Of HOA_HONG)

        Return db.Query(Of HOA_HONG)("sp_DOANH_SO_get_By_THANG_dll", New With {Key .thangnam = thangnam}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function get_All_Thang_Doanh_so() As List(Of THANG_DOANH_SO)

        Return db.Query(Of THANG_DOANH_SO)("sp_Select_AllMonth_Doanh_So", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function get_All_Thang_Chot_Lai_Doanh_so() As List(Of THANG_DOANH_SO)

        Return db.Query(Of THANG_DOANH_SO)("sp_Select_AllMonth_Chot_Lai_Doanh_So", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Sub Insert(ByVal _info As HOA_HONG)

        db.Execute("sp_DOANH_SO_Insert", New With {Key .MA_KH = _info.MA_KH,
                                                    Key .MA_DAU_TU = _info.MA_DAU_TU,
                                                    Key .THANG = _info.THANG,
                                                    Key .NAM = _info.NAM,
                                                    Key .DOANH_SO_TRAI = _info.DOANH_SO_TRAI,
                                                    Key .DOANH_SO_PHAI = _info.DOANH_SO_PHAI,
                                                    Key .DOANH_SO_KET_CHUYEN_TRAI = _info.DOANH_SO_KET_CHUYEN_TRAI,
                                                    Key .DOANH_SO_KET_CHUYEN_PHAI = _info.DOANH_SO_KET_CHUYEN_PHAI,
                                                    Key .DOANH_SO_TICH_LUY_TRAI = _info.DOANH_SO_TICH_LUY_TRAI,
                                                    Key .DOANH_SO_TICH_LUY_PHAI = _info.DOANH_SO_TICH_LUY_PHAI,
                                                    Key .SO_THANH_VIEN_MOI_TRAI = _info.SO_THANH_VIEN_MOI_TRAI,
                                                    Key .SO_THANH_VIEN_MOI_PHAI = _info.SO_THANH_VIEN_MOI_PHAI,
                                                    Key .HOA_HONG_TRUC_TIEP = _info.HOA_HONG_TRUC_TIEP,
                                                    Key .HOA_HONG_GIAN_TIEP = _info.HOA_HONG_GIAN_TIEP,
                                                    Key .HOA_HONG_CO_BAN = _info.HOA_HONG_CO_BAN,
                                                    Key .QUY_TIEN_MAT = _info.QUY_TIEN_MAT,
                                                    Key .QUY_PHONG_CACH = _info.QUY_PHONG_CACH,
                                                    Key .QUY_DAO_TAO = _info.QUY_DAO_TAO,
                                                    Key .HOA_HONG_CO_BAN_DUOC_TINH = _info.HOA_HONG_CO_BAN_DUOC_TINH,
                                                    Key .SO_THANH_VIEN_MOI_BAO_TRO_TRAI = _info.SO_THANH_VIEN_MOI_BAO_TRO_TRAI,
                                                    Key .SO_THANH_VIEN_MOI_BAO_TRO_PHAI = _info.SO_THANH_VIEN_MOI_BAO_TRO_PHAI,
                                                    Key .THUONG_THANH_TICH = _info.THUONG_THANH_TICH,
                                                    Key .THUONG_THANH_TICH_DUOC_TINH = _info.THUONG_THANH_TICH_DUOC_TINH
                                                     }, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub Insert_Recalculate(ByVal _info As HOA_HONG)

        db.Execute("sp_DOANH_SO_Insert_Recalculate", New With {Key .MA_KH = _info.MA_KH,
                                                    Key .MA_DAU_TU = _info.MA_DAU_TU,
                                                    Key .THANG = _info.THANG,
                                                    Key .NAM = _info.NAM,
                                                    Key .DOANH_SO_TRAI = _info.DOANH_SO_TRAI,
                                                    Key .DOANH_SO_PHAI = _info.DOANH_SO_PHAI,
                                                    Key .DOANH_SO_KET_CHUYEN_TRAI = _info.DOANH_SO_KET_CHUYEN_TRAI,
                                                    Key .DOANH_SO_KET_CHUYEN_PHAI = _info.DOANH_SO_KET_CHUYEN_PHAI,
                                                    Key .DOANH_SO_TICH_LUY_TRAI = _info.DOANH_SO_TICH_LUY_TRAI,
                                                    Key .DOANH_SO_TICH_LUY_PHAI = _info.DOANH_SO_TICH_LUY_PHAI,
                                                    Key .SO_THANH_VIEN_MOI_TRAI = _info.SO_THANH_VIEN_MOI_TRAI,
                                                    Key .SO_THANH_VIEN_MOI_PHAI = _info.SO_THANH_VIEN_MOI_PHAI,
                                                    Key .HOA_HONG_TRUC_TIEP = _info.HOA_HONG_TRUC_TIEP,
                                                    Key .HOA_HONG_GIAN_TIEP = _info.HOA_HONG_GIAN_TIEP,
                                                    Key .HOA_HONG_CO_BAN = _info.HOA_HONG_CO_BAN,
                                                    Key .QUY_TIEN_MAT = _info.QUY_TIEN_MAT,
                                                    Key .QUY_PHONG_CACH = _info.QUY_PHONG_CACH,
                                                    Key .QUY_DAO_TAO = _info.QUY_DAO_TAO,
                                                    Key .HOA_HONG_CO_BAN_DUOC_TINH = _info.HOA_HONG_CO_BAN_DUOC_TINH,
                                                    Key .SO_THANH_VIEN_MOI_BAO_TRO_TRAI = _info.SO_THANH_VIEN_MOI_BAO_TRO_TRAI,
                                                    Key .SO_THANH_VIEN_MOI_BAO_TRO_PHAI = _info.SO_THANH_VIEN_MOI_BAO_TRO_PHAI,
                                                    Key .THUONG_THANH_TICH = _info.THUONG_THANH_TICH,
                                                    Key .THUONG_THANH_TICH_DUOC_TINH = _info.THUONG_THANH_TICH_DUOC_TINH
                                                     }, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Function Check_Exist(ByVal thang As Integer, ByVal nam As Integer) As Boolean
        Dim ret As Object
        ret = db.ExecuteScalar("sp_DOANH_SO_check_Exist", New With {Key .THANG = thang, Key .NAM = nam}, commandType:=CommandType.StoredProcedure)

        If (ret = 0) Then
            Return False
        Else
            Return True
        End If
    End Function


    ' 06/10/2016
    Public Function report(ByVal thangnam As String, ByVal textSearch As String, ByVal type As Integer) As List(Of HOA_HONG)

        Return db.Query(Of HOA_HONG)("sp_DOANH_SO_report", New With {Key .thangnam = thangnam, Key .textSearch = textSearch, Key .type = type}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function report_commision(ByVal thangnam As String, ByVal textSearch As String, ByVal type As Integer) As DataSet

        Dim ds As New DataSet

        Dim param = New SqlParameter("@thangnam", SqlDbType.VarChar, 50)
        param.Value = thangnam

        Dim param1 = New SqlParameter("@textSearch", SqlDbType.NVarChar, 255)
        param1.Value = textSearch

        Dim param2 = New SqlParameter("@type", SqlDbType.Int)
        param2.Value = type

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_DOANH_SO_report_commision")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param1)
                cmd.Parameters.Add(param2)

                cmd.Connection = con

                Dim da As New SqlDataAdapter(cmd)


                da.Fill(ds)

            End Using
        End Using

        Return ds
    End Function



    'business report
    Public Function business_report_DANH_HIEU(ByVal thangnam As String, ByVal goidautu As Integer) As DataSet

        Dim ds As New DataSet

        Dim param = New SqlParameter("@GOI_DAU_TU", SqlDbType.Int, 50)
        param.Value = goidautu

        Dim param1 = New SqlParameter("@ThangNam", SqlDbType.VarChar, 255)
        param1.Value = thangnam

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_BAO_CAO_KINH_DOANH_danh_hieu")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param1)

                cmd.Connection = con

                Dim da As New SqlDataAdapter(cmd)


                da.Fill(ds)

            End Using
        End Using

        Return ds
    End Function

    Public Function business_report_DOANH_SO(ByVal textSearch As String, ByVal thangnam As String) As DataSet

        Dim ds As New DataSet

        Dim param = New SqlParameter("@SearchText", SqlDbType.NVarChar, 2000)
        param.Value = textSearch

        Dim param1 = New SqlParameter("@ThangNam", SqlDbType.VarChar, 50)
        param1.Value = thangnam

        
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_BAO_CAO_KINH_DOANH_doanh_so")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param1)

                cmd.Connection = con

                Dim da As New SqlDataAdapter(cmd)


                da.Fill(ds)

            End Using
        End Using

        Return ds
    End Function

    Public Function business_report_NGAY_THAM_GIA(ByVal tu_ngay As String, ByVal den_ngay As String) As DataSet

        Dim ds As New DataSet

        Dim param = New SqlParameter("@TU_NGAY", SqlDbType.Date)
        If String.IsNullOrEmpty(tu_ngay) Then
            param.Value = DBNull.Value
        Else
            param.Value = Convert.ToDateTime(tu_ngay)
        End If


        Dim param1 = New SqlParameter("@DEN_NGAY", SqlDbType.Date)
        If String.IsNullOrEmpty(den_ngay) Then
            param1.Value = DBNull.Value
        Else
            param1.Value = Convert.ToDateTime(den_ngay)
        End If

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_BAO_CAO_KINH_DOANH_ngay_tham_gia")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)
                cmd.Parameters.Add(param1)

                cmd.Connection = con

                Dim da As New SqlDataAdapter(cmd)


                da.Fill(ds)

            End Using
        End Using

        Return ds
    End Function

    Public Function business_report_MA_THANH_VIEN(ByVal ma_kh As String) As DataSet

        Dim ds As New DataSet

        Dim param = New SqlParameter("@MA_KH", SqlDbType.NVarChar, 250)
        param.Value = ma_kh


        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand("sp_BAO_CAO_KINH_DOANH_ma_thanh_vien")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(param)

                cmd.Connection = con

                Dim da As New SqlDataAdapter(cmd)


                da.Fill(ds)

            End Using
        End Using

        Return ds
    End Function
End Class
