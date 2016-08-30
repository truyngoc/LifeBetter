Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Imports MSA.COMMON
Imports MSA.DAO
Imports MSA.INFO

Public Class AccountSponsorTree
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ma_cay As String

            ma_cay = Request.Params("MA_CAY")

            txtMA_CAY.Text = ma_cay
        End If
    End Sub


    <WebMethod> _
    Public Shared Function GetSponsorData(ma_cay As String) As List(Of Object)        
        ' bo luon luon hien thi root cua ma_cay dang tim kiem
        Dim ma_bao_tro As Object

        Dim query As String = get_Sponsor_Data(ma_cay)

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
            Using cmd As New SqlCommand(query)
                Dim chartData As New List(Of Object)()
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        If sdr("MA_CAY").ToString() = ma_cay Then
                            ma_bao_tro = Nothing
                        Else
                            ma_bao_tro = sdr("MA_BAO_TRO")
                        End If

                        chartData.Add(New Object() {sdr("ID"), sdr("MA_KH"), sdr("MA_CAY"), ma_bao_tro, sdr("TEN"), sdr("MA_BAO_TRO_TT"), _
                            sdr("MA_CAY_TT"), sdr("NHANH_CAY_TT"), sdr("NGAY_THAM_GIA"), sdr("TRANG_THAI"), sdr("MA_GOI_DAU_TU"), sdr("MA_DANH_HIEU")})
                    End While
                End Using
                con.Close()

                Return chartData
            End Using
        End Using
    End Function

    Public Shared Function get_Sponsor_Data(ma_cay As String) As String
        Dim query As String = ""
        query += "SELECT ID"
        query += ", MA_KH"
        query += ", MA_CAY"
        query += ", MA_BAO_TRO"
        query += ", TEN"
        query += ", MA_BAO_TRO_TT"
        query += ", MA_CAY_TT"
        query += ", NHANH_CAY_TT"
        query += ", NGAY_THAM_GIA"
        query += ", TRANG_THAI"
        query += ", MA_GOI_DAU_TU"
        query += ", MA_DANH_HIEU"
        query += " FROM MEMBERS"
        query += " WHERE MA_CAY ='" & ma_cay + "' OR MA_CAY_TT like '" & ma_cay + "%'"
        query += " ORDER BY MA_BAO_TRO"

        Return query
    End Function
End Class