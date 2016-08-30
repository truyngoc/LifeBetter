Imports System
Imports System.Web.Caching

Namespace MSA_Constants
    'GIANGTD3-key Encript - Decript Pass:
    Public NotInheritable Class ConstEncriptKey
        Public Const KeyEncriptPass As String = "MHS@2013"
        Public Const ParttentPass As String = "MAT_KHAU=\s*(.*?)\s*;"
        Public Const KeyEncriptRef As String = "MSA@2013"

    End Class
    Public NotInheritable Class ConstCacheKey
        Public Const MSAKeyConfig As String = "MSA_CONFIG"
        Public Const MSAKeyConfigAmountPH As String = "CONFIG_AMOUNT_PH"
        Public Const MSATimerCache As Integer = 400000
    End Class

    Public NotInheritable Class TypeRose
        Public Const DirectRose As Integer = 0  'Hoa hong truc tiep
        Public Const LineRose As Integer = 1    'Hoa hong he thong
    End Class

    Public NotInheritable Class StatusSend
        Public Const Watting As Integer = 0  'chờ cho đi, mới khởi tạo PH
        Public Const Sent As Integer = 1    'đã cho đi thành công
        Public Const Lock As Integer = 2    'đã quá hạn cho đi
        
    End Class

End Namespace

