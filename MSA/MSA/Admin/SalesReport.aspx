<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="SalesReport.aspx.vb" Inherits="MSA.SalesReport" %>

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
   
    <div class="container">

        <div class="form-horizontal">
            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">BÁO CÁO DOANH SỐ</legend>
                <div class="form-group">
                    <div class="col-md-2 control-label"><b>Thời gian</b></div>

                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlMonthDS" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="col-md-5"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-2 control-label"><b>Tìm kiếm</b></div>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlDieuKien" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text="">Mã khách hàng</asp:ListItem>
                            <asp:ListItem Value="1">Tên khách hàng</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" runat="server" Text="TÌM" CssClass="btn-danger form-control" OnClick="btnSearch_Click" />
                    </div>
                </div>

            </fieldset>
        </div>

        <div>
            <asp:Label ID="lblNotify" runat="server" ForeColor="Blue">Không có kết quả thỏa mãn điều kiện tìm kiếm</asp:Label>
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
                    <asp:BoundField DataField="TEN" HeaderText="Họ và tên">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                                       
                    <asp:BoundField DataField="DOANH_SO_TRAI" HeaderText="Nhánh trái phát sinh" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_PHAI" HeaderText="Nhánh phải phát sinh" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DOANH_SO_TICH_LUY_TRAI" HeaderText="Nhánh trái tích lũy" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_TICH_LUY_PHAI" HeaderText="Nhánh phải tích lũy" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DOANH_SO_KET_CHUYEN_TRAI" HeaderText="Kết chuyển nhánh trái" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_KET_CHUYEN_PHAI" HeaderText="Kết chuyển nhánh phải" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>                   

                    <asp:TemplateField HeaderText="Tháng - năm">
                        <ItemTemplate>
                            <%# Eval("THANG")%> - <%# Eval("NAM")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
