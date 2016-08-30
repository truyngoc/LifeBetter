Imports System.Reflection
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Security.Cryptography
Imports System.Web

Public Module ObjectExtender

   
    Private Function Compare(Of T)(ByVal Object1 As T, ByVal object2 As T) As Boolean
        'Get the type of the object
        Dim type As Type = GetType(T)

        'return false if any of the object is false
        If Object1 Is Nothing OrElse object2 Is Nothing Then
            Return False
        End If

        'Loop through each properties inside class and get values for the property from both the objects and compare
        For Each [property] As System.Reflection.PropertyInfo In type.GetProperties()
            If [property].Name <> "ExtensionData" Then
                Dim Object1Value As String = String.Empty
                Dim Object2Value As String = String.Empty
                If type.GetProperty([property].Name).GetValue(Object1, Nothing) IsNot Nothing Then
                    Object1Value = type.GetProperty([property].Name).GetValue(Object1, Nothing).ToString()
                End If
                If type.GetProperty([property].Name).GetValue(object2, Nothing) IsNot Nothing Then
                    Object2Value = type.GetProperty([property].Name).GetValue(object2, Nothing).ToString()
                End If
                If Object1Value.Trim() <> Object2Value.Trim() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function


    Public Function Equals(ByVal x As Object, ByVal y As Object) As Boolean
        Dim r = True

        Dim PropXs As PropertyInfo() = x.GetType().GetProperties()
        Dim propYs As PropertyInfo() = y.GetType().GetProperties()
        If PropXs.Length <> propYs.Length Then
            Return False
        Else
            For i As Integer = 0 To PropXs.Length - 1
                Dim strName = PropXs(i).Name
                If strName <> "ExtensionData" Then
                    If Not propYs.ToList().Any(Function(o) o.Name = strName) Then
                        Return False
                    Else
                        Dim v1 = String.Empty
                        Dim v2 = String.Empty
                        If x.GetType().GetProperty(PropXs(i).Name).GetValue(x, Nothing) IsNot Nothing Then
                            v1 = x.GetType().GetProperty(PropXs(i).Name).GetValue(x, Nothing).ToString()
                        End If
                        If y.GetType().GetProperty(PropXs(i).Name).GetValue(y, Nothing) IsNot Nothing Then
                            v2 = y.GetType().GetProperty(PropXs(i).Name).GetValue(y, Nothing).ToString()
                        End If
                        If v1.Trim() <> v2.Trim() Then
                            Return False
                        End If
                    End If
                End If

            Next
        End If


        Return r
    End Function


    Public Function RandomString(ByVal str As String, length As Integer) As String
        Const chars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim random = New Random()
        Return New String(Enumerable.Repeat(chars, length).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ContainKeysExt(Of T)(ByVal seenKeys As HashSet(Of T), ByVal obj As T)
        Return seenKeys.Any(Function(o) Equals(o, obj))
    End Function

    ''' <summary>
    ''' lst = lst.DistinctBy(Function(p) New With { _
    '                                                p.MA_HQQL, _
    '                                                p.ID_TO_KHAI _
    '                                            }).ToList
    ''' </summary>
    ''' <typeparam name="TSource"></typeparam>
    ''' <typeparam name="TKey"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="keySelector"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DistinctBy(Of TSource, TKey)(ByVal source As List(Of TSource), ByVal keySelector As Func(Of TSource, TKey)) As List(Of TSource)
        Dim lst As New List(Of TSource)
        Dim seenKeys As New HashSet(Of TKey)()
        For Each element As TSource In source

            If Not seenKeys.ContainKeysExt(keySelector(element)) Then
                If seenKeys.Add(keySelector(element)) Then
                    lst.Add(element)
                End If
            End If
        Next
        Return lst
    End Function


    <System.Runtime.CompilerServices.Extension()> _
    Public Function RemoveDuplicateRows(ByVal dTable As DataTable, ByVal colName As String) As DataTable
        Dim hTable As New Hashtable()
        Dim duplicateList As New ArrayList()
        For Each drow__1 As DataRow In dTable.Rows
            If hTable.Contains(drow__1(colName)) Then
                duplicateList.Add(drow__1)
            Else
                hTable.Add(drow__1(colName), String.Empty)
            End If
        Next

        For Each dRow__2 As DataRow In duplicateList
            dTable.Rows.Remove(dRow__2)
        Next
        Return dTable
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Iterator Function DistinctBy(Of TSource, TKey)(source As IEnumerable(Of TSource), keySelector As Func(Of TSource, TKey)) As IEnumerable(Of TSource)
        Dim seenKeys As New HashSet(Of TKey)()
        For Each element As TSource In source
            If seenKeys.Add(keySelector(element)) Then
                Yield element
            End If
        Next
    End Function

    '' Làm việc với file upload:
#Region "Save file"

    <System.Runtime.CompilerServices.Extension()> _
    Public Function SaveFile(file1 As HttpPostedFile, ByVal Server As HttpServerUtility, ByVal strLocation As String) As String
        'tao folder tren server
        Dim folderNameYear As String = System.DateTime.Now.Year.ToString()
        Dim folderNameMonth As String = System.DateTime.Now.Month.ToString()
        Dim folderNameDay As String = System.DateTime.Now.Day.ToString()

        Dim strdirectoryPathYear As String = Server.MapPath(String.Format(strLocation & Convert.ToString("\{0}\"), folderNameYear))
        Dim strdirectoryPathMonth As String = Server.MapPath(String.Format((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\{0}\", folderNameMonth))
        Dim strdirectoryPathDay As String = Server.MapPath(String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay))

        Dim bitCreate As String = "000"

        Directory.CreateDirectory(strdirectoryPathYear)
        If Directory.Exists(strdirectoryPathYear) = False Then
            bitCreate = "111"
        Else
            If Directory.Exists(strdirectoryPathMonth) = False Then
                bitCreate = "011"
            Else
                If Directory.Exists(strdirectoryPathDay) = False Then

                    bitCreate = "001"
                Else
                    bitCreate = "000"
                End If
            End If
        End If

        Select Case bitCreate
            Case "111"
                Directory.CreateDirectory(strdirectoryPathYear)
                Directory.CreateDirectory(strdirectoryPathMonth)
                Directory.CreateDirectory(strdirectoryPathDay)

                Exit Select
            Case "011"
                ' Directory.CreateDirectory(strdirectoryPathYear)
                Directory.CreateDirectory(strdirectoryPathMonth)
                Directory.CreateDirectory(strdirectoryPathDay)

                Exit Select
            Case "001"
                'Directory.CreateDirectory(strdirectoryPathYear)
                'Directory.CreateDirectory(strdirectoryPathMonth)
                Directory.CreateDirectory(strdirectoryPathDay)

                Exit Select
            Case "000"
                Exit Select
                'Directory.CreateDirectory(strdirectoryPathYear)
                'Directory.CreateDirectory(strdirectoryPathMonth)
                'Directory.CreateDirectory(strdirectoryPathDay)

        End Select

        Dim strdirectoryPath As String = strdirectoryPathDay

        Dim str As String = ""
        Dim strResult As String = String.Empty
        Dim count As Integer = 0
        Dim filename As String = String.Empty
        If Not String.IsNullOrEmpty(file1.FileName) Then
            Dim ext As String = Path.GetExtension(file1.FileName)
            Dim files As String() = Directory.GetFiles(Server.MapPath(String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay)))

            If File.Exists(Server.MapPath(String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay)) + Path.GetFileName(file1.FileName)) = True Then
                For Each s As String In files
                    filename = Path.GetFileName(s).Substring(0, Path.GetFileName(s).LastIndexOf("."))
                    If filename.Contains("(") = True Then
                        filename = filename.Substring(0, filename.LastIndexOf("("))
                    End If
                    If (filename = Path.GetFileName(file1.FileName).Substring(0, Path.GetFileName(file1.FileName).LastIndexOf("."))) Then

                        count = count + 1
                    End If
                Next
                Dim filesave As String = file1.FileName.Substring(0, file1.FileName.LastIndexOf("."))
                file1.SaveAs(Convert.ToString((Server.MapPath(String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay)) & filesave) + "(" + count.ToString() + ")") & ext)
              

                strResult = Convert.ToString((Convert.ToString((Convert.ToString((String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay) & filesave) + "(" + count.ToString() + ")") & ext) + "|") & filesave) + "(" + count.ToString() + ")") & ext
            Else
                file1.SaveAs(Server.MapPath(String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay)) + file1.FileName)
               

                strResult = String.Format((Convert.ToString((Convert.ToString(strLocation & Convert.ToString("\")) & folderNameYear) + "\") & folderNameMonth) + "\{0}\", folderNameDay) + file1.FileName + "|" + file1.FileName
            End If

            Return strResult
        Else
            Return ""
        End If
    End Function

    Public Function SaveFiles(ByVal Request As HttpRequest, ByVal Server As HttpServerUtility, ByVal strLocation As String) As Dictionary(Of String, String)
        Dim lstFile As New Dictionary(Of String, String)()
        Dim hfc As HttpFileCollection = Request.Files
        If hfc.Count > 0 Then
            For k As Integer = 0 To hfc.Count - 1
                Dim hpf As HttpPostedFile = hfc(k)
                If (hpf.ContentLength > 0) Then
                    'hpf.SaveAs(Server.MapPath("~/uploads/") + System.IO.Path.GetFileName(hpf.FileName))
                    Dim strFile As String = hpf.SaveFile(Server, strLocation)
                    Dim url As String = strFile.Split("|")(0)
                    Dim filename As String = strFile.Split("|")(1)
                    lstFile.Add(filename, url)
                End If
            Next
        End If

        If lstFile.Count > 0 Then
            Return lstFile
        Else
            Return Nothing
        End If

    End Function
#End Region


    ''' <summary>
    ''' Mã hóa ký tự với kiểu mã hõa TripleDes - MD5
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="toEncrypt"></param>
    ''' <returns></returns>
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Function MSA_Encrypt(ByVal toEncrypt As String, ByVal key As String) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(toEncrypt)
        Dim hashmd5 As New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        Dim tdes As New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function

    ''' <summary>
    ''' Giải mã dữ liệu đã mã hóa
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="toDecrypt"></param>
    ''' <returns></returns>
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Function MSA_Decrypt(ByVal toDecrypt As String, ByVal key As String) As String
        Dim str As String = ""
        Try
            Dim keyArray As Byte()
            toDecrypt = toDecrypt.Replace(" ", "+")
            Dim toEncryptArray As Byte() = Convert.FromBase64String(toDecrypt)

            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))

            Dim tdes As New TripleDESCryptoServiceProvider()
            tdes.Key = keyArray
            tdes.Mode = CipherMode.ECB
            tdes.Padding = PaddingMode.PKCS7
            Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
            Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
            str = UTF8Encoding.UTF8.GetString(resultArray)
        Catch ex As Exception
            str = ""
        Finally

        End Try
        Return str
    End Function

    ''' <summary>
    ''' Sinh tờ khai 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="original"></param>
    ''' <returns></returns>
    ' <System.Runtime.CompilerServices.Extension()> _
    Public Function GenTKID(ByVal N501A_SIKNO_SoTK As String, ByVal N501A_SHIKS_MaHQ As String, ByVal N501A_SINKD_NgayDK As String) As Int64
        'N501A_SINKD_NgayDK dạng yyyyMMdd
        'output: TKID dạng 3[mã hq:2][Năm DK:2]{số tờ khai vnaccs}
        Return Int64.Parse("3" & N501A_SHIKS_MaHQ.Substring(0, 2) & N501A_SINKD_NgayDK.Substring(2, 2) & N501A_SIKNO_SoTK)
    End Function

    ''' <summary>
    ''' Copy đối tượng ( ngon nhé)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="original"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CopyData(Of T As Class)(ByVal original As T) As T
        ' Đơn giản chỉ là Serialize rồi Deserialize hehe 
        Using memoryStream As New MemoryStream()
            Dim binaryFormatter As New BinaryFormatter()
            binaryFormatter.Serialize(memoryStream, original)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return DirectCast(binaryFormatter.Deserialize(memoryStream), T)
        End Using
    End Function

    Private Sub SetValueExtend(Of T)(ByVal o As T, ByVal per As PropertyInfo, ByVal value As Object)
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        If per.PropertyType Is GetType(Nullable(Of Date)) Or per.PropertyType Is GetType(Date) Then
            per.SetValue(o, Date.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Decimal)) Or per.PropertyType Is GetType(Decimal) Then
            per.SetValue(o, Decimal.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Integer)) Or per.PropertyType Is GetType(Integer) Then
            per.SetValue(o, Integer.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Int32)) Or per.PropertyType Is GetType(Int32) Then
            per.SetValue(o, Int32.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Int16)) Or per.PropertyType Is GetType(Int16) Then
            per.SetValue(o, Int16.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Short)) Or per.PropertyType Is GetType(Short) Then
            per.SetValue(o, Short.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Double)) Or per.PropertyType Is GetType(Double) Then
            per.SetValue(o, Double.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Int64)) Or per.PropertyType Is GetType(Int64) Then
            per.SetValue(o, Int64.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of Long)) Or per.PropertyType Is GetType(Long) Then
            per.SetValue(o, Long.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(Nullable(Of DateTime)) Or per.PropertyType Is GetType(DateTime) Then
            per.SetValue(o, DateTime.Parse(value), Nothing)
        ElseIf per.PropertyType Is GetType(String) Then
            per.SetValue(o, value.ToString(), Nothing)
        Else
            per.SetValue(o, Convert.ChangeType(value, per.PropertyType), Nothing)
        End If

    End Sub

    Private _ListControlName As List(Of String) = New List(Of String) _
    (New String() {"TextBox", "DropDownList", "RadioButton", "LinkButton", "CheckBox", "Label", "CodeAndList", "DatePickerExt", "NumericTextBox", "IntergerTextbox"})

    ''Bind Label of Control WebUI
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub BindDataToLabel(Of T)(ByVal uc As Control, ByVal o As T, ByVal formatDate As String)
        'Dim typeT As Type = o.GetType()
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
            'o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()

        For Each p As PropertyInfo In pis
            If p.CanRead Then
                For Each c As Control In uc.Controls.OfType(Of WebControl)()
                    Dim strType As String = c.GetType.Name
                    If strType.ToUpper() = "LABEL" Then
                        If c.ID.Remove(0, 3) = p.Name Then
                            Dim lbl As Object = p.GetValue(o, Nothing)
                            If lbl IsNot Nothing Then
                                If p.PropertyType Is GetType(Nullable(Of Date)) Or p.PropertyType Is GetType(Date) Then
                                    TryCast(c, Label).Text = Date.Parse(lbl).ToString(formatDate)
                                ElseIf p.PropertyType Is GetType(Nullable(Of DateTime)) Or p.PropertyType Is GetType(DateTime) Then
                                    TryCast(c, Label).Text = DateTime.Parse(lbl).ToString(formatDate)
                                Else
                                    TryCast(c, Label).Text = lbl.ToString()
                                End If
                            End If

                        End If
                    End If
                Next
            End If
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ValidateForm(ByVal uc As Control, ByVal isValidate As Boolean)

        For Each c As Control In uc.Controls.OfType(Of WebControl)()
            Dim strType As String = c.GetType.Name
            Select Case strType.ToUpper()
                Case "TEXTBOX"
                    TryCast(c, TextBox).CausesValidation = isValidate
                Case "DROPDOWNLIST"
                    TryCast(c, DropDownList).CausesValidation = isValidate
                Case "RADIOBUTTON"
                    TryCast(c, RadioButton).CausesValidation = isValidate
                Case "CHECKBOX"
                    TryCast(c, CheckBox).CausesValidation = isValidate
            End Select

        Next

    End Sub

    'UpdateSource of Control WebUI
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub UpdateSource(Of T)(ByVal uc As Control, ByRef o As T, ByVal toForm As Boolean)
        'Dim typeT As Type = o.GetType()
        'o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        If toForm = True Then

            For Each p As PropertyInfo In pis
                If p.CanRead Then
                    For Each c As Control In uc.Controls.OfType(Of WebControl)()
                        Dim strType As String = c.GetType.Name
                        If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                            If c.ID.Remove(0, 3) = p.Name Then
                                Select Case c.GetType().Name.ToUpper()
                                    Case "TEXTBOX"
                                        Dim txt As Object = p.GetValue(o, Nothing)
                                        If txt IsNot Nothing Then
                                            TryCast(c, TextBox).Text = txt.ToString()
                                        Else
                                            TryCast(c, TextBox).Text = String.Empty
                                        End If
                                    Case "DROPDOWNLIST"
                                        Dim ddl As Object = p.GetValue(o, Nothing)
                                        If ddl IsNot Nothing Then
                                            TryCast(c, DropDownList).SelectedValue = ddl.ToString()
                                        End If
                                    Case "RADIOBUTTON"
                                        Dim rad As Object = p.GetValue(o, Nothing)
                                        If rad IsNot Nothing Then
                                            Dim int As Decimal = Decimal.Parse(rad.ToString())
                                            If int = 1 Then
                                                TryCast(c, RadioButton).Checked = True
                                            Else
                                                TryCast(c, RadioButton).Checked = False
                                            End If
                                        End If
                                    Case "CHECKBOX"
                                        Dim chk As Object = p.GetValue(o, Nothing)
                                        If chk IsNot Nothing Then
                                            Dim int As Decimal = Decimal.Parse(chk.ToString())
                                            If int = 1 Then
                                                TryCast(c, CheckBox).Checked = True
                                            Else
                                                TryCast(c, CheckBox).Checked = False
                                            End If
                                        End If
                                    Case "LINKBUTTON"
                                        Dim lbt As Object = p.GetValue(o, Nothing)

                                        If lbt IsNot Nothing Then
                                            TryCast(c, LinkButton).Text = lbt.ToString()
                                        Else
                                            TryCast(c, LinkButton).Text = String.Empty
                                        End If

                                        'Case "CODEANDLIST"
                                        '    Dim cal As Object = p.GetValue(o, Nothing)
                                        '    If cal IsNot Nothing Then
                                        '        TryCast(c, CodeAndList).SelectedValue = cal.ToString()
                                        '    End If
                                        'Case "DATEPICKEREXT"
                                        '    Dim dpt As Object = p.GetValue(o, Nothing)
                                        '    If dpt IsNot Nothing Then
                                        '        TryCast(c, DatePickerExt).Value = Date.Parse(dpt)
                                        '    End If
                                        'Case "NUMERICTEXTBOX"
                                        '    Dim nbt As Object = p.GetValue(o, Nothing)
                                        '    If nbt IsNot Nothing Then
                                        '        TryCast(c, NumericTextBox).Value = Double.Parse(nbt)
                                        '    End If
                                        'Case "INTERGERTEXTBOX"
                                        '    Dim inb As Object = p.GetValue(o, Nothing)
                                        '    If inb IsNot Nothing Then
                                        '        TryCast(c, IntergerTextbox).Value = Integer.Parse(inb)
                                        '    End If
                                End Select
                            End If
                        End If
                    Next
                End If
            Next

            'If p.PropertyType Is GetType(Nullable(Of Decimal)) Then
            '    p.SetValue(o, Decimal.Parse((TryCast(c, NumericTextBox).Value)), Nothing)
            'Else
            '    p.SetValue(o, Convert.ChangeType(TryCast(c, NumericTextBox).Value, p.PropertyType), Nothing)
            'End If
        Else

            For Each p As PropertyInfo In pis
                If p.CanWrite Then
                    For Each c As Control In uc.Controls.OfType(Of WebControl)()
                        Dim strType As String = c.GetType.Name
                        Dim strID As String = c.ID

                        If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                            If c.ID.Remove(0, 3) = p.Name Then
                                Select Case c.GetType().Name.ToUpper()
                                    Case "TEXTBOX"
                                        If TryCast(c, TextBox).Text <> String.Empty Then

                                            SetValueExtend(Of T)(o, p, TryCast(c, TextBox).Text)
                                        End If
                                    Case "DROPDOWNLIST"

                                        If TryCast(c, DropDownList).SelectedValue <> "0" AndAlso TryCast(c, DropDownList).SelectedValue <> String.Empty Then
                                            SetValueExtend(Of T)(o, p, TryCast(c, DropDownList).SelectedValue)
                                        End If
                                    Case "RADIOBUTTON"

                                        If TryCast(c, RadioButton).Checked = True Then
                                            SetValueExtend(Of T)(o, p, 1)
                                        Else
                                            SetValueExtend(Of T)(o, p, 0)
                                        End If
                                    Case "CHECKBOX"
                                        If TryCast(c, CheckBox).Checked = True Then
                                            SetValueExtend(Of T)(o, p, 1)
                                        Else
                                            SetValueExtend(Of T)(o, p, 0)
                                        End If
                                    Case "LINKBUTTON"
                                        If TryCast(c, LinkButton).Text <> String.Empty Then

                                            SetValueExtend(Of T)(o, p, TryCast(c, LinkButton).Text)
                                        End If
                                        'Case "CODEANDLIST"
                                        '    If TryCast(c, CodeAndList).SelectedValue <> String.Empty AndAlso TryCast(c, CodeAndList).SelectedValue <> "0" Then

                                        '        SetValueExtend(Of T)(o, p, TryCast(c, CodeAndList).SelectedValue)
                                        '    End If
                                        'Case "DATEPICKEREXT"
                                        '    If TryCast(c, DatePickerExt).Value IsNot Nothing Then
                                        '        SetValueExtend(Of T)(o, p, TryCast(c, DatePickerExt).Value)
                                        '    End If

                                        'Case "NUMERICTEXTBOX"
                                        '    If TryCast(c, NumericTextBox).Value IsNot Nothing Then
                                        '        SetValueExtend(Of T)(o, p, TryCast(c, NumericTextBox).Value)
                                        '    End If
                                        'Case "INTERGERTEXTBOX"
                                        '    If TryCast(c, IntergerTextbox).Value IsNot Nothing Then
                                        '        SetValueExtend(Of T)(o, p, TryCast(c, IntergerTextbox).Value)
                                        '    End If

                                End Select
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    ''CleartALL cotrol webUI
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ClearAllForm(ByVal uc As Control)
        For Each c As Control In uc.Controls.OfType(Of WebControl)()
            Dim strType As String = c.GetType().Name
            If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                Select Case c.GetType().Name.ToUpper()
                    Case "TEXTBOX"
                        TryCast(c, TextBox).Text = ""
                    Case "DROPDOWNLIST"
                        Try
                            TryCast(c, DropDownList).SelectedValue = "0"
                        Catch ex As Exception
                            TryCast(c, DropDownList).SelectedValue = ""
                        End Try
                    Case "RADIOBUTTON"
                        TryCast(c, RadioButton).Checked = False
                    Case "CHECKBOX"
                        TryCast(c, CheckBox).Checked = False
                    Case "CODEANDLIST"
                        'Try
                        '    TryCast(c, CodeAndList).SelectedValue = "Z00Z"
                        'Catch ex As Exception
                        '    TryCast(c, CodeAndList).SelectedValue = "0"
                        'End Try
                        'Case "DATEPICKEREXT"
                        '    TryCast(c, DatePickerExt).Value = Nothing
                        'Case "NUMERICTEXTBOX"
                        '    TryCast(c, NumericTextBox).Value = Nothing
                        'Case "INTERGERTEXTBOX"
                        '    TryCast(c, IntergerTextbox).Value = Nothing
                End Select
            End If

        Next
    End Sub

    ''BindData to Label in Page
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub BindDataToLabel(Of T)(ByVal pages As Page, ByVal o As T)
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
            'o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()

        For Each p As PropertyInfo In pis
            If p.CanRead Then
                For Each css As Control In pages.Controls
                    For Each cs In css.Controls.OfType(Of WebControl)()
                        Dim strTypeName As String = cs.GetType.Name
                        If _ListControlName.Exists(Function(item) item.ToUpper() = strTypeName.ToUpper()) = True Then
                            Dim strID = cs.ID
                            If cs.ID.Remove(0, 3) = p.Name Then
                                Dim lbl As Object = p.GetValue(o, Nothing)
                                If lbl IsNot Nothing Then
                                    If p.PropertyType Is GetType(Nullable(Of Date)) Then
                                        TryCast(cs, Label).Text = Date.Parse(lbl).ToString("dd-MM-yyyy")
                                    Else
                                        TryCast(cs, Label).Text = Convert.ToString(lbl)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If
        Next

    End Sub
    ''' Clear control in Page
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ClearAllForm(ByVal pages As Page)
        For Each c As Control In pages.Controls
            For Each cs In c.Controls.OfType(Of WebControl)()
                Dim strType As String = cs.GetType.Name
                If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                    Select Case c.GetType().Name.ToUpper()
                        Case "TEXTBOX"
                            TryCast(c, TextBox).Text = ""
                        Case "DROPDOWNLIST"
                            TryCast(c, DropDownList).SelectedValue = "0"

                        Case "RADIOBUTTON"
                            TryCast(c, RadioButton).Checked = False

                        Case "CHECKBOX"
                            TryCast(c, CheckBox).Checked = False

                        Case "LABEL"
                            TryCast(c, Label).Text = ""
                            'Case "CODEANDLIST"
                            '    TryCast(c, CodeAndList).SelectedValue = "0"
                            'Case "DATEPICKEREXT"
                            '    TryCast(c, DatePickerExt).Value = Nothing
                            'Case "NUMERICTEXTBOX"
                            '    TryCast(c, NumericTextBox).Value = Nothing
                    End Select
                End If
            Next

        Next
    End Sub
    ''' Updatesource to control in Page 
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub UpdateSource(Of T)(ByVal pages As Page, ByVal o As T, ByVal toForm As Boolean)
        Dim typeT As Type = o.GetType()
        If o Is Nothing Then
            o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        If toForm = True Then

            For Each p As PropertyInfo In pis
                If p.CanRead Then
                    For Each css As Control In pages.Controls
                        For Each cs In css.Controls.OfType(Of WebControl)()
                            Dim strTypeName As String = cs.GetType.Name
                            If _ListControlName.Exists(Function(item) item.ToUpper() = strTypeName.ToUpper()) = True Then
                                Dim strID = cs.ID
                                If cs.ID.Remove(0, 3) = p.Name Then
                                    Select Case cs.GetType().Name.ToUpper()
                                        Case "TEXTBOX"
                                            Dim txt As Object = p.GetValue(o, Nothing)
                                            TryCast(cs, TextBox).Text = IIf(txt IsNot Nothing, txt.ToString, String.Empty)
                                        Case "DROPDOWNLIST"
                                            Dim ddl As Object = p.GetValue(o, Nothing)
                                            If ddl IsNot Nothing Then
                                                TryCast(cs, DropDownList).SelectedValue = ddl.ToString()
                                            End If
                                        Case "RADIOBUTTON"
                                            Dim rad As Object = p.GetValue(o, Nothing)
                                            If rad IsNot Nothing Then
                                                Dim int As Int16 = Int16.Parse(rad.ToString())
                                                TryCast(cs, RadioButton).Checked = IIf(int = 1, True, False)
                                            End If
                                        Case "CHECKBOX"
                                            Dim chk As Object = p.GetValue(o, Nothing)
                                            If chk IsNot Nothing Then
                                                Dim int As Int16 = Int16.Parse(chk.ToString())
                                                TryCast(cs, CheckBox).Checked = IIf(int = 1, True, False)
                                            End If

                                        Case "LABEL"
                                            Dim lbl As Object = p.GetValue(o, Nothing)
                                            If lbl IsNot Nothing Then
                                                If p.PropertyType.FullName = "System.Date" Then
                                                    TryCast(cs, Label).Text = Date.Parse(lbl).ToString("dd-MM-yyyy")
                                                Else
                                                    TryCast(cs, Label).Text = lbl.ToString()
                                                End If
                                            End If
                                            'Case "CODEANDLIST"
                                            '    Dim cal As Object = p.GetValue(o, Nothing)
                                            '    If cal IsNot Nothing Then
                                            '        TryCast(cs, CodeAndList).SelectedValue = cal.ToString()
                                            '    End If
                                            'Case "DATEPICKEREXT"
                                            '    Dim dpt As Object = p.GetValue(o, Nothing)
                                            '    If dpt IsNot Nothing Then
                                            '        TryCast(cs, DatePickerExt).Value = Date.Parse(dpt)
                                            '    End If
                                            'Case "NUMERICTEXTBOX"
                                            '    Dim nbt As Object = p.GetValue(o, Nothing)
                                            '    If nbt IsNot Nothing Then
                                            '        TryCast(cs, NumericTextBox).Value = Double.Parse(nbt)
                                            '    End If

                                    End Select
                                End If
                            End If
                        Next
                    Next
                End If
            Next
        Else

            For Each p As PropertyInfo In pis
                If p.CanWrite Then
                    For Each css As Control In pages.Controls
                        For Each cs In css.Controls.OfType(Of WebControl)()
                            Dim strTypeName As String = cs.GetType.Name
                            If _ListControlName.Exists(Function(item) item.ToUpper() = strTypeName.ToUpper()) = True Then

                                Dim strID = cs.ID
                                If cs.ID.Remove(0, 3) = p.Name Then
                                    Select Case cs.GetType().Name.ToUpper()
                                        Case "TEXTBOX"
                                            If TryCast(cs, TextBox).Text <> String.Empty Then
                                                p.SetValue(o, Convert.ChangeType(TryCast(cs, TextBox).Text, p.PropertyType), Nothing)
                                            End If

                                        Case "DROPDOWNLIST"
                                            p.SetValue(o, Convert.ChangeType(TryCast(cs, DropDownList).SelectedValue, p.PropertyType), Nothing)
                                        Case "RADIOBUTTON"
                                            p.SetValue(o, IIf(TryCast(cs, RadioButton).Checked = True, 1, 0), Nothing)
                                        Case "CHECKBOX"
                                            p.SetValue(o, IIf(TryCast(cs, CheckBox).Checked = True, 1, 0), Nothing)
                                        Case "LABEL"
                                            If TryCast(cs, Label).Text <> String.Empty Then
                                                p.SetValue(o, Convert.ChangeType(TryCast(cs, Label).Text, p.PropertyType), Nothing)
                                            End If
                                            'Case "CODEANDLIST"
                                            '    If TryCast(cs, CodeAndList).SelectedValue <> String.Empty Then
                                            '        p.SetValue(o, Convert.ChangeType(TryCast(cs, CodeAndList).SelectedValue, p.PropertyType), Nothing)
                                            '    End If
                                            'Case "DATEPICKEREXT"
                                            '    If TryCast(cs, DatePickerExt).Value IsNot Nothing Then
                                            '        p.SetValue(o, Convert.ChangeType(TryCast(cs, DatePickerExt).Value, p.PropertyType), Nothing)
                                            '    End If
                                            'Case "NUMERICTEXTBOX"
                                            '    If TryCast(cs, NumericTextBox).Value IsNot Nothing Then
                                            '        p.SetValue(o, Convert.ChangeType(TryCast(cs, NumericTextBox).Value, p.PropertyType), Nothing)
                                            '    End If
                                    End Select
                                End If
                            End If
                        Next
                    Next
                End If
            Next
        End If
    End Sub


    ''BindData to Label in UserControl
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub BindDataToLabel(Of T)(ByVal uc As UserControl, ByVal o As T)
        'Dim typeT As Type = o.GetType()
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
            'o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()

        For Each p As PropertyInfo In pis
            If p.CanRead Then
                For Each c As Control In uc.Controls.OfType(Of WebControl)()
                    Dim strType As String = c.GetType.Name
                    If strType.ToUpper() = "LABEL" Then
                        If c.ID.Remove(0, 3) = p.Name Then
                            Dim lbl As Object = p.GetValue(o, Nothing)
                            If lbl IsNot Nothing Then
                                If p.PropertyType Is GetType(Nullable(Of Date)) Then
                                    TryCast(c, Label).Text = Date.Parse(lbl).ToString("dd-MM-yyyy")
                                Else
                                    TryCast(c, Label).Text = lbl.ToString()
                                End If
                            End If

                        End If
                    End If
                Next
            End If
        Next
    End Sub

    ''' Clear control in Usercontrol 
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ClearAllForm(ByVal uc As UserControl)
        For Each c As Control In uc.Controls.OfType(Of WebControl)()
            Dim strType As String = c.GetType().Name
            If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                Select Case c.GetType().Name.ToUpper()
                    Case "TEXTBOX"
                        TryCast(c, TextBox).Text = ""
                    Case "DROPDOWNLIST"
                        '  TryCast(c, DropDownList).SelectedValue = "0"

                    Case "RADIOBUTTON"
                        TryCast(c, RadioButton).Checked = False

                    Case "CHECKBOX"
                        TryCast(c, CheckBox).Checked = False
                        'Case "CODEANDLIST"
                        '    'TryCast(c, CodeAndList).SelectedValue = "0"
                        'Case "DATEPICKEREXT"
                        '    TryCast(c, DatePickerExt).Value = Nothing
                        'Case "NUMERICTEXTBOX"
                        '    TryCast(c, NumericTextBox).Value = Nothing

                End Select
            End If

        Next
    End Sub
    ''' Updatesource to control in Usercontrol 
    ''' 
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub UpdateSource(Of T)(ByVal uc As UserControl, ByVal o As T, ByVal toForm As Boolean)
        'Dim typeT As Type = o.GetType()
        If o Is Nothing Then
            o = Activator.CreateInstance(Of T)()
            'o = DirectCast(typeT.GetConstructor(New Type() {}).Invoke(New Object() {}), T)
        End If
        Dim pis As List(Of PropertyInfo) = o.GetType().GetProperties().ToList()
        If toForm = True Then

            For Each p As PropertyInfo In pis
                If p.CanRead Then
                    For Each c As Control In uc.Controls.OfType(Of WebControl)()
                        Dim strType As String = c.GetType.Name
                        If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                            If c.ID.Remove(0, 3) = p.Name Then
                                Select Case c.GetType().Name.ToUpper()
                                    Case "TEXTBOX"
                                        Dim txt As Object = p.GetValue(o, Nothing)
                                        If txt IsNot Nothing Then
                                            TryCast(c, TextBox).Text = txt.ToString()
                                        Else
                                            TryCast(c, TextBox).Text = String.Empty
                                        End If

                                    Case "DROPDOWNLIST"
                                        Dim ddl As Object = p.GetValue(o, Nothing)
                                        If ddl IsNot Nothing Then
                                            TryCast(c, DropDownList).SelectedValue = ddl.ToString()
                                        End If
                                    Case "RADIOBUTTON"
                                        Dim rad As Object = p.GetValue(o, Nothing)
                                        If rad IsNot Nothing Then
                                            Dim int As Int16 = Int16.Parse(rad.ToString())
                                            TryCast(c, RadioButton).Checked = IIf(int = 1, True, False)
                                        End If
                                    Case "CHECKBOX"
                                        Dim chk As Object = p.GetValue(o, Nothing)
                                        If chk IsNot Nothing Then
                                            Dim int As Int16 = Int16.Parse(chk.ToString())
                                            TryCast(c, CheckBox).Checked = IIf(int = 1, True, False)
                                        End If

                                        'Case "LABEL"
                                        '    Dim lbl As Object = p.GetValue(o, Nothing)
                                        '    If p.PropertyType.FullName = "System.Date" Then
                                        '        TryCast(c, Label).Text = Date.Parse(lbl).ToString("dd-MM-yyyy")
                                        '    Else
                                        '        TryCast(c, Label).Text = lbl.ToString()
                                        '    End If
                                        'Case "CODEANDLIST"
                                        '    Dim cal As Object = p.GetValue(o, Nothing)
                                        '    If cal IsNot Nothing Then
                                        '        TryCast(c, CodeAndList).SelectedValue = cal.ToString()
                                        '    End If
                                        'Case "DATEPICKEREXT"
                                        '    Dim dpt As Object = p.GetValue(o, Nothing)
                                        '    If dpt IsNot Nothing Then
                                        '        TryCast(c, DatePickerExt).Value = Date.Parse(dpt)
                                        '    End If
                                        'Case "NUMERICTEXTBOX"
                                        '    Dim nbt As Object = p.GetValue(o, Nothing)
                                        '    If nbt IsNot Nothing Then
                                        '        TryCast(c, NumericTextBox).Value = Double.Parse(nbt)
                                        '    End If
                                End Select
                            End If
                        End If
                    Next
                End If
            Next
        Else

            For Each p As PropertyInfo In pis
                If p.CanWrite Then
                    For Each c As Control In uc.Controls.OfType(Of WebControl)()
                        Dim strType As String = c.GetType.Name
                        Dim strID As String = c.ID

                        If _ListControlName.Exists(Function(item) item.ToUpper() = strType.ToUpper()) = True Then
                            If c.ID.Remove(0, 3) = p.Name Then
                                Select Case c.GetType().Name.ToUpper()
                                    Case "TEXTBOX"
                                        If TryCast(c, TextBox).Text <> String.Empty Then
                                            p.SetValue(o, Convert.ChangeType(TryCast(c, TextBox).Text, p.PropertyType), Nothing)
                                        End If
                                    Case "DROPDOWNLIST"
                                        p.SetValue(o, Convert.ChangeType(TryCast(c, DropDownList).SelectedValue, p.PropertyType), Nothing)
                                    Case "RADIOBUTTON"
                                        p.SetValue(o, IIf(TryCast(c, RadioButton).Checked = True, 1, 0), Nothing)
                                    Case "CHECKBOX"
                                        p.SetValue(o, IIf(TryCast(c, CheckBox).Checked = True, 1, 0), Nothing)
                                        'Case "LABEL"
                                        '    If TryCast(c, Label).Text <> String.Empty Then
                                        '        p.SetValue(o, Convert.ChangeType(TryCast(c, Label).Text, p.PropertyType), Nothing)
                                        '    End If
                                        'Case "CODEANDLIST"
                                        '    If TryCast(c, CodeAndList).SelectedValue <> String.Empty Then
                                        '        p.SetValue(o, Convert.ChangeType(TryCast(c, CodeAndList).SelectedValue, p.PropertyType), Nothing)
                                        '    End If
                                        'Case "DATEPICKEREXT"
                                        '    If TryCast(c, DatePickerExt).Value IsNot Nothing Then
                                        '        'If p.PropertyType Is GetType(Nullable(Of Date)) Then
                                        '        '    p.SetValue(o, Date.Parse((TryCast(c, DatePickerExt).Value)), Nothing)
                                        '        'Else
                                        '        '    p.SetValue(o, Convert.ChangeType((TryCast(c, DatePickerExt).Value), p.PropertyType), Nothing)
                                        '        'End If
                                        '        SetValueExtend(Of T)(o, p, TryCast(c, DatePickerExt).Value)
                                        '    End If
                                        'Case "NUMERICTEXTBOX"
                                        '    If TryCast(c, NumericTextBox).Value IsNot Nothing Then
                                        '        If p.PropertyType Is GetType(Nullable(Of Decimal)) Then
                                        '            p.SetValue(o, Decimal.Parse((TryCast(c, NumericTextBox).Value)), Nothing)
                                        '        Else
                                        '            p.SetValue(o, Convert.ChangeType(TryCast(c, NumericTextBox).Value, p.PropertyType), Nothing)
                                        '        End If
                                        '    End If
                                End Select
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    'If per.PropertyType Is GetType(Nullable(Of Date)) Then
    '    per.SetValue(o, Decimal.Parse(value), Nothing)
    'End If
    'If per.PropertyType Is GetType(Nullable(Of Integer)) Then
    '    per.SetValue(o, Integer.Parse(value), Nothing)
    'End If
    'If per.PropertyType Is GetType(Nullable(Of Int32)) Then
    '    per.SetValue(o, Int32.Parse(value), Nothing)
    'End If
    'If per.PropertyType Is GetType(Nullable(Of Int16)) Then
    '    per.SetValue(o, Int16.Parse(value), Nothing)
    'End If
    'If per.PropertyType Is GetType(Nullable(Of Short)) Then
    '    per.SetValue(o, Short.Parse(value), Nothing)
    'End If
    'If per.PropertyType Is GetType(Nullable(Of Double)) Then
    '    per.SetValue(o, Double.Parse(value), Nothing)
    'End If

    '' Setvalue Extend 




    ''' Lấy ra giá trị của một Property
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="propertyName"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetPropertyValue(ByVal obj As Object, ByVal propertyName As String) As Object
        If obj Is Nothing Then
            Return Nothing
        End If

        Dim type As Type = obj.[GetType]()
        Dim pi As PropertyInfo = type.GetProperty(propertyName)
        Return If(pi Is Nothing, Nothing, pi.GetValue(obj, Nothing))
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetPropertyValue(Of T)(ByVal obj As Object, ByVal propertyName As String) As T
        Dim value As Object = obj.GetPropertyValue(propertyName)
        Return If(value Is Nothing, Nothing, DirectCast(value, T))
    End Function

    ''' <summary>
    ''' Thiết lập giá trị cho một Property
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="propertyName"></param>
    ''' <param name="value"></param>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SetPropertyValue(ByVal obj As Object, ByVal propertyName As String, ByVal value As Object)
        Dim pi As PropertyInfo = obj.[GetType]().GetProperty(propertyName)
        If pi IsNot Nothing AndAlso pi.CanWrite Then
            pi.SetValue(obj, value, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' Lấy ra các thuộc tính của một đối tượng
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="notIn"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetPropertiesName(ByVal obj As Object, ByVal ParamArray notIn As String()) As String()
        Return obj.[GetType]().GetProperties().Where(Function(p) Not notIn.Contains(p.Name)).[Select](Function(p) p.Name).ToArray()
    End Function

    ''' <summary>
    ''' Copy giá trị thuộc tính của đối tượng khác
    ''' </summary>
    ''' <param name="des"></param>
    ''' <param name="src"></param>
    ''' <param name="properties"></param>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub CopyPropertyValue(ByVal des As Object, ByVal src As Object, ByVal ParamArray properties As String())
        ' Đối tượng đích
        Dim typeDes As Type = des.[GetType]()
        ' Đối tượng cần copy value thuộc tính
        Dim typeSrc As Type = src.[GetType]()

        ' 
        Dim piDes As PropertyInfo = Nothing
        Dim piSrc As PropertyInfo = Nothing

        ' Nếu thỏa mãn các thuộc tính theo tên không được Null và 
        ' Thuộc tính đích phải là ghi được
        ' Thuộc tính nguồn phải là đọc được

        properties.[Select](Function(p)
                                piDes = typeDes.GetProperty(p)
                                piSrc = typeSrc.GetProperty(p)
                                If piDes IsNot Nothing AndAlso piDes.CanWrite And piSrc IsNot Nothing AndAlso piSrc.CanRead Then
                                    piDes.SetValue(des, piSrc.GetValue(src, Nothing), Nothing)
                                End If
                                Return p

                            End Function).ToArray()
    End Sub

    ''' <summary>
    ''' Lấy ra phương thức của đối tượng
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="name"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetMethod(ByVal obj As Object, ByVal name As String) As MethodInfo
        Return obj.[GetType]().GetMethod(name)
    End Function

    ''' <summary>
    '''  Lấy ra Attribute của một đối tượng
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetAttribute(Of T As Attribute)(ByVal obj As Object) As T
        Return obj.[GetType]().GetAttribute(Of T)()
    End Function

    ''' <summary>
    ''' Convert đối tượng sang kiểu khác
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function [To](Of T)(ByVal obj As Object) As T
        Return obj.[To](Of T)(Nothing)
    End Function

    ''' <summary>
    ''' Chuyển đổi dữ liệu cho một đối tượng
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="obj"></param>
    ''' <param name="default"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function [To](Of T)(ByVal obj As Object, ByVal [default] As T) As T
        If obj Is Nothing OrElse obj.Equals(DBNull.Value) Then
            Return [default]
        End If

        Return DirectCast(Convert.ChangeType(obj, GetType(T)), T)
    End Function

    ''' <summary>
    ''' Kiểm tra xem một đối tượng có Null hay không
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsNull(ByVal obj As Object) As Boolean
        Return obj Is Nothing OrElse obj.Equals(DBNull.Value)
    End Function

    ''' <summary>
    ''' Cast object to T
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function [As](Of T)(ByVal obj As Object) As T
        Return DirectCast(obj, T)
    End Function

    ''' <summary>
    ''' Serialize object to bytes
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToBytes(ByVal obj As Object) As Byte()
        ' trả ra null nếu rỗng
        If obj Is Nothing Then
            Return Nothing
        End If

        ' Serialize
        Dim bf As New BinaryFormatter()
        Using ms As New MemoryStream()
            bf.Serialize(ms, obj)
            Return ms.ToArray()
        End Using
    End Function

    ''' <summary>
    ''' Copy nội dung từ t2 sang t
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="t"></param>
    ''' <param name="t2"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub CopyFrom(Of T)(ByVal t1 As T, ByVal t2 As T)
        ' Lấy các thuộc tính mà vừa đọc và vừa ghi được
        Dim pis As PropertyInfo() = GetType(T).GetProperties().Where(Function(p) p.CanRead AndAlso p.CanWrite).ToArray()

        ' Copy nội dung sang
        ' Lấy giá trị từ t2, Gán cho giá trị ở t
        pis.[Select](Function(p)
                         p.SetValue(t1, p.GetValue(t2, Nothing), Nothing)
                         Return p

                     End Function).ToArray()
    End Sub
End Module
