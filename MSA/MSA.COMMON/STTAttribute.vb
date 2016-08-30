Public Class STTAttribute
    Inherits Attribute

    Private _Value As Integer
    Public Property Value() As Integer
        Get
            Return Me._Value
        End Get
        Set(ByVal value As Integer)
            Me._Value = value
        End Set
    End Property
End Class
