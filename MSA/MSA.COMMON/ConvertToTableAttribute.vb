Public Class ConvertToTableAttribute
    Inherits Attribute
    Private _isToTable As Boolean
    Public Property isToTable() As Boolean
        Get
            Return Me._isToTable
        End Get
        Set(ByVal value As Boolean)
            Me._isToTable = value
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
