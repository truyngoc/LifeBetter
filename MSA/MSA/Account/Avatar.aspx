<%@ Page Language="vb" MasterPageFile="~/Admin/MSA_Admin.Master" AutoEventWireup="false" CodeBehind="Avatar.aspx.vb" Inherits="MSA.Avatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* style cho fieldset */
        fieldset.fdb-scheduler-border {
            /*border: 1px solid #dddddd;*/
            padding: 0 1.4em 1.4em 1.4em !important;
            /*margin: 0 0 1.5em 0 !important;*/
            -webkit-box-shadow: 0px 0px 0px 0px #000;
            box-shadow: 0px 0px 0px 0px #000;
        }

        legend.fdb-scheduler-border {
            font-size: 16px;
            text-align: left !important;
            /*width: auto;*/
            /*padding: 0 10px;*/
            /*border-bottom: none;*/
            margin-bottom: 15px;
            color: #006bc1;
            font-weight: bold;
        }
    </style>

    <div class="container">
        <br />
        <div class="form-horizontal">
            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">HÌNH ĐẠI DIỆN</legend>
                <div class="form-group">
                    <label class="col-md-3 control-label">Đổi hình đại diện</label>
                    <div class="col-md-4">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" ValidationGroup="avatar" />
                        <asp:RequiredFieldValidator ErrorMessage="Bạn phải chọn ảnh đại diện." ControlToValidate="FileUpload1" runat="server" ForeColor="#cc0066" Text="Bạn phải chọn ảnh đại diện." Display="Dynamic" ValidationGroup="avatar" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-2">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn-info form-control" ValidationGroup="avatar" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3">
                        <asp:Label ID="lblMsgAvatar" runat="server" Visible="false" CssClass="text-warning"></asp:Label>
                    </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">THAY ĐỔI MẬT KHẨU</legend>
                <div class="form-group">
                    <label class="col-md-3 control-label">Mật khẩu hiện tại</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtCurrentPwd" runat="server" CssClass="form-control" type="password" ValidationGroup="changepass" />
                        <asp:RequiredFieldValidator ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtCurrentPwd" runat="server" ForeColor="#cc0066" Text="Mật khẩu không được để trống." Display="Dynamic" ValidationGroup="changepass" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Mật khẩu mới</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtNewPwd" runat="server" CssClass="form-control" type="password" ValidationGroup="changepass" />
                        <asp:RequiredFieldValidator ErrorMessage="Mật khẩu mới không được để trống." ControlToValidate="txtNewPwd" runat="server" ForeColor="#cc0066" Text="Mật khẩu mới không được để trống." Display="Dynamic" ValidationGroup="changepass" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Xác nhận lại mật khẩu</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtConfirmNewPwd" runat="server" CssClass="form-control" type="password" ValidationGroup="changepass" />
                        <asp:RequiredFieldValidator ErrorMessage="Xác nhận mật khẩu mới không được để trống." ControlToValidate="txtConfirmNewPwd" runat="server" ForeColor="#cc0066" Text="Xác nhận mật khẩu mới không được để trống." Display="Dynamic" ValidationGroup="changepass" />
                        <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmNewPwd" runat="server" ForeColor="#cc0066" ErrorMessage="Xác nhận mật khẩu không đúng" ValidationGroup="changepass"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-2">
                        <asp:Button ID="btnChangePwd" runat="server" Text="Cập nhật" CssClass="btn-info form-control" ValidationGroup="changepass" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3">
                        <asp:Label ID="lblMsgChangePass" runat="server" Visible="false"  CssClass="text-warning"></asp:Label>
                    </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">SỬA THÔNG TIN CÁ NHÂN</legend>
                <div class="form-group">
                    <label class="col-md-3 control-label">Email</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="profile" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="txtEmail" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="Dynamic" ValidationGroup="profile"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Điện thoại</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDIEN_THOAI" runat="server" CssClass="form-control" ValidationGroup="profile" />
                        <asp:RequiredFieldValidator ErrorMessage="Số điện thoại không được để trống" ControlToValidate="txtDIEN_THOAI" runat="server" ForeColor="#cc0066" Text="Số điện thoại không được để trống" Display="Dynamic" ValidationGroup="profile" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Số tài khoản</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtSO_TAI_KHOAN" runat="server" CssClass="form-control" ValidationGroup="profile" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Ngân hàng</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtNGAN_HANG" runat="server" CssClass="form-control" ValidationGroup="profile" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-2">
                        <asp:Button ID="btnUpdateProfile" runat="server" Text="Cập nhật" CssClass="btn-info form-control" ValidationGroup="profile" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3">
                        <asp:Label ID="lblMsgUpdateProfile" runat="server" Visible="false" CssClass="text-warning"></asp:Label>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
