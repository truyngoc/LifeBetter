﻿Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class CommisionStatistics
    Inherits System.Web.UI.Page

    Private daoDOANH_SO As New MSA_DOANH_SO_DAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'load doanh so
            Dim title As String = "<h4 class='text-center'>THỐNG KÊ</h4>"
            lblDOANH_SO_THANG.Text = Server.HtmlDecode(title)            

            bindDDL_MonthDS()

            bindDOANH_SO()
        End If
    End Sub


   Public Sub bindDOANH_SO()

        Dim lstDOANH_SO As List(Of HOA_HONG)
        lstDOANH_SO = daoDOANH_SO.get_by_Thang_ddl(ddlMonthDS.SelectedValue)

        If lstDOANH_SO IsNot Nothing AndAlso lstDOANH_SO.Count > 0 Then
            lblDOANH_SO_THANG.Visible = True

            datagrid.DataSource = lstDOANH_SO
            datagrid.DataBind()

            lblDOANH_SO_THANG.Visible = True
            lblNotify.Visible = False
        Else
            lblDOANH_SO_THANG.Visible = False

            datagrid.DataSource = Nothing
            datagrid.DataBind()

            lblDOANH_SO_THANG.Visible = False
            lblNotify.Visible = True
        End If
    End Sub

    Public Sub bindDDL_MonthDS()
        Dim lstMonth As List(Of THANG_DOANH_SO)

        lstMonth = daoDOANH_SO.get_All_Thang_Doanh_so()

        If lstMonth IsNot Nothing AndAlso lstMonth.Count > 0 Then
            ddlMonthDS.DataSource = lstMonth
            ddlMonthDS.DataValueField = "DS_Value"
            ddlMonthDS.DataTextField = "DS_Text"
            ddlMonthDS.DataBind()
        Else
            ddlMonthDS.DataSource = Nothing
            ddlMonthDS.DataBind()
        End If
    End Sub


    Public Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        datagrid.PageIndex = e.NewPageIndex
        bindDOANH_SO()
    End Sub

    Protected Sub datagrid_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles datagrid.RowCommand
        Try
            If e.CommandName = "cmdView" Then
                'RaiseEvent pEvtSua(e.CommandArgument)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlMonthDS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonthDS.SelectedIndexChanged
        bindDOANH_SO()
    End Sub
End Class