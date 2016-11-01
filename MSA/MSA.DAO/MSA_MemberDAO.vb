Imports MSA.INFO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Dapper

Public Class MSA_MemberDAO
    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)

    Public Function Find(id As Integer) As MSA_MemberInfo

        Return DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetByID", New With {Key .ID = id}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)

    End Function

    Public Function CHECK_VI_TRI_TRONG(MA_UPLINE As String) As Integer

        Dim parameter As New DynamicParameters()
        parameter.Add("@MA_CAY", MA_UPLINE, DbType.String)
        parameter.Add("@STATUS", "", DbType.String, ParameterDirection.Output)
        'db.Execute("sproc_MEMBERS_Add", New With {Key .MA_KH = mInfo.MA_KH, Key .MAT_KHAU = mInfo.MAT_KHAU, Key .TEN = mInfo.TEN, Key .DIEN_THOAI = mInfo.DIEN_THOAI, Key .DIA_CHI = mInfo.DIA_CHI, Key .MA_BAO_TRO_TT = mInfo.MA_BAO_TRO_TT, Key .URL = mInfo.URL, Key .NV = mInfo.NV}, commandType:=CommandType.StoredProcedure)
        db.Execute("sproc_MEMBERS_CHECK_VI_TRI", parameter, commandType:=CommandType.StoredProcedure)
        Return Integer.Parse(parameter.Get(Of String)("@STATUS"))
    End Function

    Public Function FindByMA_BAO_TRO(MA_BAO_TRO As String) As MSA_MemberInfo

        Return DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetByMA_BAO_TRO", New With {Key .MA_BAO_TRO = MA_BAO_TRO}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)

    End Function

    Public Function FindByMA_KH(MA_KH As String) As MSA_MemberInfo

        Return DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetByMA_KH", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)

    End Function

    Public Function FindByMA_CAY(MA_CAY As String) As MSA_MemberInfo

        Return DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetByMA_CAY", New With {Key .MA_CAY = MA_CAY}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)

    End Function

    Public Function FindBaoTro(MA_CAY As String) As MSA_MemberInfo

        Return DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetBaoTro", New With {Key .MA_CAY = MA_CAY}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)

    End Function

    Public Function Find(MA_KH As String, ByVal MAT_KHAU As String)
        'Dim multipleresult = db.QueryMultiple("sproc_MEMBERS_GetByUserPass", New With { _
        '                                                                                Key .MA_KH = MA_KH _
        '                                                                            , Key .MAT_KHAU = MAT_KHAU _
        '                                                                        }, commandType:=CommandType.StoredProcedure)
        Dim member = DirectCast(db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_GetByUserPass", New With {Key .MA_KH = MA_KH, .MAT_KHAU = MAT_KHAU}, commandType:=CommandType.StoredProcedure _
                                                                    ).SingleOrDefault(), MSA_MemberInfo)
        Return member

    End Function
    Public Sub ResetMAT_KHAU(ByVal MA_KH As String, ByVal MAT_KHAU As String)
        db.Execute("sproc_MEMBERS_ResetMAT_KHAU", New With { _
                                                            Key .MA_KH = MA_KH _
                                                          , Key .MAT_KHAU = MAT_KHAU _
                                                          }, commandType:=CommandType.StoredProcedure)

    End Sub

    Public Sub Update(_info As MSA_MemberInfo)

        Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("MEMBERS", _info)
        Dim parameter = New DynamicParameters()
        parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)
        db.Execute("sproc_MEMBERS_Update", parameter, commandType:=CommandType.StoredProcedure)

    End Sub

    'Public Sub UpdateProfile(_info As MSA_MemberInfo)

    '    Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("MEMBERS", _info)
    '    dictsqlParam.Remove("ExistsChild")
    '    dictsqlParam.Remove("IsLock")
    '    dictsqlParam.Remove("ID")
    '    dictsqlParam.Remove("Country")

    '    Dim parameter = New DynamicParameters()
    '    parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)
    '    db.Execute("sproc_MEMBERS_UpdateProfile", parameter, commandType:=CommandType.StoredProcedure)

    'End Sub

    Public Sub UpdateDanhHieuKimCuong(ByVal MA_CAY As String)
        db.Execute("sproc_MEMBERS_UpdateDANH_HIEU_KIM_CUONG", New With {Key .MA_CAY = MA_CAY}, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub UpdateDanhHieuChuTich(ByVal MA_CAY As String)
        db.Execute("sproc_MEMBERS_UpdateDANH_HIEU_CHU_TICH", New With {Key .MA_CAY = MA_CAY}, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub UpdateStatus(ByVal CodeId As String, ByVal IsLock As Integer)
        db.Execute("sproc_MEMBERS_UpdateStatus", New With {Key .CodeId = CodeId, Key .IsLock = IsLock}, commandType:=CommandType.StoredProcedure)
    End Sub
    'Public Sub Remove(Id As Integer)

    '    db.Execute("sproc_MEMBERS_Delete", New With {Key .ID = Id}, commandType:=CommandType.StoredProcedure)
    'End Sub

    ''File:

    'Public Sub InsertFile(ByVal _info As MSA_Member_FileInfo)
    '    Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("MEMBER_FILE", _info)
    '    dictsqlParam.Remove("Id")
    '    Dim parameter = New DynamicParameters()
    '    parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)
    '    db.Execute("sproc_MEMBER_FILE_Add", parameter, commandType:=CommandType.StoredProcedure)
    'End Sub

    Function Insert(mInfo As MSA_MemberInfo) As String
        Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("MEMBERS", mInfo)
        dictsqlParam("MA_KH").Direction = ParameterDirection.Output
        dictsqlParam.Remove("ID")
        dictsqlParam.Remove("MA_CAY")
        dictsqlParam.Remove("MA_BAO_TRO")
        dictsqlParam.Remove("CMND")
        dictsqlParam.Remove("NGAY_SINH")
        dictsqlParam.Remove("MST")
        dictsqlParam.Remove("MA_CAY_TT")
        dictsqlParam.Remove("TEN_CAY_TT")
        dictsqlParam.Remove("TEN_BAO_TRO_TT")
        dictsqlParam.Remove("NHANH_CAY_TT")
        dictsqlParam.Remove("NGAY_THAM_GIA")
        dictsqlParam.Remove("TRANG_THAI")
        dictsqlParam.Remove("MA_GOI_DAU_TU")
        dictsqlParam.Remove("TEN_GOI_DAU_TU")
        dictsqlParam.Remove("MA_DANH_HIEU")
        dictsqlParam.Remove("NGAY_NANG_CAP")
        Dim parameter = New DynamicParameters()
        parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)
        'db.Execute("sproc_MEMBERS_Add", New With {Key .MA_KH = mInfo.MA_KH, Key .MAT_KHAU = mInfo.MAT_KHAU, Key .TEN = mInfo.TEN, Key .DIEN_THOAI = mInfo.DIEN_THOAI, Key .DIA_CHI = mInfo.DIA_CHI, Key .MA_BAO_TRO_TT = mInfo.MA_BAO_TRO_TT, Key .URL = mInfo.URL, Key .NV = mInfo.NV}, commandType:=CommandType.StoredProcedure)
        db.Execute("sproc_MEMBERS_Add", parameter, commandType:=CommandType.StoredProcedure)
        Return parameter.Get(Of String)("@MA_KH")
    End Function

    Sub Update_KICH_HOAT(mInfo As MSA_MemberInfo)
        db.Execute("sproc_MEMBERS_Admin_KichHoat", New With {Key .MA_KH = mInfo.MA_KH, Key .MA_CAY = mInfo.MA_CAY, Key .MA_CAY_TT = mInfo.MA_CAY_TT, Key .NHANH_CAY_TT = mInfo.NHANH_CAY_TT, Key .MA_BAO_TRO = mInfo.MA_BAO_TRO, Key .MA_GOI_DAU_TU = mInfo.MA_GOI_DAU_TU, Key .TRANG_THAI = mInfo.TRANG_THAI}, commandType:=CommandType.StoredProcedure)
        'db.Execute("sproc_MEMBERS_Admin_KichHoat", parameter, commandType:=CommandType.StoredProcedure)
    End Sub


    Sub Admin_Update(mInfo As MSA_MemberInfo)
        Dim dictsqlParam As Dictionary(Of String, SqlParameter) = SqlUtilities.GetParameters("MEMBERS", mInfo)
        dictsqlParam.Remove("ID")
        dictsqlParam.Remove("MAT_KHAU")
        dictsqlParam.Remove("NGAY_SINH")
        dictsqlParam.Remove("MST")
        dictsqlParam.Remove("NGAY_THAM_GIA")
        dictsqlParam.Remove("MA_GOI_DAU_TU")
        dictsqlParam.Remove("TEN_GOI_DAU_TU")
        dictsqlParam.Remove("MA_DANH_HIEU")
        dictsqlParam.Remove("URL")
        dictsqlParam.Remove("NV")
        dictsqlParam.Remove("NGAY_NANG_CAP")
        dictsqlParam.Remove("MA_BAO_TRO_TT")
        dictsqlParam.Remove("TRANG_THAI")
        dictsqlParam.Remove("MA_CAY_TT")
        dictsqlParam.Remove("NHANH_CAY_TT")
        dictsqlParam.Remove("MA_CAY")
        Dim parameter = New DynamicParameters()
        parameter = SqlUtilities.GetDynamicParameters(dictsqlParam)

        db.Execute("sproc_MEMBERS_Admin_Update", parameter, commandType:=CommandType.StoredProcedure)
    End Sub


    '-------------
    Public Function SEARCH_NEW(ByVal SearchText As String, ByVal Type As Integer, ByVal ThangNam As String, ByVal TrangThai As Integer) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_NEW", New With {Key .SearchText = SearchText, Key .Type = Type, Key .ThangNam = ThangNam, Key .TrangThai = TrangThai}, _
                                           commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function


    Public Sub DELETE(ByVal ID As Integer)
        db.Execute("sproc_MEMBERS_Delete", New With {Key .ID = ID
                                                    }, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub LOCK_AND_UNLOCK(ByVal ID As Integer, ByVal TRANG_THAI As Integer)
        db.Execute("sproc_MEMBERS_Lock_Unlock", New With {Key .ID = ID, Key .TRANG_THAI = TRANG_THAI
                                                    }, commandType:=CommandType.StoredProcedure)
    End Sub

    '-------------

    Public Function SEARCH_ALL() As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_ALL", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_KH(ByVal MA_KH As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_MA_KH", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function
    Public Function SEARCH_BY_MA_KH_DOWNLINE(ByVal MA_KH As String, ByVal MA_SPONSOR As String) As MSA_MemberInfo

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_MA_KH_DOWNLINE", New With {Key .MA_KH = MA_KH, Key .MA_SPONSOR = MA_SPONSOR}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList.FirstOrDefault
    End Function
    Public Function SEARCH_BY_TEN(ByVal TEN As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_TEN", New With {Key .TEN = TEN}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function


    Public Function SEARCH_BY_MA_GOI_DAU_TU(ByVal MA_GOI_DAU_TU As Integer) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_MA_GOI_DAU_TU", New With {Key .MA_GOI_DAU_TU = MA_GOI_DAU_TU}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_KH_BAO_TRO_TT(ByVal MA_KH As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_MA_KH_BAO_TRO_TT", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_MA_KH_CHI_DINH_TT(ByVal MA_KH As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_MA_KH_CHI_DINH_TT", New With {Key .MA_KH = MA_KH}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_TEN_KH_BAO_TRO_TT(ByVal TEN As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_TEN_KH_BAO_TRO_TT", New With {Key .TEN = TEN}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_TEN_KH_CHI_DINH_TT(ByVal TEN As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_TEN_KH_CHI_DINH_TT", New With {Key .TEN = TEN}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_DIEN_THOAI(ByVal DIEN_THOAI As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_DIEN_THOAI]", New With {Key .DIEN_THOAI = DIEN_THOAI}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_DIA_CHI(ByVal DIA_CHI As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_DIA_CHI]", New With {Key .DIA_CHI = DIA_CHI}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_STK(ByVal STK As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_STK]", New With {Key .STK = STK}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_NGAN_HANG(ByVal STK As String) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_NGAN_HANG]", New With {Key .STK = STK}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_NGAY_THAM_GIA(ByVal NGAY_THAM_GIA As Date) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_NGAY_THAM_GIA]", New With {Key .NGAY_THAM_GIA = NGAY_THAM_GIA}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function SEARCH_BY_NGAY_NANG_CAP(ByVal NGAY_NANG_CAP As Date) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("[sproc_MEMBERS_SEARCH_BY_NGAY_NANG_CAP]", New With {Key .NGAY_NANG_CAP = NGAY_NANG_CAP}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function
    Public Function SEARCH_BY_TRANG_THAI(ByVal TRANG_THAI As Integer) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sproc_MEMBERS_SEARCH_BY_TRANG_THAI", New With {Key .TRANG_THAI = TRANG_THAI}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function

    Public Function get_All() As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sp_MEMBERS_get_All", commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function


    Public Function get_All(ByVal Month As Integer) As List(Of MSA_MemberInfo)

        Return db.Query(Of MSA_MemberInfo)("sp_MEMBERS_get_All_By_Month", New With {Key .Month = Month}, commandType:=CommandType.StoredProcedure _
                                                                    ).ToList
    End Function
    Public Function Check_OldPassword(ByVal MA_KH As String, ByVal OldPassword As String) As Boolean
        Dim ret As Object
        ret = db.ExecuteScalar("sp_MEMBERS_Check_OldPassword", New With {Key .MA_KH = MA_KH, Key .OldPassword = OldPassword}, commandType:=CommandType.StoredProcedure)

        If (ret = 0) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub ChangePassword(ByVal MA_KH As String, ByVal NewPassword As String)

        db.Execute("sp_MEMBERS_ChangePwd", New With {Key .MA_KH = MA_KH,
                                                    Key .NewPassword = NewPassword
                                                     }, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub UpdateProfile(ByVal MA_KH As String, ByVal EMAIL As String, ByVal DIEN_THOAI As String, ByVal SO_TAI_KHOAN As String, ByVal NGAN_HANG As String)
        db.Execute("sp_MEMBERS_UpdateProfile", New With {Key .MA_KH = MA_KH,
                                                    Key .EMAIL = EMAIL,
                                                     Key .DIEN_THOAI = DIEN_THOAI,
                                                     Key .SO_TAI_KHOAN = SO_TAI_KHOAN,
                                                     Key .NGAN_HANG = NGAN_HANG
                                                     }, commandType:=CommandType.StoredProcedure)
    End Sub

    Public Sub UpdateImageProfileURL(ByVal MA_KH As String, ByVal URL As String)

        db.Execute("sp_MEMBERS_UpdateImageProfileURL", New With {Key .MA_KH = MA_KH,
                                                    Key .URL = URL
                                                     }, commandType:=CommandType.StoredProcedure)
    End Sub
End Class