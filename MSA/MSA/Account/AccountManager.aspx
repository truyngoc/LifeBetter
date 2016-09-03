<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountManager.aspx.vb" Inherits="MSA.AccountManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="form-horizontal">
        <fieldset class="fdb-scheduler-border">
            <legend class="fdb-scheduler-border">THÀNH VIÊN</legend>
            <asp:Label ID="lblError" runat="server" CssClass="has-error"></asp:Label>
            <div class="form-group">
                <label class="col-md-2 control-label">Tìm kiếm</label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 col-md-push-1">
                    <asp:DropDownList ID="ddlDieuKien" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDieuKien_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="">Mã khách hàng</asp:ListItem>
                        <asp:ListItem Value="1">Tên khách hàng</asp:ListItem>
                        <asp:ListItem Value="2">Gói tham gia</asp:ListItem>
                        <asp:ListItem Value="3">Mã bảo trợ</asp:ListItem>
                        <asp:ListItem Value="4">Tên người bảo trợ</asp:ListItem>
                        <asp:ListItem Value="5">Mã chỉ định</asp:ListItem>
                        <asp:ListItem Value="6">Nhánh</asp:ListItem>
                        <asp:ListItem Value="7">SĐT</asp:ListItem>
                        <asp:ListItem Value="8">Email</asp:ListItem>
                        <asp:ListItem Value="9">STK</asp:ListItem>
                        <asp:ListItem Value="10">Ngân hàng</asp:ListItem>
                        <asp:ListItem Value="11">Ngày ĐK</asp:ListItem>
                        <asp:ListItem Value="12">Ngày NC</asp:ListItem>
                        <asp:ListItem Value="13">Hỗ trợ</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-md-push-1">
                    <asp:Button ID="btnSearch" runat="server" Text="TÌM" CssClass="btn-danger form-control" OnClick="btnSearch_Click" />
                </div>
                <div class="col-md-3 col-md-push-2">
                    <asp:DropDownList ID="dllHOA_HONG_THANG" runat="server" CssClass="form-control" OnSelectedIndexChanged="dllHOA_HONG_THANG_SelectedIndexChanged"></asp:DropDownList>
                </div>

            </div>
        </fieldset>

        <fieldset class="fdb-scheduler-border">
            <asp:GridView ID="grdMEMBERS" runat="server" HeaderStyle-BackColor="#cc181e"
                HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" AllowPaging="true" PageSize="100"
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

                    <asp:TemplateField HeaderText="Mã CĐ" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCD" runat="server" Text='<%# Eval("MA_CAY_TT")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tên CĐ" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTCD" runat="server" Text='<%# Eval("TEN_CAY_TT")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nhánh" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblNhanh" runat="server" Text='<%# Eval("NHANH_CAY_TT")%>' />
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
                                CommandArgument='<%# Eval("MA_KH")%>' ImageUrl="/Images/delete-icon.png" ToolTip="Delete" Width="16" Height="16"
                                OnClientClick="return confirm('Are you sure you want delete ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnLock" runat="server" CausesValidation="false" CommandName="cmdLock"
                                CommandArgument='<%# Eval("MA_KH") %>' ImageUrl="/Images/key-icon.png" ToolTip="Lock account" Width="16" Height="16"
                                OnClientClick="return confirm('Are you sure you want lock account ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
</asp:Content>
