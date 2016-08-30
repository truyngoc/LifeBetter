Imports MSA
Imports MSA.INFO

Public Class Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateUsers.Click
        Dim totalF As Integer = Integer.Parse(txtSoLuongTang.Text)
        Dim index As Integer = totalF
        Dim listCurrent As New List(Of String)

        While index > 2
            index = totalF / 2
        End While
        'Dim totalLeft As Integer = Integer.Parse(txtTongNhanhTrai.ToString)
        'Dim totalRight As Integer = Integer.Parse(txtTongNhanhPhai.ToString)

        'Dim UPLINE As String
        ''Tạo tài khoản
        For i As Integer = 1 To totalF
            Dim _mInfo As New MSA_MemberInfo()
            _mInfo.MA_KH = ""
            _mInfo.TEN = "User " + i.ToString
            _mInfo.DIEN_THOAI = "User " + i.ToString
            _mInfo.DIA_CHI = "User " + i.ToString
            _mInfo.SO_TAI_KHOAN = "User " + i.ToString
            _mInfo.NGAN_HANG = "User " + i.ToString
            _mInfo.MAT_KHAU = "123456"
            _mInfo.TRANG_THAI = 1
            _mInfo.URL = ""
            _mInfo.NV = 0


        Next
    End Sub
End Class