<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/MSA_Admin.Master" CodeBehind="AccountTreeView.aspx.vb" Inherits="MSA.AccountTreeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function view_Data() {
            var ma_cay = $("#<%=txtMA_CAY.ClientID%>")[0].value;

            var w = 650;
            var h = 580;
            var x = screen.width / 2 - w / 2;
            var y = screen.height / 2 - h / 2;
            window.open("AccountSponsorTree.aspx?MA_CAY=" + ma_cay, 'Xem cây bảo trợ',
          'height=' + h + ',width=' + w + ',left=' + x + ',top=' + y);

            return false;
        }
    </script>

    <div class="co-md-12">
        <div id="dnn_rightPane" class="rightPane">
            <div class="table_doanhso">
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
                                <tr>
                                    <td class="col-first">Tổng số Thành viên</td>
                                    <td class="content">
                                        <asp:Label ID="lblTONG_SO_THANH_VIEN_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblTONG_SO_THANH_VIEN_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-first">Số Thành viên Mới</td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>
<%--                                <tr>
                                    <td class="col-first">Số Thành viên Mới được bảo trợ</td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_BAO_TRO_TRAI" runat="server"></asp:Label>
                                    </td>
                                    <td class="content">
                                        <asp:Label ID="lblSO_THANH_VIEN_MOI_BAO_TRO_PHAI" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                            </tbody>
                        </table>

                    </div>
                </div>
                <div class="clear"></div>
            </div>

            <br />

            <div class="life_better_tree">
                <div>

                    <script type="text/javascript">
                        var currZoom = 1;

                        $(document).ready(function () {
                            $("#ZoomIn").click(function () {
                                var w = $("#chart_div").width();
                                var w_chart = $("table.google-visualization-orgchart-table").width();

                                currZoom += 0.1;
                                $(".chart_div").css({
                                    'zoom': currZoom
                                }
                                );
                            });
                            $("#ZoomOut").click(function () {
                                currZoom -= 0.1;
                                $(".chart_div").css({
                                    'zoom': currZoom
                                }
                                );
                            });
                        });
                    </script>


                    <script type="text/javascript" src="../Scripts/loader.js"></script>
                    <script type="text/javascript" src="../Scripts/smart.resize.js"></script>
                    <script type="text/javascript">

                        $(document).ready(function () {
                            ShowTree();
                        });

                        function ShowTree() {
                            google.charts.load('current', { packages: ["orgchart"] });
                            google.charts.setOnLoadCallback(drawChart1);
                        }

                        function drawChart1() {
                            $.ajax({
                                type: "POST",
                                url: "AccountTreeView.aspx/GetChartData",
                                //data: '{}',
                                data: '{ma_cay: "' + $("#<%=txtMA_CAY.ClientID%>")[0].value + '" }',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (r) {
                                    var data = new google.visualization.DataTable();
                                    data.addColumn('string', 'Entity');
                                    data.addColumn('string', 'ParentEntity');
                                    data.addColumn('string', 'ToolTip');

                                    for (var i = 0; i < r.d.length; i++) {
                                        var ma_cay = r.d[i][2].toString();
                                        var ma_kh = r.d[i][1] != null ? r.d[i][1].toString() : 'Trống';
                                        var memberName = r.d[i][4];
                                        var ma_cay_tt = r.d[i][6] != null ? r.d[i][6].toString() : '';
                                        var ma_goi_dau_tu = r.d[i][10];

                                        data.addRows([[{
                                            v: ma_cay,
                                            f: memberName
                                                + '<div>(<span style="color:red">'
                                                + ma_kh
                                                + '</span>)<div><img src = "../images/goi_' + ma_goi_dau_tu + '.png" "height="31" width="35" /></div>'
                                        }, ma_cay_tt, ma_kh]]);
                                    }
                                    var chart = new google.visualization.OrgChart($("#chart_div")[0]);


                                    //$(window).smartresize(function () {
                                    //    chart.draw(data, { allowHtml: true, nodeClass: 'blf-orgchart-node', allowCollapse: true });
                                    //});


                                    var options = {
                                        allowHtml: true,
                                        nodeClass: 'blf-orgchart-node',
                                        allowCollapse: true
                                    };


                                    //chart.draw(data, { allowHtml: true, nodeClass: 'blf-orgchart-node', allowCollapse: true });

                                    chart.draw(data, options);


                                    // chinh zoom cua cayf
                                    var cur_zoom;
                                    var w = $("#chart_div").width();
                                    var w_chart = $("table.google-visualization-orgchart-table").width();
                                    cur_zoom = w / w_chart;

                                    if (cur_zoom > 1) cur_zoom = 1;
                                    currZoom = cur_zoom;

                                    $(".chart_div").css({
                                        'zoom': cur_zoom
                                    });
                                },
                                failure: function (r) {
                                    //alert(r.d);
                                },
                                error: function (r) {
                                    //alert(r.d);
                                }
                            });
                        }

                    </script>
                    <div class="chart">
                        <div>
                            <%--<div class="title">Số tầng</div>
                                        <input type="text" value="6" class="form-control" style="width: 100px;">--%>
                            <div class="title" style="color: black">Mã gốc</div>

                            <asp:TextBox runat="server" ID="txtMA_CAY" Text="" class="form-control" Style="width:100px" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtMa_KH" Text="" class="form-control" Style="width:100px" placeholder="Mã khách hàng"></asp:TextBox>
                           <%-- <input type="submit" value="CÂY NHỊ PHÂN" class="btn btn-primary" />--%>
                            <asp:Button ID="SearchTree" runat="server" Text="CÂY NHỊ PHÂN" CssClass="btn btn-primary" OnClick="SearchTree_Click" />
                            <asp:Button ID="btnShowSponsor" runat="server" Text="CÂY BẢO TRỢ" class="btn btn-primary"  OnClientClick="view_Data(); return false;" />
                        </div>
                        <div>
                            <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                        </div>
                        <div class="ghichu">
                            <img src="../images/goi_0.png" height="24" width="24" />
                            Vị trí trống
                                                <img src="../images/goi_1.png" height="24" width="24" />
                            Gói Khởi động
                                                <img src="../images/goi_2.png" height="24" width="24" />
                            Gói Kinh doanh
                                                <img src="../images/goi_3.png" height="24" width="24" />
                            Gói Chuyên nghiệp
                                                <img src="../images/goi_4.png" height="24" width="24" />
                            Gói kim cương
                                                <img src="../images/goi_5.png" height="24" width="24" />
                            Gói chủ tịch
                        </div>
                        <div class="zoom">
                            <p id="ZoomIn" class="in" title="Phóng to">
                                + 
                            </p>
                            <p id="ZoomOut" class="out" title="Thu nhỏ">
                                -
                            </p>
                        </div>


                        <div id="chart_div" class="chart_div">
                        </div>

                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <%--</div>
        </div>--%>



    <%--<div id="footer">
            <div class="container">
            </div>
            <div class="container">
                <hr class="col-md-12" style="margin-left: 0px;" />
            </div>
            <div id="copyright" class="container">
                <div class="pull-right">
                    <a href="#">Terms Of Use</a> |
					<a href="#">Privacy Statement</a>
                </div>
                <span class="pull-left">Copyright 2016 by Life better Group;</span>

            </div>
            <!--/copyright-->
        </div>--%>
    <!--/footer-->
    <%-- </div>--%>
</asp:Content>
