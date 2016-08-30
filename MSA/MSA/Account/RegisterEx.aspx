<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="RegisterEx.aspx.vb" Inherits="MSA.RegisterEx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <div class="page-header">
        <h1>Account
			<small>
                <i class="ace-icon fa fa-angle-double-right"></i>
                Sign up
            </small>
        </h1>
    </div>--%>

    <asp:Panel runat="server" ID="pnForm">
        <fieldset class="fdb-scheduler-border">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessages" ForeColor="Blue"></asp:Label>
            <br />
            <br />

            <div class="form-group">
                <label class="col-md-2 control-label">Họ tên:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtTEN" runat="server" class="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Tên người tham gia không được để trống" ControlToValidate="txtTEN" runat="server" ForeColor="#cc0066" Text="Tên người tham gia không được để trống" Display="Dynamic" />
                    <br />
                </div>
            </div>
            <br />
            <br />

                <div class="form-group">
                <label class="col-md-2 control-label">Số điện thoại:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtDIEN_THOAI" runat="server" class="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Số điện thoại không được để trống" ControlToValidate="txtDIEN_THOAI" runat="server" ForeColor="#cc0066" Text="Số điện thoại không được để trống" Display="Dynamic" />
                    <br />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <label class="col-md-2 control-label" for="Email">Email:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtDIA_CHI" runat="server" class="form-control" />
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="txtDIA_CHI" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>
            <br />
            <br />

             <div class="form-group">
                <label class="col-md-2 control-label">Tài khoản:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtSO_TAI_KHOAN" runat="server" class="form-control" />
                    <br />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <label class="col-md-2 control-label"">Ngân hàng:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtNGAN_HANG" runat="server" class="form-control" />
                    <br />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <label class="col-md-2 control-label">Mật khẩu:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtMAT_KHAU" runat="server" TextMode="Password" class="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtMAT_KHAU" runat="server" ForeColor="#cc0066" Text="Mật khẩu không được để trống." Display="Dynamic" />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <label class="col-md-2 control-label" for="ConfirmPassword">Xác nhận mật khẩu:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Xác nhận mật khẩu không được để trống" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" Text="Xác nhận mật khẩu không được để trống" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtMAT_KHAU" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator>
                </div>
            </div>
            <br />
            <br />


            <br />
            <br />



        
        </fieldset>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnSubmit" runat="server" Text="Register member" class="btn btn-info" Style="border: 2px solid #FFF;" />
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>

</asp:Content>