Imports MSA.INFO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Dapper

Public Class MSA_GOI_DAU_TU_HIS_DAO
    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)

    Public Sub Insert(ByVal MA_KH As String, ByVal MA_DAU_TU As Integer, ByVal NGAY As DateTime, ByVal MOI_NHAT As Integer, ByVal MA_CAY As String, _
        ByVal THUONG_THANH_TICH As Decimal, _
        ByVal GOI_DAU_TU As String, _
        ByVal GOI_DAU_TU_HIS As String, _
        ByVal MA_DAU_TU_HIS As Integer, _
        ByVal NGUOI_CAP_NHAT As String, _
        ByVal GHI_CHU As String)

        db.Execute("sproc_GOI_DAU_TU_HIS_Insert", _
                   New With {Key .MA_KH = MA_KH, Key .MA_DAU_TU = MA_DAU_TU, Key .NGAY = NGAY, Key .MOI_NHAT = MOI_NHAT, Key .MA_CAY = MA_CAY, Key .THUONG_THANH_TICH = THUONG_THANH_TICH, _
                            Key .GOI_DAU_TU = GOI_DAU_TU, Key .GOI_DAU_TU_HIS = GOI_DAU_TU_HIS, Key .MA_DAU_TU_HIS = MA_DAU_TU_HIS, Key .NGUOI_CAP_NHAT = NGUOI_CAP_NHAT, Key .GHI_CHU = GHI_CHU}, _
                   commandType:=CommandType.StoredProcedure)
    End Sub
End Class
