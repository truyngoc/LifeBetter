Imports Dapper
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Program
    '  Implements IContactRepository

    Shared db As IDbConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)
    Private Shared Sub Main(args As String())
        '#Region "Get All Data()"
        ' Program p = new Program();
        'StringBuilder sb = new StringBuilder();
        'foreach (Contact contact in p.GetAll())
        '{
        '    sb.Append("Name : " + contact.FirstName + " " + contact.LastName);
        '    sb.AppendLine();
        '    sb.Append("Email : " + contact.Email);
        '    sb.AppendLine();

        '}
        ' Console.WriteLine(sb.ToString());
        '#End Region

        '#Region "Get data based on id"
        'StringBuilder sb = new StringBuilder();
        'Program p = new Program();
        'Console.Write("Enter Contact ID : ");
        'Contact contact = p.Find(Convert.ToInt32(Console.ReadLine()));
        'sb.Append("Name : " + contact.FirstName + " " + contact.LastName);
        'sb.AppendLine();
        'sb.Append("Email : " + contact.Email);
        'sb.AppendLine();
        'Console.WriteLine(sb.ToString());
        '#End Region

        '#Region "Update Firstname"
        'Program p = new Program();
        'Console.WriteLine("Contact Updated with ID : {0} ", p.Update(new Contact {Id= 1 , FirstName = "Updatefname" , LastName = "updatelname"}).Id);
        '#End Region

        '#Region "Delete Record"
        'Program p = new Program();
        'Console.Write("Enter ID to be deleted ");
        'int id = Convert.ToInt32(Console.ReadLine());
        'p.Remove(id);
        'Console.WriteLine("Record Deleted With ID {0}" ,id );
        '#End Region

        '#Region "Insert Single Object To Database"
        'Contact c = new Contact();
        'Program p = new Program();
        'Console.WriteLine("Enter First Name : ");
        'c.FirstName = Console.ReadLine();
        'Console.WriteLine("Enter Last Name : ");
        'c.LastName = Console.ReadLine();
        'Console.WriteLine("Enter Email Address : ");
        'c.Email = Console.ReadLine();
        'Console.WriteLine("Enter Company Name: ");
        'c.Company = Console.ReadLine();
        'Console.WriteLine("Enter Title : ");
        'c.Title = Console.ReadLine();
        'Console.WriteLine( "New Contact Created With ID {0} ", p.Add(c).Id);
        '#End Region

        '#Region "Get multiple Table data"
        'Program p = new Program();
        'Contact c = p.GetFullContact(1);
        'Console.WriteLine("Name  : {0} ", c.FirstName + c.LastName);
        'foreach(Address ad in c.Addresses)
        '    Console.WriteLine("Address : {0}" , ad.StreetAddress +"  " + ad.City + "  "+ ad.AddressType);
        'Console.WriteLine("Email Address {0}", c.Email);
        '#End Region

        '#Region "Get multiple Table data"
        'Program p = new Program();
        'Contact c = p.GetFullContactBySp(1);
        'Console.WriteLine("Name  : {0} ", c.FirstName + c.LastName);
        'foreach (Address ad in c.Addresses)
        '    Console.WriteLine("Address : {0}", ad.StreetAddress + "  " + ad.City + "  " + ad.AddressType);
        'Console.WriteLine("Email Address {0}", c.Email);
        '#End Region

        '#Region "Insert Dynamic Object To Database"
        'dynamic c = new Contact();
        'Program p = new Program();
        'Console.WriteLine("Enter First Name : ");
        'c.FirstName = Console.ReadLine();
        'Console.WriteLine("Enter Last Name : ");
        'c.LastName = Console.ReadLine();
        'Console.WriteLine("Enter Email Address : ");
        'c.Email = Console.ReadLine();
        'Console.WriteLine("Enter Company Name: ");
        'c.Company = Console.ReadLine();
        'Console.WriteLine("Enter Title : ");
        'c.Title = Console.ReadLine();
        'Console.WriteLine("New Contact Created With ID {0} ", p.dynamicspcall(c).Id);
        '#End Region

        Console.ReadLine()
    End Sub
    Public Function dynamicspcall(con As Contact) As Contact
        Dim parameter = New DynamicParameters()
        parameter.Add("@Id", con.Id, dbType:=DbType.Int32, direction:=ParameterDirection.InputOutput)
        parameter.Add("@FirstName", con.FirstName)
        parameter.Add("@LastName", con.LastName)
        parameter.Add("@Company", con.Company)
        parameter.Add("@Title", con.Title)
        parameter.Add("@Email", con.Email)

        db.Execute("SaveContact", parameter, commandType:=CommandType.StoredProcedure)
        'To get new created ID back
        con.Id = parameter.[Get](Of Integer)("@Id")
        Return con

    End Function
    Public Function GetFullContactBySp(id As Integer) As Contact
        Using multipleresult = db.QueryMultiple("sp_GetContact_Address", New With { _
            Key .id = id _
        }, commandType:=CommandType.StoredProcedure)
            Dim contact = multipleresult.Read(Of Contact)().SingleOrDefault()
            Dim Addresses = multipleresult.Read(Of Address)().ToList()
            If contact IsNot Nothing AndAlso Addresses IsNot Nothing Then
                contact.Addresses.AddRange(Addresses)
            End If
            Return contact
        End Using

    End Function
    Public Function GetFullContact(id As Integer) As Contact
        Dim query As String = "select * from contacts where id = @id ; select * from addresses where ContactId = @id;"
        Using multipleresult = db.QueryMultiple(query, New With { _
            Key .id = id _
        })
            Dim contact = multipleresult.Read(Of Contact)().SingleOrDefault()
            Dim Addresses = multipleresult.Read(Of Address)().ToList()
            If contact IsNot Nothing AndAlso Addresses IsNot Nothing Then
                contact.Addresses.AddRange(Addresses)
            End If
            Return contact
        End Using

    End Function
    Public Function Add(contact As Contact) As Contact
        Dim query As String = "Insert into contacts values (@FirstName , @LastName, @Email , @Company , @Title);" & vbCr & vbLf & "            select Cast(Scope_Identity() as int)"
        Dim id As Integer = db.Query(Of Integer)(query, contact).[Single]()
        contact.Id = id
        Return contact
    End Function
    Public Function GetAll() As System.Collections.Generic.List(Of Contact)
        Dim query As String = "select * from contacts"
        Return DirectCast(db.Query(Of Contact)(query), List(Of Contact))
    End Function
    Public Function Find(id As Integer) As Contact
        Dim query As String = "select * from contacts where id = @id"
        Return DirectCast(db.Query(Of Contact)(query, New With { _
            Key .id = id _
        }).SingleOrDefault(), Contact)
    End Function
    Public Function Update(contact As Contact) As Contact
        Dim query As String = "update contacts set FirstName = '" + contact.FirstName + "' , LastName = '" + contact.LastName + "' where id = @id"
        Dim i As Integer = db.Execute(query, New With { _
            Key .id = contact.Id _
        })
        contact.Id = i
        Return contact
    End Function
    Public Sub Remove(id As Integer)
        Dim query As String = "delete from contacts where id = @id"
        Dim i As Integer = db.Execute(query, New With { _
            Key .id = id _
        })
    End Sub

End Class