<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="Register.aspx.vb" Inherits="MSA.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="pnForm">
        <fieldset class="fdb-scheduler-border">
            <div class="row">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label runat="server" ID="lblMessages" ForeColor="Blue" Font-Bold="true"> <br />    
                                                        </asp:Label>
                <br />
                <asp:Label runat="server" ID="lblMessages2" ForeColor="Blue" Font-Bold="true"> <br />    
                </asp:Label>
                <asp:Label runat="server" ID="lblMaKHMOI" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                <br />
                <div class="row">
                    Đường link đăng ký tài khoản: <asp:LinkButton ID="lblLink" runat="server"></asp:LinkButton> 
                </div>

                <div class="row">
                    <label class="col-md-3 control-label">Họ tên:</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtTEN" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Tên người tham gia không được để trống" ControlToValidate="txtTEN" runat="server" ForeColor="#cc0066" Text="Tên người tham gia không được để trống" Display="Dynamic" />
                    </div>
                </div>

                <div class="row">
                    <label class="col-md-3 control-label">Số điện thoại:</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtDIEN_THOAI" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Số điện thoại không được để trống" ControlToValidate="txtDIEN_THOAI" runat="server" ForeColor="#cc0066" Text="Số điện thoại không được để trống" Display="Dynamic" />
                    </div>
                </div>

                <div class="row">
                    <label class="col-md-3 control-label" for="Email">Email:</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtDIA_CHI" runat="server" class="form-control" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="txtDIA_CHI" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <label class="col-md-3 control-label">Mật khẩu:</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtMAT_KHAU" runat="server" TextMode="Password" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtMAT_KHAU" runat="server" ForeColor="#cc0066" Text="Mật khẩu không được để trống." Display="Dynamic" />
                    </div>
                </div>

                <div class="row">
                    <label class="col-md-3 control-label" for="ConfirmPassword">Xác nhận mật khẩu:</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="Xác nhận mật khẩu không được để trống" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" Text="Xác nhận mật khẩu không được để trống" Display="Dynamic" />
                        <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtMAT_KHAU" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator>
                    </div>
                </div>
            </div>
        </fieldset>
        <br />
        <div class="row">
            <div class="col-md-offset-3 col-md-8">
                <asp:CheckBox runat="server" CssClass="check alert-danger" ID="chkNV" Text="Nhân viên LIFE BETTER" ForeColor="Red" Visible="false" /><br />
                <asp:Button ID="btnSubmit" runat="server" Text="Register member" class="btn btn-info" Style="border: 2px solid #FFF;" />
            </div>

        </div>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>

</asp:Content>
