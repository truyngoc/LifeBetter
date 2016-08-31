<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountCommision.aspx.vb" Inherits="MSA.AccountCommision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .bonus {
            margin: 0 auto;
        }

            .bonus .header {
                /*background-color: #0B8D35;*/
                background-color: #036299;
                color: white;
                font-size: larger;
                padding-left: 10px;
                width: 250px;
            }

            .bonus .value {
                font-size: larger;
                font-weight: bold;
                color: #FE3F00;
                background-color: #E6E6E6;
                padding: 10px;
                text-align: right;
                display: inline-block;
                min-width: 150px;
            }

        .larger {
            font-size: x-large !important;
        }

        .hoahong {
            margin: 0 auto;
            border-color: white;
        }

            .hoahong td {
                border-spacing: 0;
                margin: 0;
                padding: 1px 15px 1px 5px;
                /* border: 1px solid #4cff00; */
                font-size: Larger;
            }


            .hoahong .title {
                color: White;
                /*background-color: #0B8D35;*/
                background-color: #036299;
                font-size: Small;
                font-weight: bold;
                width: 190px;
            }

        .month {
            display: inline-block;
        }

            .chart .title, .month .title {
                color: #3CA936;
                font-size: large;
                float: left;
                margin-right: 10px;
            }

            .month .btnexcel {
                float: right;
            }
    </style>

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

    <div>
        <div class="tkhoahong">
            <table class="bonus">
                <tbody>
                    <tr>
                        <td class="header">TỔNG THU NHẬP CÁC KỲ</td>
                        <td>
                            <span class="value larger">
                                <asp:Label ID="lblTONG_THU_NHAP_CAC_KY" runat="server"></asp:Label>
                            </span>

                        </td>
                    </tr>
                </tbody>
            </table>
            <hr>
            <%--<div class="month">
                <span class="title">Tháng</span>
                <asp:DropDownList ID="dllHOA_HONG_THANG" runat="server" CssClass="form-control"></asp:DropDownList>

                <asp:Button ID="btnExcel" runat="server" Text="Xuất file Excel" CssClass="btn btn-warning .btn-lg btnexcel" />

                <select name="dnn$ctr513$HoaHong$cmbMonth" onchange="javascript:setTimeout('__doPostBack(\'dnn$ctr513$HoaHong$cmbMonth\',\'\')', 0)" id="dnn_ctr513_HoaHong_cmbMonth" class="combobox form-control">
                    <option selected="selected" value="45">07 - 2016</option>
                    <option value="44">06 - 2016</option>
                    <option value="43">05 - 2016</option>
                    <option value="42">04 - 2016</option>
                    <option value="41">03 - 2016</option>
                    <option value="40">02 - 2016</option>
                    <option value="39">01 - 2016</option>

                </select>
                <input type="submit" name="dnn$ctr513$HoaHong$btnExcel" value="Xuất file Excel" id="dnn_ctr513_HoaHong_btnExcel" class="btn btn-warning .btn-lg btnexcel">
            </div>--%>
            <div>
                <div class="row">
                    <h4 class="text-center" style="color:#cc181e";>HOA HỒNG THÁNG HIỆN TẠI</h4>
                </div>
                <br />
                <div class="row">

                    <label class="col-md-3 control-label">
                        <li>Hoa hồng trực tiếp: </li>
                    </label>
                    <div class="col-md-8">
                        <asp:Label ID="lblHOA_HONG_TRUC_TIEP" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">

                    <label class="col-md-3 control-label">
                        <li>Hoa hồng gián tiếp: </li>
                    </label>
                    <div class="col-md-8">
                        <asp:Label ID="lblHOA_HONG_GIAN_TIEP" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">

                    <label class="col-md-3 control-label">
                        <li>Hoa hồng cơ bản: </li>
                    </label>
                    <div class="col-md-8">
                        <asp:Label ID="lblHOA_HONG_CO_BAN_DUOC_TINH" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">

                    <label class="col-md-3 control-label">
                        <li>Tổng thu nhập: </li>
                    </label>

                    <div class="col-md-5">
                        <table class="hoahong" border="1" style="height: 50px; width: 600px; border-collapse: collapse;">
                            <tr>
                                <td align="center" style="background-color:  #cc181e;">
                                    <asp:Label runat="server" ID="Header1" Text="50%" Font-Bold="true" ForeColor="White"> </asp:Label>
                                </td>
                                <td align="center" style="background-color:  #cc181e;">
                                    <asp:Label runat="server" ID="Label1" Text="30%" Font-Bold="true" ForeColor="White"> </asp:Label>
                                </td>
                                <td align="center" style="background-color:  #cc181e;">
                                    <asp:Label runat="server" ID="Label2" Text="20%" Font-Bold="true" ForeColor="White"> </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <label>Quỹ tiền mặt </label>
                                </td>
                                <td align="center">
                                    <label>Quỹ phong cách sống </label>
                                </td>
                                <td align="center">
                                    <label>Quỹ đào tạo </label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="bonus">
                                    <asp:Label ID="lblQUY_TIEN_MAT" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </td>
                                <td align="center" class="bonus">
                                    <asp:Label ID="lblQUY_PHONG_CACH" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </td>
                                <td align="center" class="bonus">
                                    <asp:Label ID="lblQUY_DAO_TAO" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <br />
                <div class="row">

                    <label class="col-md-3 control-label">
                        <li>Thưởng thành tích: </li>
                    </label>

                    <div class="col-md-5">
                        <table class="hoahong" border="1" style="height: 50px; width: 600px; border-collapse: collapse;">
                            <tr>
                                <td align="center" style="background-color:  #cc181e;">
                                    <asp:Label runat="server" ID="Label4" Text="Thưởng" Font-Bold="true" ForeColor="White"> </asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" class="bonus">
                                    <asp:Label ID="lblTHUONG_THANH_TICH" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>



                <hr />
                <div>
                    <h4 class="text-center" style="color:#cc181e";>HOA HỒNG CÁC THÁNG TRƯỚC</h4>
                    <%--<h4 class="text-center">Thu nhập tháng hiện tại</h4>--%>
                </div>
                <div>
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
        </div>
    </div>

</asp:Content>
