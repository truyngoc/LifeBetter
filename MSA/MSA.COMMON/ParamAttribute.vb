Imports MSA.COMMON.GTTLibrary

Public Class ParamAttribute
    Inherits Attribute

    Private _STT As Integer
    Private _ParamDirection As ParameterDirection
    Private _SqlType As GTTSqlType
    Private _InOut As ParameterDirect

    ''' <summary>
    ''' Thuộc tính xác định thứ tự của các Parameter truyền vào
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property STT() As Integer
        Get
            Return Me._STT
        End Get
        Set(ByVal value As Integer)
            _STT = value
        End Set
    End Property

    ''' <summary>
    ''' Thuộc tính xác định xem Parameter là In,Out,InOut hay ReturnValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InOut() As ParameterDirect
        Get
            Return Me._InOut
        End Get
        Set(ByVal value As ParameterDirect)
            Me._InOut = value
        End Set
    End Property

    ''' <summary>
    ''' Thuộc tính ParameterDirection của .NET framework
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParamDirection() As ParameterDirection
        Get

            Select Case Me._InOut
                Case ParameterDirect.Input
                    Return ParameterDirection.Input
                Case ParameterDirect.InOutPut
                    Return ParameterDirection.InputOutput
                Case ParameterDirect.OutPut
                    Return ParameterDirection.Output
                Case ParameterDirect.ReturnValue
                    Return ParameterDirection.ReturnValue
                Case Else
                    Return Me._ParamDirection
            End Select

        End Get
        Set(ByVal value As ParameterDirection)
            Me._ParamDirection = value
        End Set
    End Property


    ''' <summary>
    ''' Thuộc tính xác định Kiểu dữ liệu của SqlDbType trong .NET Freamwork
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SqlType() As GTTSqlType
        Get
            Return Me._SqlType
        End Get
        Set(ByVal value As GTTSqlType)
            Me._SqlType = value
        End Set
    End Property



End Class
