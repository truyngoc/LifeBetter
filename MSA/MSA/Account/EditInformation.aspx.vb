Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System
Imports System.Collections.Generic

Partial Public Class EditInformation
    Inherits System.Web.UI.Page
    Protected Property SuccessMessage() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Protected Property CanRemoveExternalLogins() As Boolean
        Get
            Return m_CanRemoveExternalLogins
        End Get
        Private Set(value As Boolean)
            m_CanRemoveExternalLogins = value
        End Set
    End Property
    Private m_CanRemoveExternalLogins As Boolean

    Private Function HasMAT_KHAU(manager As UserManager) As Boolean
        Dim appUser = manager.FindById(User.Identity.GetUserId())
        Return (appUser IsNot Nothing AndAlso appUser.PasswordHash IsNot Nothing)
    End Function

    Protected Sub Page_Load() Handles Me.Load
        If Not IsPostBack Then
            ' Determine the sections to render
            Dim manager = New UserManager()
            If HasMAT_KHAU(manager) Then
                changeMAT_KHAUHolder.Visible = True
            Else
                setMAT_KHAU.Visible = True
                changeMAT_KHAUHolder.Visible = False
            End If
            CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1

            ' Render success message
            Dim message = Request.QueryString("m")
            If message IsNot Nothing Then
                ' Strip the query string from action
                Form.Action = ResolveUrl("~/Account/Manage")
                SuccessMessage = If(message = "ChangePwdSuccess", "Your MAT_KHAU has been changed.", If(message = "SetPwdSuccess", "Your MAT_KHAU has been set.", If(message = "RemoveLoginSuccess", "The account was removed.", [String].Empty)))
                SuccessMessagePlaceHolder.Visible = Not [String].IsNullOrEmpty(SuccessMessage)
            End If
        End If
    End Sub

    Protected Sub ChangeMAT_KHAU_Click(sender As Object, e As EventArgs)
        If IsValid Then
            Dim manager = New UserManager()
            Dim result As IdentityResult = manager.ChangePassword(User.Identity.GetUserId(), CurrentMAT_KHAU.Text, NewMAT_KHAU.Text)
            If result.Succeeded Then
                Response.Redirect("~/Account/Manage?m=ChangePwdSuccess")
            Else
                AddErrors(result)
            End If
        End If
    End Sub

    Protected Sub SetMAT_KHAU_Click(sender As Object, e As EventArgs)
        'If IsValid Then
        '    ' Create the local login info and link the local account to the user
        '    Dim manager = New UserManager()
        '    Dim result As IdentityResult = manager.AddPasswordAsync(User.Identity.GetUserId(), MAT_KHAU.Text)
        '    If result.Succeeded Then
        '        Response.Redirect("~/Account/Manage?m=SetPwdSuccess")
        '    Else
        '        AddErrors(result)
        '    End If
        'End If
    End Sub

    Public Function GetLogins() As IEnumerable(Of UserLoginInfo)
        Dim manager = New UserManager()
        Dim accounts = manager.GetLogins(User.Identity.GetUserId())
        CanRemoveExternalLogins = accounts.Count() > 1 Or HasMAT_KHAU(manager)
        Return accounts
    End Function

    Public Sub RemoveLogin(loginProvider As String, providerKey As String)
        Dim manager = New UserManager()
        Dim result = manager.RemoveLogin(User.Identity.GetUserId(), New UserLoginInfo(loginProvider, providerKey))
        Dim msg = If(result.Succeeded, "?m=RemoveLoginSuccess", [String].Empty)
        Response.Redirect("~/Account/Manage" & msg)
    End Sub

    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub
End Class
