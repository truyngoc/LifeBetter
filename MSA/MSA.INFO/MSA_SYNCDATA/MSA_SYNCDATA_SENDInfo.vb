Public Class MSA_SYNCDATA_SENDInfo
#Region "***** Fields & Properties *****"
    Private _ID As Decimal
    Public Property ID() As Decimal
        Get
            Return _ID
        End Get
        Set(value As Decimal)
            _ID = value
        End Set
    End Property
    Private _CODE_ID_TO As String
    Public Property CODE_ID_TO() As String
        Get
            Return _CODE_ID_TO
        End Get
        Set(value As String)
            _CODE_ID_TO = value
        End Set
    End Property
    Private _PIN_ACTIVED_TIME As DateTime?
    Public Property PIN_ACTIVED_TIME() As DateTime?
        Get
            Return _PIN_ACTIVED_TIME
        End Get
        Set(value As DateTime?)
            _PIN_ACTIVED_TIME = value
        End Set
    End Property
    Private _SEND_ACTIVED_TIME As DateTime?
    Public Property SEND_ACTIVED_TIME() As DateTime?
        Get
            Return _SEND_ACTIVED_TIME
        End Get
        Set(value As DateTime?)
            _SEND_ACTIVED_TIME = value
        End Set
    End Property
    Private _STATUS As Boolean
    Public Property STATUS() As Boolean
        Get
            Return _STATUS
        End Get
        Set(value As Boolean)
            _STATUS = value
        End Set
    End Property

    Private _PIN_AMOUNT As Integer
    Public Property PIN_AMOUNT() As Integer
        Get
            Return _PIN_AMOUNT
        End Get
        Set(value As Integer)
            _PIN_AMOUNT = value
        End Set
    End Property

    Private _SEND_AMOUNT As Decimal?
    Public Property SEND_AMOUNT() As Decimal?
        Get
            Return _SEND_AMOUNT
        End Get
        Set(value As Decimal?)
            _SEND_AMOUNT = value
        End Set
    End Property

    Public Property SEND_AMOUNT_CURRENT As Decimal?

    Public Property ID_MEMBER_PIN As Decimal

    Public Property GETDATE_DB As DateTime?

    Public Property CURRENT_AMOUNT As Decimal?

#End Region

#Region "***** Init Methods *****"
    Public Sub New()
    End Sub

    Public Sub New(ByVal vCODE_ID_TO As String, ByVal vPIN_ACTIVED_TIME As DateTime?, ByVal vSEND_ACTIVED_TIME As DateTime?, ByVal vSTATUS As Integer, ByVal vID_MEMBER_PIN As Decimal, ByVal vGETDATE_DB As DateTime?)
        Me.CODE_ID_TO = vCODE_ID_TO
        Me.PIN_ACTIVED_TIME = vPIN_ACTIVED_TIME
        Me.SEND_ACTIVED_TIME = vSEND_ACTIVED_TIME
        Me.STATUS = vSTATUS
        Me.ID_MEMBER_PIN = vID_MEMBER_PIN
        Me.GETDATE_DB = vGETDATE_DB
    End Sub

#End Region
End Class
