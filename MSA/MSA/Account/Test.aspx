<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="MSA.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButton runat="server" ID="rdGoi1" groupname="goiThamGia" Text="Khởi động: 2tr"/>
        <asp:RadioButton runat="server" ID="rdGoi2" groupname="goiThamGia" Text="Chủ tịch: 36tr"/>
        <br />
        <asp:TextBox runat="server" ID="txtSoLuongTang" placeholder="Số lượng tầng"></asp:TextBox>
        <br />
        <asp:TextBox runat="server" ID="txtTongNhanhTrai" placeholder="Tổng Nhánh Trái"></asp:TextBox>
        <br />
        <asp:TextBox runat="server" ID="txtTongNhanhPhai" placeholder="Tổng nhánh phải"></asp:TextBox>
        <asp:Button runat="server" ID="btnCreateUsers" Text="Tạo tài khoản tự động" />

    </div>
    </form>
</body>
</html>
