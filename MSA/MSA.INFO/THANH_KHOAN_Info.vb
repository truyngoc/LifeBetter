
Public Class THANH_KHOAN_Info
#Region "***** Fields & Properties *****"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property
    Private _MA_CAY As String
    Public Property MA_CAY() As String
        Get
            Return _MA_CAY
        End Get
        Set(value As String)
            _MA_CAY = value
        End Set
    End Property
    Private _MA_KH As String
    Public Property MA_KH() As String
        Get
            Return _MA_KH
        End Get
        Set(value As String)
            _MA_KH = value
        End Set
    End Property
    Private _MA_DAU_TU As Integer
    Public Property MA_DAU_TU() As Integer
        Get
            Return _MA_DAU_TU
        End Get
        Set(value As Integer)
            _MA_DAU_TU = value
        End Set
    End Property
    Private _NGAY_RUT As DateTime
    Public Property NGAY_RUT() As DateTime
        Get
            Return _NGAY_RUT
        End Get
        Set(value As DateTime)
            _NGAY_RUT = value
        End Set
    End Property
    Private _TEN_KH As String
    Public Property TEN_KH() As String
        Get
            Return _TEN_KH
        End Get
        Set(value As String)
            _TEN_KH = value
        End Set
    End Property
    Private _QUY_TIEN_MAT As Decimal
    Public Property QUY_TIEN_MAT() As Decimal
        Get
            Return _QUY_TIEN_MAT
        End Get
        Set(value As Decimal)
            _QUY_TIEN_MAT = value
        End Set
    End Property
    Private _QUY_PHONG_CACH As Decimal
    Public Property QUY_PHONG_CACH() As Decimal
        Get
            Return _QUY_PHONG_CACH
        End Get
        Set(value As Decimal)
            _QUY_PHONG_CACH = value
        End Set
    End Property
    Private _QUY_DAO_TAO As Decimal
    Public Property QUY_DAO_TAO() As Decimal
        Get
            Return _QUY_DAO_TAO
        End Get
        Set(value As Decimal)
            _QUY_DAO_TAO = value
        End Set
    End Property
    Private _QUY_TIEN_MAT_TK As Decimal
    Public Property QUY_TIEN_MAT_TK() As Decimal
        Get
            Return _QUY_TIEN_MAT_TK
        End Get
        Set(value As Decimal)
            _QUY_TIEN_MAT_TK = value
        End Set
    End Property
    Private _QUY_PHONG_CACH_TK As Decimal
    Public Property QUY_PHONG_CACH_TK() As Decimal
        Get
            Return _QUY_PHONG_CACH_TK
        End Get
        Set(value As Decimal)
            _QUY_PHONG_CACH_TK = value
        End Set
    End Property
    Private _QUY_DAO_TAO_TK As Decimal
    Public Property QUY_DAO_TAO_TK() As Decimal
        Get
            Return _QUY_DAO_TAO_TK
        End Get
        Set(value As Decimal)
            _QUY_DAO_TAO_TK = value
        End Set
    End Property
    Private _isTK_QUY_TIEN_MAT As Integer
    Public Property isTK_QUY_TIEN_MAT() As Integer
        Get
            Return _isTK_QUY_TIEN_MAT
        End Get
        Set(value As Integer)
            _isTK_QUY_TIEN_MAT = value
        End Set
    End Property
    Private _isTK_QUY_PHONG_CACH As Integer
    Public Property isTK_QUY_PHONG_CACH() As Integer
        Get
            Return _isTK_QUY_PHONG_CACH
        End Get
        Set(value As Integer)
            _isTK_QUY_PHONG_CACH = value
        End Set
    End Property
    Private _isTK_QUY_DAO_TAO As Integer
    Public Property isTK_QUY_DAO_TAO() As Integer
        Get
            Return _isTK_QUY_DAO_TAO
        End Get
        Set(value As Integer)
            _isTK_QUY_DAO_TAO = value
        End Set
    End Property
#End Region

#Region "***** Init Methods *****"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer)
        Me.ID = id
    End Sub
    Public Sub New(id As Integer, ma_cay As String, ma_kh As String, ma_dau_tu As Integer, ngay_rut As DateTime, ten_kh As String, _
        quy_tien_mat As Decimal, quy_phong_cach As Decimal, quy_dao_tao As Decimal, quy_tien_mat_tk As Decimal, quy_phong_cach_tk As Decimal, quy_dao_tao_tk As Decimal, _
        istk_quy_tien_mat As Integer, istk_quy_phong_cach As Integer, istk_quy_dao_tao As Integer)
        Me.ID = id
        Me.MA_CAY = ma_cay
        Me.MA_KH = ma_kh
        Me.MA_DAU_TU = ma_dau_tu
        Me.NGAY_RUT = ngay_rut
        Me.TEN_KH = ten_kh
        Me.QUY_TIEN_MAT = quy_tien_mat
        Me.QUY_PHONG_CACH = quy_phong_cach
        Me.QUY_DAO_TAO = quy_dao_tao
        Me.QUY_TIEN_MAT_TK = quy_tien_mat_tk
        Me.QUY_PHONG_CACH_TK = quy_phong_cach_tk
        Me.QUY_DAO_TAO_TK = quy_dao_tao_tk
        Me.isTK_QUY_TIEN_MAT = istk_quy_tien_mat
        Me.isTK_QUY_PHONG_CACH = istk_quy_phong_cach
        Me.isTK_QUY_DAO_TAO = istk_quy_dao_tao
    End Sub
#End Region
End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
