<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="ActiveUsers.aspx.vb" Inherits="MSA.ActiveUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-body">
        <div class="form">
            <div class="form-group col-lg-12">
                <asp:Label runat="server" ID="lblError" ForeColor="#cc0066" Font-Bold="True"></asp:Label>
                <br />
                <label for="firstname" class="control-label col-lg-2">Mã khách hàng</label>
                <div class="col-lg-6">
                    <asp:TextBox runat="server" ID="txtMa_KH" CssClass="form-control" ForeColor="#464646" Font-Bold="True" placeholder="Mã khách hàng"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Button runat="server" class="btn btn-info" ID="btnSearch" Text="TÌM KIẾM" CausesValidation="false" />
                </div>
            </div>

            <br />  
            <br />

            <asp:Panel runat="server" ID="pnDetail">
                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">Họ và tên</label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtTEN" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">CMND</label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtCMND" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">Điện thoại</label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtDIEN_THOAI" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <br />

                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">Gói đầu tư</label>
                    <div class="col-lg-6">
                        <asp:DropDownList runat="server" ID="lstGOI_DAU_TU" Tex="KHỞI ĐỘNG - 2TR" CssClass="form-control col-md-6" ForeColor="#464646" Font-Bold="True">
                            <asp:ListItem>KHỞI ĐỘNG - 2TR </asp:ListItem>
                            <asp:ListItem>KINH DOANH - 6TR </asp:ListItem>
                            <asp:ListItem>CHUYÊN NGHIỆP - 12TR </asp:ListItem>
                            <asp:ListItem>KIM CƯƠNG - 24TR </asp:ListItem>
                            <asp:ListItem>CHỦ TỊCH - 36TR </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />

                <div class="form-group col-lg-12" >
                    <label for="firstname" class="control-label col-lg-2">Mã bảo trợ</label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtBaoTro" CssClass="form-control" ForeColor="#464646" Font-Bold="True" Visible="True"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" class="btn btn-info" ID="btnCheckBaoTro" Text="KIỂM TRA" CausesValidation="false" Visible="True" />
                    </div>
                </div>

                <br />

                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2"></label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtTEN_BAO_TRO" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtMA_BAO_TRO" CssClass="form-control" ForeColor="#464646" Font-Bold="True" Visible="false"></asp:TextBox>
                    </div>

                </div>
                               
                <br />
                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">Mã người chỉ định</label>
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtUPLINE" CssClass="form-control" ForeColor="#464646" Font-Bold="True"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" class="btn btn-info" ID="btnSearchUpline" Text="KIỂM TRA" CausesValidation="false" />
                    </div>
                </div>

                <br />



                <div class="form-group col-lg-12">
                    <div class="col-lg-6">
                        <asp:TextBox runat="server" ID="txtTEN_UPLINE" CssClass="form-control" ForeColor="#464646" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtMA_UPLINE" CssClass="form-control" ForeColor="#464646" Font-Bold="True" Visible="false"></asp:TextBox>
                    </div>

                </div>
                <br />

                <div class="form-group col-lg-12">
                    <label for="firstname" class="control-label col-lg-2">Vị trí chỉ định</label>
                    <div class="col-lg-6">
                        <asp:DropDownList runat="server" ID="lstVITRI" Tex="TRÁI" CssClass="form-control col-md-6" ForeColor="#464646" Font-Bold="True" Visible="false">
                            <asp:ListItem>TRÁI </asp:ListItem>
                            <asp:ListItem>PHẢI </asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <br />

                <div class="form-group col-lg-12">

                    <div class="col-lg-6">
                        <asp:Button runat="server" class="btn btn-info" ID="btnKichHoat" Text="KÍCH HOẠT" CausesValidation="false" />
                    </div>
                </div>
                <br />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
