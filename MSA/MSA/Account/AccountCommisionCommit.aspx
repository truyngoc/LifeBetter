<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountCommisionCommit.aspx.vb" Inherits="MSA.AccountCommisionCommit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .bonus {
            margin: 0 auto;
        }

            .bonus .header {
                background-color: #0B8D35;
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
                width: 250px;
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



    <!-- This is your Javascript function that will display your image -->
    <script type='text/javascript'>
        function DisplayLoadingImage() {
            document.getElementById("HiddenLoadingImage").style.display = "block";
        }

        function DisplayLoadingImage1() {
            document.getElementById("HiddenLoadingImage1").style.display = "block";
        }
    </script>


    <div class="container">
        <div class="row">
            <div class="text-danger"><b>Thực hiện chốt doanh số tháng</b></div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <!-- Your Button -->
                <asp:Button ID="btnChotHoaHong" runat="server" OnClientClick="DisplayLoadingImage();" Text="Chốt doanh số - hoa hồng tháng" CssClass="btn btn-info" />
            </div>

            <div class="col-md-4">
                <!-- Your initially hidden loading image -->
                <img id='HiddenLoadingImage' src='/images/loading.gif' style='display: none;' />
            </div>
        </div>
        <br />
        <div class="row">
            <asp:Label ID="lblResult" runat="server" ForeColor="Blue"></asp:Label>
        </div>

    </div>

    <br />
    <hr />

    <div class="container">
        <div class="row">
            <div class="text-danger"><b>Thực hiện chốt lại doanh số tháng</b></div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <asp:DropDownList ID="ddlMonth_Chot_Lai_DS" runat="server" CssClass="form-control"></asp:DropDownList>
                <!-- Your Button -->
                <asp:Button ID="btnChotLaiHoaHong" runat="server" OnClientClick="DisplayLoadingImage1();" Text="Chốt lại doanh số - hoa hồng tháng" CssClass="btn btn-info" />
            </div>

            <div class="col-md-4">
                <!-- Your initially hidden loading image -->
                <img id='HiddenLoadingImage1' src='/images/loading.gif' style='display: none;' />
            </div>
        </div>
        <br />
        <div class="row">
            <asp:Label ID="lblNotify" runat="server" ForeColor="Blue"></asp:Label>
        </div>
    </div>

    <br />
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-md-3 text-danger"><b>Xem trong tháng</b></div>

            <div class="col-md-3">
                <asp:DropDownList ID="ddlMonthDS" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>

            <div class="col-md-5"></div>
        </div>

        <div>
            <h4 class="text-center">Thống kê hệ thống</h4>
        </div>

        <div>
            <table class="hoahong " cellspacing="0" rules="all" border="1" style="height: 50px; width: 400px; border-collapse: collapse;">
                <tbody>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng số thành viên</td>
                        <td>
                            <asp:Label ID="lblTONG_SO_THANH_VIEN" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng doanh số</td>
                        <td>
                            <asp:Label ID="lblTONG_DOANH_SO" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Hoa hồng Trực tiếp</td>
                        <td>
                            <asp:Label ID="lblHOA_HONG_TRUC_TIEP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Hoa hồng gián tiếp</td>
                        <td>
                            <asp:Label ID="lblHOA_HONG_GIAN_TIEP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Hoa hồng cơ bản được tính</td>
                        <td>
                            <asp:Label ID="lblHOA_HONG_CO_BAN_DUOC_TINH" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Thưởng thành tích</td>
                        <td>
                            <asp:Label ID="lblTHUONG_THANH_TICH" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Thưởng thành tích được tính</td>
                        <td>
                            <asp:Label ID="lblTHUONG_THANH_TICH_DUOC_TINH" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Quỹ tiền mặt</td>
                        <td>
                            <asp:Label ID="lblQUY_TIEN_MAT" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Quỹ phong cách sống</td>
                        <td>
                            <asp:Label ID="lblQUY_PHONG_CACH" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng Quỹ đào tạo</td>
                        <td>
                            <asp:Label ID="lblQUY_DAO_TAO" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                        <td align="left" class="title">Tổng hoa hồng chi trả</td>
                        <td style="color: #FE3F00; font-weight: bold;">
                            <asp:Label ID="lblTONG_CONG_DOANH_SO_THANG" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
