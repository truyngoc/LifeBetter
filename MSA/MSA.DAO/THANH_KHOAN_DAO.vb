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
End Class