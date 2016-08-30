<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="CommisionStatistics.aspx.vb" Inherits="MSA.CommisionStatistics" %>

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

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
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


    <script>
        function view_Data(id) {
            var w = 650;
            var h = 580;
            var x = screen.width / 2 - w / 2;
            var y = screen.height / 2 - h / 2;
            window.open("AccountCommisionDetail.aspx?ID=" + id, 'Xem chi tiết doanh thu, hoa hồng',
          'height=' + h + ',width=' + w + ',left=' + x + ',top=' + y);

            return false;
        }
    </script>


    <div class="container">

        <div class="row">
            <div class="col-md-4 text-danger"><b>Xem Doanh số - Hoa hồng</b></div>
            
            <div class="col-md-3">
            <asp:DropDownList ID="ddlMonthDS" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

            <div class="col-md-5"></div>
        </div>
        <br />
        <div class="row">
            <asp:Label ID="lblDOANH_SO_THANG" runat="server" Visible="false"></asp:Label>
            <%--<h4 class="text-center">Thu nhập tháng hiện tại</h4>--%>
        </div>
        <div>
            <asp:Label ID="lblNotify" runat="server" ForeColor="Blue">Doanh số - hoa hồng tháng này chưa được chốt</asp:Label>
            <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" PageSize="12"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="MA_KH" HeaderText="Mã KH">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="THANG" HeaderText="Tháng">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NAM" HeaderText="Năm">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_THANH_VIEN_MOI_TRAI" HeaderText="Số thành viên mới nhánh trái">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_THANH_VIEN_MOI_PHAI" HeaderText="Số thành viên mới nhánh phải">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_TRAI" HeaderText="Doanh số nhánh trái" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_PHAI" HeaderText="Doanh số nhánh phải" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HOA_HONG_TRUC_TIEP" HeaderText="Hoa hồng trực tiếp" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HOA_HONG_GIAN_TIEP" HeaderText="Hoa hồng gián tiếp" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HOA_HONG_CO_BAN" HeaderText="Hoa hồng cơ bản" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdView" runat="server" CausesValidation="false" CommandName="cmdView"
                                CommandArgument='<%# Eval("ID") %>' ImageUrl="/Images/view_detail.png" ToolTip="Xem chi tiết"
                                OnClientClick='<%# String.Format("return view_Data({0});", Eval("ID"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
