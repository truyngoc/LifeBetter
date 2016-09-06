<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AccountSponsorTree.aspx.vb" Inherits="MSA.AccountSponsorTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="~/Content/bootstrap.min_t.css" type="text/css" />
    <link rel="stylesheet" href="~/Content/MSA_style_truybn.css" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
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
                                url: "AccountSponsorTree.aspx/GetSponsorData",
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
                                        var ma_kh = r.d[i][1].toString();
                                        var ma_cay = r.d[i][2].toString();
                                        var memberName = r.d[i][4];
                                        var ma_bao_tro = r.d[i][3] != null ? r.d[i][3].toString() : '';
                                        var ma_goi_dau_tu = r.d[i][10];

                                        data.addRows([[{
                                            v: ma_cay,
                                            f: memberName
                                                + '<div>(<span style="color:red">'
                                                + ma_kh
                                                + '</span>)<div><img src = "../images/goi_' + ma_goi_dau_tu + '.png" "height="31" width="35" /></div>'
                                        }, ma_bao_tro, memberName]]);
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
                            <div class="title" style="color: black">Mã gốc</div>

                            <asp:TextBox runat="server" ID="txtMA_CAY" Text="0" class="form-control" Style="width: 100px;" Enabled="false"></asp:TextBox>
                            <%--<input type="submit" value="Show tree" class="btn btn-primary" />--%>

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
    </form>
</body>
</html>
