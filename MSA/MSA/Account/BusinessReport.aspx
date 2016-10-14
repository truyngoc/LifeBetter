<%@ Page Language="vb" MasterPageFile="~/Admin/NEW_ADMIN.Master" AutoEventWireup="false" CodeBehind="BusinessReport.aspx.vb" Inherits="MSA.BusinessReport"
     EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        $(function () {
            $(".mydate").datepicker();

        });
    </script>

    <script type="text/javascript">
        function ChangeCheckBoxState(id, checkState) {
            var cb = document.getElementById(id);
            if (cb != null)
                cb.checked = checkState;
        }

        function ChangeAllCheckBoxStates(checkState) {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null) {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxState(CheckBoxIDs[i], checkState);
            }
        }

        function ChangeHeaderAsNeeded() {
            // Whenever a checkbox in the GridView is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null) {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++) {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked) {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false);
                        return;
                    }
                }

                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true);
            }
        }
    </script>

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
            padding: 0 1em 1em 1em !important;
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
            margin-bottom: 5px;
            color: #006bc1;
            font-weight: bold;
        }
    </style>

    <div class="container">
        <br />
        <asp:HiddenField ID="hidTypeSearch" runat="server" />

        <div class="form-horizontal">
            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">DANH HIỆU</legend>
                <div class="form-group">
                    <label class="col-md-2 control-label">Tên danh hiệu</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlDanhHieu" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">KIM CƯƠNG</asp:ListItem>
                            <asp:ListItem Value="2">CHỦ TỊCH</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label class="col-md-1 control-label">Tháng</label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlDanhHieu_THANG" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnSearchDanhHieu" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                    </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">DOANH SỐ</legend>
                <div class="form-group">
                    <label class="col-md-2 control-label">Trái</label>
                    <div class="col-md-1" style="padding-right: 8px; width: 80px">
                        <asp:DropDownList ID="ddlToanTuTrai" runat="server" CssClass="form-control">
                            <asp:ListItem Value=">" Text=">"></asp:ListItem>
                            <asp:ListItem Value="<"><</asp:ListItem>
                            <asp:ListItem Value="=">=</asp:ListItem>
                            <asp:ListItem Value=">=">>=</asp:ListItem>
                            <asp:ListItem Value="<="><=</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2" style="padding-left: 0">
                        <asp:TextBox ID="txtDoanhSoTrai" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-2 control-label">Phải</label>
                    <div class="col-md-1" style="padding-right: 8px; width: 80px">
                        <asp:DropDownList ID="ddlToanTuPhai" runat="server" CssClass="form-control">
                            <asp:ListItem Value=">" Text=">"></asp:ListItem>
                            <asp:ListItem Value="<"><</asp:ListItem>
                            <asp:ListItem Value="=">=</asp:ListItem>
                            <asp:ListItem Value=">=">>=</asp:ListItem>
                            <asp:ListItem Value="<="><=</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2" style="padding-left: 0">
                        <asp:TextBox ID="txtDoanhSoPhai" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="col-md-1 control-label">Tháng</label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlDoanhSo_THANG" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnSearch_DOANH_SO" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                    </div>
                </div>
            </fieldset>


            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">NGÀY THAM GIA</legend>
                <div class="form-group">
                    <label class="col-md-2 control-label">Từ ngày</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTuNgay" runat="server" CssClass="form-control mydate"></asp:TextBox>
                    </div>
                    <label class="col-md-1 control-label">Đến ngày</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtDenNgay" runat="server" CssClass="form-control mydate"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnSearch_NGAY_THAM_GIA" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                    </div>
                </div>
            </fieldset>

            <fieldset class="fdb-scheduler-border">
                <legend class="fdb-scheduler-border">MÃ SỐ THÀNH VIÊN</legend>

                <div class="form-group">
                    <label class="col-md-2 control-label">Mã thành viên</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtMA_THANH_VIEN" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnSearch_MA_THANH_VIEN" runat="server" Text="TÌM" CssClass="btn-danger form-control" />
                    </div>
                </div>
            </fieldset>
        </div>

        <div class="row" style="margin-bottom:5px;">
            <div class="col-md-6">
                <asp:Label ID="lblNotify" runat="server" ForeColor="Blue">Không có kết quả thỏa mãn điều kiện tìm kiếm</asp:Label>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-2">
                <asp:Button ID="btnExportExcel" runat="server" Text="Export Excel" CssClass="btn btn-info" />
            </div>                        
        </div>
        <div class="row">
            <%--<input type="button" value="Check All" onclick="ChangeAllCheckBoxStates(true);" />&nbsp;
            <input type="button" value="Uncheck All" onclick="ChangeAllCheckBoxStates(false);" />--%>
            
            <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" PageSize="30"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="MA_KH" HeaderText="Mã số">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TEN" HeaderText="Họ và tên">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="TEN_GOI_DAU_TU" HeaderText="Danh hiệu">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOANH_SO_TRAI" HeaderText="Nhánh trái" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DOANH_SO_PHAI" HeaderText="Nhánh phải" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DOANH_SO_TICH_LUY_TRAI" HeaderText="Nhánh trái tích lũy" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DOANH_SO_TICH_LUY_PHAI" HeaderText="Nhánh phải tích lũy" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="THANG_NAM" HeaderText="Tháng-Năm">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Ngày tham gia" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%# Eval("NGAY_THAM_GIA", "{0:dd/MM/yyyy}")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
                        
            <asp:Literal ID="CheckBoxIDsArray" runat="server"></asp:Literal>

        </div>
    </div>

</asp:Content>
