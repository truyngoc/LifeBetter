Public Class ToExcelAttribute
    Inherits Attribute
    Private _isToExcel As Boolean
    Public Property isToExcel() As Boolean
        Get
            Return Me._isToExcel
        End Get
        Set(ByVal value As Boolean)
            Me._isToExcel = value
        End Set
    End Property
    Private _STT As Integer
    Public Property STT() As Integer
        Get
            Return Me._STT
        End Get
        Set(ByVal value As Integer)
            _STT = value
        End Set
    End Property
End Class
