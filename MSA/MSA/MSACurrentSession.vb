Imports MSA.INFO
Public Class MSACurrentSession
    Public Property SessionMember() As MSA_MemberInfo
        Get
            If HttpContext.Current.Session("MSA_MemberInfoLogon") IsNot Nothing Then
                Return TryCast(HttpContext.Current.Session("MSA_MemberInfoLogon"), MSA_MemberInfo)
            End If
            Return Nothing
        End Get
        Set(value As MSA_MemberInfo)
            HttpContext.Current.Session("MSA_MemberInfoLogon") = value
        End Set
    End Property
    Public ReadOnly Property isLoginUser() As Boolean
        Get
            Return HttpContext.Current.Session("MSA_MemberInfoLogon") IsNot Nothing
        End Get
    End Property

    Public Shared Sub SignOut()
        If HttpContext.Current.Session("MSA_MemberInfoLogon") IsNot Nothing Then
            HttpContext.Current.Session("MSA_MemberInfoLogon") = Nothing
            HttpContext.Current.Session.Abandon()
        End If
    End Sub

    'End Class

    'Public Class MSACurrentSessionAdmin
    '    Public Property SessionMember() As MSA_MemberInfo
    '        Get
    '            If HttpContext.Current.Session("MSA_MemberInfoLogonAdmin") IsNot Nothing Then
    '                Return TryCast(HttpContext.Current.Session("MSA_MemberInfoLogonAdmin"), MSA_MemberInfo)
    '            End If
    '            Return Nothing
    '        End Get
    '        Set(value As MSA_MemberInfo)
    '            HttpContext.Current.Session("MSA_MemberInfoLogonAdmin") = value
    '        End Set
    '    End Property
    '    Public ReadOnly Property isLoginUser() As Boolean
    '        Get
    '            Return HttpContext.Current.Session("MSA_MemberInfoLogonAdmin") IsNot Nothing
    '        End Get
    '    End Property



End Class
