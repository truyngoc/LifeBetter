<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountReport.aspx.vb" Inherits="MSA.AccountReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .mydatagrid {
            width: 100%;
            border: solid 1px black;
            /*min-width: 80%;*/
        }

            .mydatagrid .header {
                /*background-color: #646464;*/
                /*background-color: #ff0c0c;*/
                background-color: #036299;
                font-family: Arial;
                color: White;
                /*border: none 0px transparent;*/
                border: 1px solid #000;
                height: 25px;
                text-align: center;
                font-size: 16px;
                vertical-align: top;
            }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            /*border: none 0px transparent;*/
            border: 1px solid #000;
        }

            .rows:hover {
                background-color: #ff8000;
                font-family: Arial;
                color: #fff;
                text-align: left;
            }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid .pager span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }
    </style>

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
    
    <div class="form-horizontal">
        <br />
        <fieldset class="fdb-scheduler-border">
            <legend class="fdb-scheduler-border">BÁO CÁO THÀNH VIÊN</legend>
            <asp:Label ID="lblError" runat="server" CssClass="has-error"></asp:Label>
            <div class="form-group">
                <label class="col-md-2 control-label">Tìm kiếm</label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlDieuKien" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1" Text="">Mã khách hàng</asp:ListItem>
                        <asp:ListItem Value="2">Tên khách hàng</asp:ListItem>
                        <asp:ListItem Value="3">Gói tham gia</asp:ListItem>
                        <asp:ListItem Value="4">Mã bảo trợ</asp:ListItem>
                        <asp:ListItem Value="5">Số CMND</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-md-push-1">
                    <asp:Button ID="btnSearch" runat="server" Text="TÌM" CssClass="btn-danger form-control" OnClick="btnSearch_Click" />
                </div>

            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Thời gian</label>
                <div class="col-md-3">
                    <asp:DropDownList ID="dllHOA_HONG_THANG" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlTrangThai" runat="server" CssClass="form-control">
                        <asp:ListItem Value="5" Text="">Tất cả</asp:ListItem>
                        <asp:ListItem Value="1">Kích hoạt</asp:ListItem>
                        <asp:ListItem Value="0">Chưa kích hoạt</asp:ListItem>
                        <asp:ListItem Value="3">Hủy mã số</asp:ListItem>
                        <asp:ListItem Value="2">Được công ty hỗ trợ</asp:ListItem>                        
                    </asp:DropDownList>
                </div>
            </div>
        </fieldset>

        <fieldset class="fdb-scheduler-border">
            <div class="row">
                <asp:Label ID="lblMsgInfo" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                <asp:GridView ID="grdMEMBERS" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                    AutoGenerateColumns="false" AllowPaging="true" PageSize="50"
                    OnPageIndexChanging="grdMEMBERS_PageIndexChanging" OnRowCommand="grdMEMBERS_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MÃ KH" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMa_KH" runat="server" Text='<%# Eval("MA_KH")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TÊN" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblTen" runat="server" Text='<%# Eval("TEN") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="GÓI" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblGoi" runat="server" Text='<%# LoadGoiDauTu(Eval("MA_GOI_DAU_TU"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Danh hiệu" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblDanhHieu" runat="server" Text='<%# LoadDanhHieu(Eval("MA_DANH_HIEU"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mã BT" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblBT" runat="server" Text='<%# Eval("MA_BAO_TRO")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tên BT" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblTBT" runat="server" Text='<%# Eval("TEN_BAO_TRO")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mã tuyến trên" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCD" runat="server" Text='<%# Eval("MA_CAY_TT")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tên tuyến trên" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblTCD" runat="server" Text='<%# Eval("TEN_CAY_TT")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CMND" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCMND" runat="server" Text='<%# Eval("CMND")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ngày sinh" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblNGAY_SINH" runat="server" Text='<%# Eval("NGAY_SINH")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Điện thoại" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("DIEN_THOAI")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("DIA_CHI")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mã số thuế" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMST" runat="server" Text='<%# Eval("MST")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Số tài khoản" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSTK" runat="server" Text='<%# Eval("SO_TAI_KHOAN")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ngân hàng" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblNganHang" runat="server" Text='<%# Eval("NGAN_HANG") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ngày tham gia" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("NGAY_THAM_GIA", "{0:dd/MM/yyyy HH:mm:ss}")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ngày nâng cấp" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblUpdateDate" runat="server" Text='<%# Eval("NGAY_NANG_CAP" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEdit" runat="server" CausesValidation="false" CommandName="cmdEdit"
                                    CommandArgument='<%# Eval("MA_KH")%>' ImageUrl="/Images/edit-icon.png" ToolTip="Edit" Width="16" Height="16" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="false" CommandName="cmdDelete"
                                    CommandArgument='<%# Eval("ID")%>' ImageUrl="/Images/delete-icon.png" ToolTip="Delete" Width="16" Height="16"
                                    OnClientClick="return confirm('Are you sure you want delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnLock" runat="server" CausesValidation="false" CommandName="cmdLock"
                                    CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/key-icon.png" ToolTip="Lock account" Width="16" Height="16"
                                    OnClientClick="return confirm('Are you sure you want lock account ?');" Visible='<%# VisibleByStatus(Eval("TRANG_THAI"),1)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnUnLock" runat="server" CausesValidation="false" CommandName="cmdUnLock"
                                    CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/unlock_icon.jpg" ToolTip="UnLock account" Width="16" Height="16"
                                    OnClientClick="return confirm('Are you sure you want unlock account ?');" Visible='<%# VisibleByStatus(Eval("TRANG_THAI"),2)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>
    </div>
</asp:Content>
