Imports MSA.INFO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Dapper
Imports MSA.COMMON

Public Class MSA_Caching_DAO
    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
    'Public Function GetConfigToCache() As MSA_CONFIGInfo
    '    Dim _config = MSACacheHelper.Get(Of MSA_CONFIGInfo)(MSA_Constants.ConstCacheKey.MSAKeyConfig)

    '    If _config Is Nothing Then
    '        _config = db.Query(Of MSA_CONFIGInfo)("sproc_CONFIG_Get", commandType:=CommandType.StoredProcedure _
    '                                                              ).SingleOrDefault()
    '        MSACacheHelper.Add(_config, MSA_Constants.ConstCacheKey.MSAKeyConfig)
    '    End If

    '    Return _config
    'End Function

    'Public Function GetConfigAmountPH() As List(Of MSA_CONFIG_AMOUNT_PHInfo)
    '    Dim _config = MSACacheHelper.Get(Of List(Of MSA_CONFIG_AMOUNT_PHInfo))(MSA_Constants.ConstCacheKey.MSAKeyConfigAmountPH)

    '    If _config Is Nothing Then
    '        _config = db.Query(Of MSA_CONFIG_AMOUNT_PHInfo)("sproc_CONFIG_AMOUNT_PH_Get", commandType:=CommandType.StoredProcedure).ToList()
    '        MSACacheHelper.Add(_config, MSA_Constants.ConstCacheKey.MSAKeyConfigAmountPH)
    '    End If

    '    Return _config
    'End Function

End Class
