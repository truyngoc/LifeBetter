<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MSA.Master" CodeBehind="ViewAccountDetail.aspx.vb" Inherits="MSA.ViewAccountDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
        <div class="form-horizontal">
            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">DANH HIỆU</legend>
                 <div class="form-group">
                    <label class="col-md-2 control-label">Tên danh hiệu</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlDanhHieu" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">KIM CƯƠNG</asp:ListItem>
                            <asp:ListItem Value="2">CHỦ TỊCH</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-3 col-md-push-1">
                        <asp:DropDownList ID="ddlDanhHieu_THANG" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-2 col-md-push-1">
                         <asp:Button ID="btnSearchDanhHieu" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                     </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">DOANH SỐ</legend>
                <div class="form-group">
                    <label class="col-md-2 control-label">Trái</label>
                    <div class="col-md-1" style="padding-right:0;">                        
                        <asp:DropDownList ID="ddlToanTuTrai" runat="server"  CssClass="form-control">
                            <asp:ListItem Value=">" Text=">"></asp:ListItem>
                            <asp:ListItem Value="<"><</asp:ListItem>
                            <asp:ListItem Value="=">=</asp:ListItem>
                            <asp:ListItem Value=">=">>=</asp:ListItem>
                            <asp:ListItem Value="<="><=</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2" style="padding-left:0">
                        <asp:TextBox ID="txtDoanhSoTrai" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-md-3 col-md-push-1">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-2 col-md-push-1">
                         <asp:Button ID="Button1" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                     </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">ĐỜI BẢO TRỢ</legend>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">NGÀY THAM GIA</legend>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">MÃ SỐ THÀNH VIÊN</legend>
            </fieldset>
        </div>
    </div>
</asp:Content>
