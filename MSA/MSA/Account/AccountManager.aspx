<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountManager.aspx.vb" Inherits="MSA.AccountManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <br />
        <div class="form-horizontal">
            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">THÀNH VIÊN</legend>
                 <div class="form-group">
                    <label class="col-md-2 control-label">Tìm kiếm</label>
                    <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-md-3 col-md-push-1">
                        <asp:DropDownList ID="ddlDieuKien" runat="server"  CssClass="form-control" OnTextChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="">Mã</asp:ListItem>
                            <asp:ListItem Value="1">Tên</asp:ListItem>
                            <asp:ListItem Value="2">Gói</asp:ListItem>
                            <asp:ListItem Value="3">Mã BT</asp:ListItem>
                            <asp:ListItem Value="4">Tên BT</asp:ListItem>
                            <asp:ListItem Value="5">Mã CĐ</asp:ListItem>
                            <asp:ListItem Value="5">Nhánh</asp:ListItem>
                            <asp:ListItem Value="6">SĐT</asp:ListItem>
                            <asp:ListItem Value="7">Email</asp:ListItem>
                            <asp:ListItem Value="8">STK</asp:ListItem>
                            <asp:ListItem Value="9">Ngân hàng</asp:ListItem>
                            <asp:ListItem Value="10">Ngày ĐK</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-2 col-md-push-1">
                         <asp:Button ID="btnSearch" runat="server" Text="TÌM" CssClass="btn-danger form-control" OnClick="btnSearch_Click" />
                     </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">MÃ SỐ THÀNH VIÊN</legend>
            </fieldset>
    </div>
</asp:Content>
