Public Class BuildWhereAttribute
    Inherits Attribute

    Private _isBuildWbere As Boolean
    Public Property isBuildWhere() As Boolean
        Get
            Return Me._isBuildWbere
        End Get
        Set(ByVal value As Boolean)
            Me._isBuildWbere = value
        End Set
    End Property
    Private _STT As Integer
    Public Property STT() As Integer
        Get
            Return Me._STT
        End Get
        Set(ByVal value As Integer)
            Me._STT = value
        End Set
    End Property
End Class
