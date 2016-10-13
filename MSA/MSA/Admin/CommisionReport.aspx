<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/NEW_ADMIN.Master" CodeBehind="CommisionReport.aspx.vb" Inherits="MSA.CommisionReport" %>
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
                <legend class="fdb-scheduler-border">BÁO CÁO HOA HỒNG</legend>
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
                                       
                    <asp:BoundField DataField="HOA_HONG_TRUC_TIEP" HeaderText="Hoa hồng trực tiếp" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HOA_HONG_GIAN_TIEP" HeaderText="Hoa hồng gián tiếp" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="HOA_HONG_CO_BAN_DUOC_TINH" HeaderText="Hoa hồng cơ bản" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="TONG_HOA_HONG" HeaderText="Tổng hoa hồng" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="THUONG_THANH_TICH_DUOC_TINH" HeaderText="Thưởng thành tích" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="QUY_TIEN_MAT" HeaderText="Quỹ tiền mặt" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QUY_PHONG_CACH" HeaderText="Quỹ phong cách" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="QUY_DAO_TAO" HeaderText="Quỹ đào tạo" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>                  

                    <asp:BoundField DataField="TONG_THU_NHAP" HeaderText="Tổng thu nhập" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>          
                    
                    <asp:BoundField DataField="SO_TAI_KHOAN" HeaderText="Số tài khoản">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>   

                    <asp:BoundField DataField="NGAN_HANG" HeaderText="Ngân hàng">
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
