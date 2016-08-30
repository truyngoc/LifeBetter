
Imports System.Reflection
Imports System.Web
Imports System.Text

Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class GTTLibrary


#Region "Get ParamArray for OracleHelper, SQLHelper from Object T "
#Region "Get Parameter"


    ''' <summary>
    ''' Function Build SqlParameter Từ Info Param người coding tạo ra 
    ''' với các Param Attribute tùy biến
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="o"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateParamSql(Of T)(ByVal o As T) As List(Of SqlParameter)
        Dim lstPi As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        Dim lstPiIsParam As List(Of PropertyInfo) = _
                                lstPi.Where(
                                        Function(s) s.GetCustomAttributes(GetType(ParamAttribute), False).Count <> 0
                                        ).ToList() _
                                         .OrderBy(Function(s) TryCast(s.GetCustomAttributes(GetType(ParamAttribute), False)(0), ParamAttribute).STT).ToList()

        Dim listSqlParam As New List(Of SqlParameter)()
        For i As Integer = 0 To lstPiIsParam.Count - 1
            Dim SQLParam As SqlParameter = Nothing
            Dim cusPar As ParamAttribute = lstPiIsParam(i).GetCustomAttributes(GetType(ParamAttribute), False)(0)
            If cusPar.ParamDirection = ParameterDirection.Output Then
                SQLParam = New SqlParameter("@" + lstPiIsParam(i).Name, cusPar.SqlType, IIf(lstPiIsParam(i).GetValue(o, Nothing) Is Nothing, DBNull.Value, lstPiIsParam(i).GetValue(o, Nothing)), cusPar.ParamDirection)
            Else
                SQLParam = New SqlParameter("@" + lstPiIsParam(i).Name, cusPar.SqlType, IIf(lstPiIsParam(i).GetValue(o, Nothing) Is Nothing, DBNull.Value, lstPiIsParam(i).GetValue(o, Nothing)), cusPar.ParamDirection)
            End If

            listSqlParam.Add(SQLParam)
        Next

        Return listSqlParam

    End Function

    Public Shared Function CreateParamSql(ByVal o As Object) As List(Of SqlParameter)
        Dim lstPi As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        Dim lstPiIsParam As List(Of PropertyInfo) = _
                                lstPi.Where(
                                        Function(s) s.GetCustomAttributes(GetType(ParamAttribute), False).Count <> 0
                                        ).ToList() _
                                         .OrderBy(Function(s) TryCast(s.GetCustomAttributes(GetType(ParamAttribute), False)(0), ParamAttribute).STT).ToList()

        Dim listSqlParam As New List(Of SqlParameter)()
        For i As Integer = 0 To lstPiIsParam.Count - 1
            Dim SQLParam As SqlParameter = Nothing
            Dim cusPar As ParamAttribute = lstPiIsParam(i).GetCustomAttributes(GetType(ParamAttribute), False)(0)
            If cusPar.ParamDirection = ParameterDirection.Output Then
                SQLParam = New SqlParameter("@" + lstPiIsParam(i).Name, cusPar.SqlType, IIf(lstPiIsParam(i).GetValue(o, Nothing) Is Nothing, DBNull.Value, lstPiIsParam(i).GetValue(o, Nothing)), cusPar.ParamDirection)
            Else
                SQLParam = New SqlParameter("@" + lstPiIsParam(i).Name, cusPar.SqlType, IIf(lstPiIsParam(i).GetValue(o, Nothing) Is Nothing, DBNull.Value, lstPiIsParam(i).GetValue(o, Nothing)), cusPar.ParamDirection)
            End If

            listSqlParam.Add(SQLParam)
        Next

        Return listSqlParam

    End Function

    
#End Region

#Region "Set Value Output"

    ''' <summary>
    ''' Function lấy lại giá trị Output từ SqlParameter có ParameterDirection.Output
    ''' 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="o"></param>
    ''' <param name="listP"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetValueOutputSQL(Of T)(ByRef o As T, ByVal listP As List(Of SqlParameter))
        Dim lstPi As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        Dim lstPiIsParam As List(Of PropertyInfo) = _
                                lstPi.Where(
                                        Function(s) s.GetCustomAttributes(GetType(ParamAttribute), False).Count <> 0
                                        ).ToList() _
                                         .OrderBy(Function(s) TryCast(s.GetCustomAttributes(GetType(ParamAttribute), False)(0), ParamAttribute).STT).ToList()

        For i As Integer = 0 To lstPiIsParam.Count - 1

            Dim cusPar As ParamAttribute = lstPiIsParam(i).GetCustomAttributes(GetType(ParamAttribute), False)(0)
            If cusPar.ParamDirection = ParameterDirection.Output And lstPiIsParam(i).Name = listP(i).ParameterName.Substring(1, listP(i).ParameterName.Length - 1) Then
                lstPiIsParam(i).SetValue(o, _
                                            Convert.ChangeType(listP(i).Value, If(Nullable.GetUnderlyingType(lstPiIsParam(i).PropertyType) _
                                            , lstPiIsParam(i).PropertyType)), Nothing)
            End If
        Next

    End Sub

    Public Shared Sub SetValueOutputSQL(ByRef o As Object, ByVal listP As List(Of SqlParameter))
        Dim lstPi As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        Dim lstPiIsParam As List(Of PropertyInfo) = _
                                lstPi.Where(
                                        Function(s) s.GetCustomAttributes(GetType(ParamAttribute), False).Count <> 0
                                        ).ToList() _
                                         .OrderBy(Function(s) TryCast(s.GetCustomAttributes(GetType(ParamAttribute), False)(0), ParamAttribute).STT).ToList()

        For i As Integer = 0 To lstPiIsParam.Count - 1

            Dim cusPar As ParamAttribute = lstPiIsParam(i).GetCustomAttributes(GetType(ParamAttribute), False)(0)
            If cusPar.ParamDirection = ParameterDirection.Output And lstPiIsParam(i).Name = listP(i).ParameterName.Substring(1, listP(i).ParameterName.Length - 1) Then
                lstPiIsParam(i).SetValue(o, _
                                            Convert.ChangeType(listP(i).Value, If(Nullable.GetUnderlyingType(lstPiIsParam(i).PropertyType) _
                                            , lstPiIsParam(i).PropertyType)), Nothing)
            End If
        Next

    End Sub

    

#End Region

#Region "Function"
    

    Public Shared Function MappingVBTypeToSQLDbType(ByRef per As PropertyInfo) As SqlDbType
        If per.PropertyType Is GetType(Nullable(Of Date)) Or per.PropertyType Is GetType(Date) Then
            Return SqlDbType.Date
        ElseIf per.PropertyType Is GetType(Nullable(Of DateTime)) Or per.PropertyType Is GetType(DateTime) Then
            Return SqlDbType.DateTime
        ElseIf per.PropertyType Is GetType(Nullable(Of Decimal)) Or per.PropertyType Is GetType(Decimal) Then
            Return SqlDbType.Decimal
        ElseIf per.PropertyType Is GetType(Nullable(Of Integer)) Or per.PropertyType Is GetType(Integer) Then
            Return SqlDbType.Int
        ElseIf per.PropertyType Is GetType(Nullable(Of Int32)) Or per.PropertyType Is GetType(Int32) Then
            Return SqlDbType.Int
        ElseIf per.PropertyType Is GetType(Nullable(Of Int64)) Or per.PropertyType Is GetType(Int64) Then
            Return SqlDbType.BigInt
        ElseIf per.PropertyType Is GetType(Nullable(Of Boolean)) Or per.PropertyType Is GetType(Boolean) Then
            Return SqlDbType.Bit
        ElseIf per.PropertyType Is GetType(Nullable(Of Single)) Or per.PropertyType Is GetType(Single) Then
            Return SqlDbType.Float
        ElseIf per.PropertyType Is GetType(Nullable(Of Long)) Or per.PropertyType Is GetType(Long) Then
            Return SqlDbType.Float
        ElseIf per.PropertyType Is GetType(String) Then
            Return SqlDbType.NVarChar
        Else
            Return SqlDbType.VarChar
        End If
    End Function

    Public Shared Function GetSqlDBType(theType As System.Type) As SqlDbType
        Dim param As SqlParameter
        Dim tc As System.ComponentModel.TypeConverter
        param = New SqlParameter()
        tc = System.ComponentModel.TypeDescriptor.GetConverter(param.DbType)
        If tc.CanConvertFrom(theType) Then
            param.DbType = DirectCast(tc.ConvertFrom(theType.Name), DbType)
        Else
            ' try to forcefully convert
            Try
                param.DbType = DirectCast(tc.ConvertFrom(theType.Name), DbType)
                ' ignore the exception
            Catch e As Exception
            End Try
        End If
        Return param.SqlDbType
    End Function

    
    Public Function GetTypes(o As [Object]()) As Type()
        Dim str As String = String.Empty
        Dim arrType As Type() = New Type(o.Length - 1) {}
        For i As Integer = 0 To o.Length - 1
            arrType(i) = o(i).[GetType]()
        Next
        Return arrType
    End Function

#End Region

#End Region


#Region "Enum"
    Public Enum ParameterDirect
        Input = 1
        InOutPut = 2
        OutPut = 3
        ReturnValue = 4
    End Enum

    Public Enum DataProvider
        SqlServer = 1
        OleDb = 2
        Odbc = 3
        MySql = 4
        Oracle = 5
    End Enum

    Public Enum GTTSqlType
        GTTDecimal = SqlDbType.Decimal
        GTTBigInt = SqlDbType.BigInt
        GTTBit = SqlDbType.Bit
        GTTInt = SqlDbType.Int
        GTTSmallInt = SqlDbType.SmallInt
        GTTReal = SqlDbType.Real
        GTTDate = SqlDbType.Date
        GTTDateTime = SqlDbType.DateTime
        'GTTLong = SqlDbType.Float
        GTTNVarchar = SqlDbType.NVarChar
        GTTVarchar = SqlDbType.VarChar
        GTTFloat = SqlDbType.Float
    End Enum

#End Region


End Class
