Public Class MSA_SYNCDATA_PAYMENTInfo

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
    Private _CODE_ID_TO As String
    Public Property CODE_ID_TO() As String
        Get
            Return _CODE_ID_TO
        End Get
        Set(value As String)
            _CODE_ID_TO = value
        End Set
    End Property
    Private _DATE_START As DateTime
    Public Property DATE_START() As DateTime
        Get
            Return _DATE_START
        End Get
        Set(value As DateTime)
            _DATE_START = value
        End Set
    End Property
    Private _DATE_END As DateTime
    Public Property DATE_END() As DateTime
        Get
            Return _DATE_END
        End Get
        Set(value As DateTime)
            _DATE_END = value
        End Set
    End Property
    Private _AMOUNT As Decimal
    Public Property AMOUNT() As Decimal
        Get
            Return _AMOUNT
        End Get
        Set(value As Decimal)
            _AMOUNT = value
        End Set
    End Property
    Private _REPORT_ID As String
    Public Property REPORT_ID() As String
        Get
            Return _REPORT_ID
        End Get
        Set(value As String)
            _REPORT_ID = value
        End Set
    End Property
    Private _STATUS_SEND As Integer?
    Public Property STATUS_SEND() As Integer?
        Get
            Return _STATUS_SEND
        End Get
        Set(value As Integer?)
            _STATUS_SEND = value
        End Set
    End Property
    Private _STATUS_RECEIVE As Integer?
    Public Property STATUS_RECEIVE() As Integer?
        Get
            Return _STATUS_RECEIVE
        End Get
        Set(value As Integer?)
            _STATUS_RECEIVE = value
        End Set
    End Property

    Public Property ID_SEND As Integer?

    Public Property ID_RECEIVE As Integer?

    Public Property ID_COMMITION As Integer?

#End Region

#Region "***** Init Methods *****"
    Public Sub New()
    End Sub
    Public Sub New(id As Decimal)
        Me.ID = id
    End Sub
    Public Sub New(id As Decimal, code_id_from As String, code_id_to As String, date_start As DateTime, date_end As DateTime, amount As Decimal, _
        report_id As String, status_send As Integer?, status_receive As Integer?, id_send As Integer?, id_receive As Integer?, ByVal id_commition As Integer?)
        Me.ID = id
        Me.CODE_ID_FROM = code_id_from
        Me.CODE_ID_TO = code_id_to
        Me.DATE_START = date_start
        Me.DATE_END = date_end
        Me.AMOUNT = amount
        Me.REPORT_ID = report_id
        Me.STATUS_SEND = status_send
        Me.STATUS_RECEIVE = status_receive
        Me.ID_SEND = id_send
        Me.ID_RECEIVE = id_receive
        Me.ID_COMMITION = id_commition
    End Sub
#End Region

End Class

Public Class MSA_SYNCDATA_MEMBER_PINInfo
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
    Private _CODE_ID As String
    Public Property CODE_ID() As String
        Get
            Return _CODE_ID
        End Get
        Set(value As String)
            _CODE_ID = value
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
    Private _ACTIVED As Boolean
    Public Property ACTIVED() As Boolean
        Get
            Return _ACTIVED
        End Get
        Set(value As Boolean)
            _ACTIVED = value
        End Set
    End Property
    Private _PIN_ACTIVE As DateTime?
    Public Property PIN_ACTIVE() As DateTime?
        Get
            Return _PIN_ACTIVE
        End Get
        Set(value As DateTime?)
            _PIN_ACTIVE = value
        End Set
    End Property
    Private _PH_ACTIVE As DateTime?
    Public Property PH_ACTIVE() As DateTime?
        Get
            Return _PH_ACTIVE
        End Get
        Set(value As DateTime?)
            _PH_ACTIVE = value
        End Set
    End Property
    Public Property GETDATE_DB As DateTime?
#End Region

#Region "***** Init Methods *****"
    Public Sub New()
    End Sub
    Public Sub New(id As Decimal)
        Me.ID = id
    End Sub
    Public Sub New(id As Decimal, code_id As String, pin_amount As Integer, actived As Boolean, pin_active As DateTime?, ph_active As DateTime?)
        Me.ID = id
        Me.CODE_ID = code_id
        Me.PIN_AMOUNT = pin_amount
        Me.ACTIVED = actived
        Me.PIN_ACTIVE = pin_active
        Me.PH_ACTIVE = ph_active
    End Sub
#End Region
End Class