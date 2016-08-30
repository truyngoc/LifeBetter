Public Class MSA_SYNCDATA_RECEIVEInfo
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
    Private _CODE_ID_FROM As String
    Public Property CODE_ID_FROM() As String
        Get
            Return _CODE_ID_FROM
        End Get
        Set(value As String)
            _CODE_ID_FROM = value
        End Set
    End Property
    Private _SEND_ACTIVED_TIME As DateTime
    Public Property SEND_ACTIVED_TIME() As DateTime
        Get
            Return _SEND_ACTIVED_TIME
        End Get
        Set(value As DateTime)
            _SEND_ACTIVED_TIME = value
        End Set
    End Property
    Private _STATUS As Int64
    Public Property STATUS() As Int64
        Get
            Return _STATUS
        End Get
        Set(value As Int64)
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

    Private _RECEIVE_AMOUNT As Decimal
    Public Property RECEIVE_AMOUNT() As Decimal
        Get
            Return _RECEIVE_AMOUNT
        End Get
        Set(value As Decimal)
            _RECEIVE_AMOUNT = value
        End Set
    End Property

    Public Property RECEIVE_AMOUNT_CURRENT As Decimal

    Public Property CURRENT_AMOUNT As Decimal

    Public Property GETDATE_DB As DateTime?

    Public Property ID_COMMITION As Integer?
    Public Property ID_RECEIVE As Integer?

#End Region

#Region "***** Init Methods *****"
    Public Sub New()
    End Sub
    Public Sub New(id As Decimal)
        Me.ID = id
    End Sub
    Public Sub New(id As Decimal, code_id_from As String, send_actived_time As DateTime, status As Int64)
        Me.ID = id
        Me.CODE_ID_FROM = code_id_from
        Me.SEND_ACTIVED_TIME = send_actived_time
        Me.STATUS = status
    End Sub
#End Region
End Class
