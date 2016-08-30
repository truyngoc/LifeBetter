Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Public Module StringExtender



    'kiem tra xem String co null hay khong
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsNull(ByVal str As String) As Boolean
        Return String.IsNullOrEmpty(str)

    End Function
    'kiem tra xem String co null hay khong
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsNotNull(ByVal str As String) As Boolean
        Return Not String.IsNullOrEmpty(str)

    End Function
    'Convert du lieu
    <System.Runtime.CompilerServices.Extension()> _
    Public Function [To](Of T)(ByVal str As String) As T
        If Not str.IsNull() Then
            Return DirectCast(Convert.ChangeType(str, GetType(T)), T)
        Else
            Throw New Exception("dữ liệu trống!")
        End If
        ' Return If(str.IsNull(), DirectCast(Convert.ChangeType(str, GetType(T)), T))
    End Function

    'Convert du lieu
    <System.Runtime.CompilerServices.Extension()> _
    Public Function [To](Of T)(ByVal str As String, ByVal defaultValue As T) As T
        Return If(str.IsNull(), defaultValue, DirectCast(Convert.ChangeType(str, GetType(T)), T))
    End Function
    'format mot String
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Frmat(ByVal str As String, ByVal ParamArray params As Object()) As String
        Return String.Format(str, params)
    End Function

    'khoi tao mot do tuong String
    'Voi dieu kien String phai laf FullName cua mot doi tuong
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateInstace(ByVal str As String) As Object
        Dim type__1 As Type = Type.[GetType](str)
        Return Activator.CreateInstance(type__1, New Object() {})
    End Function

    '''khoi tao mot String voi dieu kien strong phai lam FullName cua mot doi tuong
    '''
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateInstance(Of T As Class)(ByVal str As String) As T
        Return TryCast(str.CreateInstace(), T)
    End Function
    'Kiem tra xem co phai la so hay khong
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsNumberic(ByVal str As String) As Boolean
        Return Regex.IsMatch(str, "^\d+(\.\d+)?$")
    End Function

    ''Convert Json sang Dictionary
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDictionary(ByVal json As String) As Dictionary(Of String, String)
        Dim dict As New Dictionary(Of String, String)
        dict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)

        Return dict
    End Function

    'Dinh dang str kieu Price
    <System.Runtime.CompilerServices.Extension()> _
    Public Function FormatPrice(ByVal str As String) As String
        str = str.Replace(".", "")
        str = str.Replace(",", "")
        Dim tmp As String = ""
        While str.Length > 3
            tmp = "." + str.Substring(str.Length - 3) + tmp
            str = str.Substring(0, str.Length - 3)
        End While
        tmp = str + tmp
        Return tmp
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function FormatMoney(ByVal input As String) As String
        If input IsNot Nothing Then
            If String.IsNullOrEmpty(input.Trim) Then
                Return ""
            Else
                'Dim temp As String = String.Empty
                'For Each ch As Char In input
                '    If ch >= Char.Parse("0") And ch <= Char.Parse("9") Then
                '        temp += ch.ToString()
                '    End If
                'Next
                Dim temp1 As String = input.Trim()
                temp1 = temp1.Replace(",", "")
                If temp1.Split(".")(0).Length > 3 Then
                    Return String.Format("{0:0,0.0000}", CDbl(input.Trim))
                Else
                    Return input.Trim
                End If
                ' Return String.Format("{0:#,#}", CDbl(input.Trim)) 'Constants.Numbers.DISPLAY_NUMBER) N01  
                'Console.WriteLine("N: {0}", 0:N4
                '             integral.ToString("N01", ci));  0:0,0.0000
                ' Return CDbl(input.Trim).ToString("N4")
            End If
        Else
            Return ""
        End If
    End Function

End Module
