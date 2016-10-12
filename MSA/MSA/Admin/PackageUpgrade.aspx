<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="PackageUpgrade.aspx.vb" Inherits="MSA.PackageUpgrade" %>

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
                <legend class="fdb-scheduler-border">NÂNG CẤP GÓI</legend>

                <asp:HiddenField ID="hidMA_CAY" runat="server" />

                <div class="form-group">
                    <label class="col-md-3 control-label">Mã khách hàng</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtMA_KH" runat="server" CssClass="form-control"  ValidationGroup="packageupgrade" />
                        <asp:RequiredFieldValidator ErrorMessage="Mã khách hàng không được để trống" ControlToValidate="txtMA_KH" runat="server" ForeColor="#cc0066" Text="Mã khách hàng không được để trống" Display="Dynamic" ValidationGroup="packageupgrade" />
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="btnCheckMA_KH" runat="server" CssClass="btn btn-info" Text="Kiểm tra" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3 control-label">Họ và tên</label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtTEN" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3 control-label">Gói đầu tư hiện tại</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlGOI_DAU_TU_HIEN_TAI" CssClass="form-control" ForeColor="#464646" Font-Bold="True" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">KHỞI ĐỘNG - 2TR </asp:ListItem>
                            <asp:ListItem Value="2">KINH DOANH - 6TR </asp:ListItem>
                            <asp:ListItem Value="3">CHUYÊN NGHIỆP - 12TR </asp:ListItem>
                            <asp:ListItem Value="4">KIM CƯƠNG - 24TR </asp:ListItem>
                            <asp:ListItem Value="5">CHỦ TỊCH - 36TR </asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ErrorMessage="Gói đầu tư không được để trống" ControlToValidate="ddlGOI_DAU_TU_HIEN_TAI" runat="server" ForeColor="#cc0066" Text="Gói đầu tư không được để trống" Display="Dynamic" ValidationGroup="packageupgrade" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3 control-label">Gói đầu tư nâng cấp</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlGOI_DAU_TU_NANG_CAP" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ValidationGroup="packageupgrade">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">KHỞI ĐỘNG - 2TR </asp:ListItem>
                            <asp:ListItem Value="2">KINH DOANH - 6TR </asp:ListItem>
                            <asp:ListItem Value="3">CHUYÊN NGHIỆP - 12TR </asp:ListItem>
                            <asp:ListItem Value="4">KIM CƯƠNG - 24TR </asp:ListItem>
                            <asp:ListItem Value="5">CHỦ TỊCH - 36TR </asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ErrorMessage="Gói đầu tư không được để trống" ControlToValidate="ddlGOI_DAU_TU_NANG_CAP" runat="server" ForeColor="#cc0066" Text="Gói đầu tư không được để trống" Display="Dynamic" ValidationGroup="packageupgrade" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3 control-label">Ghi chú</label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="txtGHI_CHU" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ValidationGroup="packageupgrade" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-3 col-md-2">
                        <asp:Button ID="btnUpgrade" runat="server" Text="Cập nhật" CssClass="btn-info form-control" ValidationGroup="packageupgrade" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-3">
                        <asp:Label ID="lblMsgPackageUpgrade" runat="server" Visible="false" CssClass="text-warning"></asp:Label>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
