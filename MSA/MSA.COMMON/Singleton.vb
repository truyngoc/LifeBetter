Imports System.Web.Caching
Imports System.Web

''' <summary>
''' Đối tượng dùng để khởi tạo Instance cho các đối tượng khác
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class Singleton(Of T As New)
    Private Shared o As New T()
    ''' <summary>
    '''Khởi tạo một Instance
    ''' </summary>
    Public Shared ReadOnly Property Inst() As T
        Get
            Return o
        End Get
    End Property

    ''' <summary>
    ''' New
    ''' </summary>
    Public Shared ReadOnly Property [New]() As T
        Get
            Return New T()
        End Get
    End Property
End Class

Public NotInheritable Class MSACacheHelper
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Insert value into the cache using
    ''' appropriate name/value pairs
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="o">Item to be cached</param>
    ''' <param name="key">Name of item</param>
    Public Shared Sub Add(Of T As Class)(o As T, key As String)
        ' NOTE: Apply expiration parameters as you see fit.
        ' In this example, I want an absolute 
        ' timeout so changes will always be reflected 
        ' at that time. Hence, the NoSlidingExpiration.  
        HttpContext.Current.Cache.Insert(key, o, Nothing, DateTime.Now.AddMinutes(MSA_Constants.ConstCacheKey.MSATimerCache), System.Web.Caching.Cache.NoSlidingExpiration)
    End Sub

    ''' <summary>
    ''' Remove item from cache 
    ''' </summary>
    ''' <param name="key">Name of cached item</param>
    Public Shared Sub Clear(key As String)
        HttpContext.Current.Cache.Remove(key)
    End Sub

    ''' <summary>
    ''' Check for item in cache
    ''' </summary>
    ''' <param name="key">Name of cached item</param>
    ''' <returns></returns>
    Public Shared Function Exists(key As String) As Boolean
        Return HttpContext.Current.Cache(key) IsNot Nothing
    End Function

    ''' <summary>
    ''' Retrieve cached item
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="key">Name of cached item</param>
    ''' <returns>Cached item as type</returns>
    Public Shared Function [Get](Of T As Class)(key As String) As T
        Try
            Return DirectCast(HttpContext.Current.Cache(key), T)
        Catch
            Return Nothing
        End Try
    End Function
End Class