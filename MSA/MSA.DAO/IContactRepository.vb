Public Interface IContactRepository
    Function Find(id As Integer) As Contact
    Function GetAll() As List(Of Contact)
    Function Add(contact As Contact) As Contact
    Function Update(contact As Contact) As Contact
    Sub Remove(id As Integer)

    Function GetFullContact(id As Integer) As Contact
End Interface
Public Class Contact
    Public Sub New()
        Me.Addresses = New List(Of Address)()
    End Sub

    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = Value
        End Set
    End Property
    Private m_FirstName As String
    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = Value
        End Set
    End Property
    Private m_LastName As String
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = Value
        End Set
    End Property
    Private m_Email As String
    Public Property Company() As String
        Get
            Return m_Company
        End Get
        Set(value As String)
            m_Company = Value
        End Set
    End Property
    Private m_Company As String
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String

    Public Property Addresses() As List(Of Address)
        Get
            Return m_Addresses
        End Get
        Private Set(value As List(Of Address))
            m_Addresses = Value
        End Set
    End Property
    Private m_Addresses As List(Of Address)

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return Me.Id = 0
        End Get
    End Property
End Class
Public Class Address
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property ContactId() As Integer
        Get
            Return m_ContactId
        End Get
        Set(value As Integer)
            m_ContactId = Value
        End Set
    End Property
    Private m_ContactId As Integer
    Public Property AddressType() As String
        Get
            Return m_AddressType
        End Get
        Set(value As String)
            m_AddressType = Value
        End Set
    End Property
    Private m_AddressType As String
    Public Property StreetAddress() As String
        Get
            Return m_StreetAddress
        End Get
        Set(value As String)
            m_StreetAddress = Value
        End Set
    End Property
    Private m_StreetAddress As String
    Public Property City() As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = Value
        End Set
    End Property
    Private m_City As String
    Public Property StateId() As Integer
        Get
            Return m_StateId
        End Get
        Set(value As Integer)
            m_StateId = Value
        End Set
    End Property
    Private m_StateId As Integer
    Public Property PostalCode() As String
        Get
            Return m_PostalCode
        End Get
        Set(value As String)
            m_PostalCode = Value
        End Set
    End Property
    Private m_PostalCode As String

    Friend ReadOnly Property IsNew() As Boolean
        Get
            Return Me.Id = 0
        End Get
    End Property

    Public Property IsDeleted() As Boolean
        Get
            Return m_IsDeleted
        End Get
        Set(value As Boolean)
            m_IsDeleted = Value
        End Set
    End Property
    Private m_IsDeleted As Boolean
End Class
Public Class State
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property StateName() As String
        Get
            Return m_StateName
        End Get
        Set(value As String)
            m_StateName = Value
        End Set
    End Property
    Private m_StateName As String
End Class
