Imports MSA.INFO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Dapper

Public Class THANH_KHOAN_DAO
    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
    Function Insert(mInfo As THANH_KHOAN_Info) As String
        Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("THANH_KHOAN", mInfo)
        dictsqlParam.Remove("ID")
        Dim parameter = New DynamicParameters()
        parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)
        db.Execute("sproc_THANH_KHOAN_Add", parameter, commandType:=CommandType.StoredProcedure)
        Return ""
    End Function

    Function Insert_Recalculate(_info As THANH_KHOAN_Info, ByVal Thang As Integer, ByVal Nam As Integer) As String
        db.Execute("sproc_THANH_KHOAN_Add_Recalculate", New With {Key .MA_CAY = _info.MA_CAY,
                                                        Key .MA_KH = _info.MA_KH,
                                                        Key .MA_DAU_TU = _info.MA_DAU_TU,
                                                        Key .NGAY_RUT = _info.NGAY_RUT,
                                                        Key .TEN_KH = _info.TEN_KH,
                                                        Key .QUY_TIEN_MAT = _info.QUY_TIEN_MAT,
                                                        Key .QUY_PHONG_CACH = _info.QUY_PHONG_CACH,
                                                        Key .QUY_DAO_TAO = _info.QUY_DAO_TAO,
                                                        Key .QUY_TIEN_MAT_TK = _info.QUY_TIEN_MAT_TK,
                                                        Key .QUY_PHONG_CACH_TK = _info.QUY_PHONG_CACH_TK,
                                                        Key .QUY_DAO_TAO_TK = _info.QUY_DAO_TAO_TK,
                                                        Key .isTK_QUY_TIEN_MAT = _info.isTK_QUY_TIEN_MAT,
                                                        Key .isTK_QUY_PHONG_CACH = _info.isTK_QUY_PHONG_CACH,
                                                        Key .isTK_QUY_DAO_TAO = _info.isTK_QUY_DAO_TAO,
                                                        Key .Thang = Thang,
                                                        Key .Nam = Nam
                                                     }, commandType:=CommandType.StoredProcedure)
    End Function


    Public Function SEARCH_ALL() As List(Of THANH_KHOAN_Info)

        Return db.Query(Of THANH_KHOAN_Info)("sproc_THANH_KHOAN_Get", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_KH(ByVal MA_KH As String) As List(Of THANH_KHOAN_Info)

        Return db.Query(Of THANH_KHOAN_Info)("sproc_THANH_KHOAN_GetByMA_KH", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_CAY(ByVal MA_CAY As String) As List(Of THANH_KHOAN_Info)

        Return db.Query(Of THANH_KHOAN_Info)("sproc_THANH_KHOAN_GetByMA_CAY", New With {Key .MA_CAY = MA_CAY}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_TK_PHONG_CACH(ByVal MA_KH As String) As List(Of THANH_KHOAN_Info)

        Return db.Query(Of THANH_KHOAN_Info)("sproc_THANH_KHOAN_GetByTK_PHONG_CACH", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function
    Public Function Get_So_Thang_TK_PHONG_CACH_SONG(ByVal MA_KH As String) As Integer
        Return SEARCH_BY_MA_TK_PHONG_CACH(MA_KH).Count
    End Function


    'tbn
    Public Function SEARCH_BY_MA_TK_PHONG_CACH_CHOT_LAI_HH(ByVal MA_KH As String, ByVal Thang As Integer, ByVal Nam As Integer) As List(Of THANH_KHOAN_Info)

        Return db.Query(Of THANH_KHOAN_Info)("sproc_THANH_KHOAN_GetByTK_PHONG_CACH_CHOT_LAI_HH", New With {Key .MA_KH = MA_KH, Key .Thang = Thang, Key .Nam = Nam}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function Get_So_Thang_TK_PHONG_CACH_SONG_CHOT_LAI_HH(ByVal MA_KH As String, ByVal Thang As Integer, ByVal Nam As Integer) As Integer
        Return SEARCH_BY_MA_TK_PHONG_CACH_CHOT_LAI_HH(MA_KH, Thang, Nam).Count
    End Function
End Class