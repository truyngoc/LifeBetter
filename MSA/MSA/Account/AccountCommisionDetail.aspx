<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AccountCommisionDetail.aspx.vb" Inherits="MSA.AccountCommisionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="~/Content/bootstrap.min_t.css" type="text/css" />
    <link rel="stylesheet" href="~/Content/MSA_style_truybn.css" type="text/css" />
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div>
                    <div class="month">
                        <%--<span></span>
                                    <div class="title">Tháng</div>
                                    <asp:DropDownList ID="ddlTHANG" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:Button ID="btnExcel" runat="server" Text="Xuất file Excel" CssClass="btn btn-info" />--%>

                        <div class="canhan">
                            <div>
                                <span class="header">Doanh số nhóm trong Tháng: </span>
                                <span class="value">
                                    <asp:Label ID="lblDOANH_SO_CA_NHAN_THANG" runat="server"></asp:Label>
                                </span>
                                <span class="header1">| </span>
                                <span class="header">Doanh số Tích lũy: </span>
                                <span class="value">
                                    <asp:Label ID="lblDOANH_SO_CA_NHAN_TICH_LUY" runat="server"></asp:Label>
                                </span>

                            </div>
                        </div>
                    </div>


                    <div>

                        <table class="doanhso">
                            <tbody>
                                <tr class="row-first">
                                    <%--<td class="col-nothing"></td>--%>
                                    <td></td>
                                    <td>Nhánh trái</td>
                                    <td>Nhánh phải</td>
                                </tr>
                                <tr>
                                    <td class="col-first">Doanh số Phát sinh mới</td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-first">Doanh số Kết chuyển</td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_KET_CHUYEN_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_KET_CHUYEN_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-first">Doanh số Tích lũy</td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_TICH_LUY_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblDOANH_SO_TICH_LUY_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="col-first">Tổng số Thành viên</td>
                                    <td class="content">
                                        <asp:Label ID="lblTONG_SO_THANH_VIEN_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblTONG_SO_THANH_VIEN_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="col-first">Số Thành viên Mới</td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-first">Số Thành viên Mới được bảo trợ</td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_BAO_TRO_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_BAO_TRO_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>
                <div class="clear"></div>
            </div>



            <div>
                <div>
                    <h4 class="text-center">Thu nhập tháng</h4>
                </div>
                <div>
                    <table class="hoahong " cellspacing="0" rules="all" border="1" style="height: 50px; width: 400px; border-collapse: collapse;">
                        <tbody>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Hoa hồng Trực tiếp</td>
                                <td>
                                    <asp:Label ID="lblHOA_HONG_TRUC_TIEP" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Hoa hồng gián tiếp</td>
                                <td>
                                    <asp:Label ID="lblHOA_HONG_GIAN_TIEP" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Hoa hồng cơ bản</td>
                                <td>
                                    <asp:Label ID="lblHOA_HONG_CO_BAN" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Hoa hồng cơ bản được tính</td>
                                <td>
                                    <asp:Label ID="lblHOA_HONG_CO_BAN_DUOC_TINH" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Quỹ tiền mặt</td>
                                <td>
                                    <asp:Label ID="lblQUY_TIEN_MAT" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Quỹ phong cách sống</td>
                                <td>
                                    <asp:Label ID="lblQUY_PHONG_CACH" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Quỹ đào tạo</td>
                                <td>
                                    <asp:Label ID="lblQUY_DAO_TAO" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right" style="background-color: #E6E6E6; font-size: Larger;">
                                <td align="left" class="title">Tổng cộng</td>
                                <td style="color: #FE3F00; font-weight: bold;">
                                    <asp:Label ID="lblTONG_CONG_DOANH_SO_THANG" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
