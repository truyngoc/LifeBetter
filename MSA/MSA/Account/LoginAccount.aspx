<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginAccount.aspx.vb" Inherits="MSA.LoginAcount" %>--%>
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MSA.Master" CodeBehind="LoginAccount.aspx.vb" Inherits="MSA.LoginAcount" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainLoginAccount" runat="server">
       <script type="text/javascript">
           $(document).ready(function () {
               $("#btnLogin").click(function () {
                   $('#myModal').modal();
               });
           });
           $("#btnHide").click(function () {
               $("#div1").attr("style", "");
               $("#div1").html('');
               $("#<%=txtTransaction.ClientID%>").val('');

                $('#myModal').modal('hide');

            });
        </script>
            <div id="motopress-main" class="main-holder">

                
                <div class="motopress-wrapper content-holder clearfix">
                    <div class="container">
                        <div class="row">
                            <div class="span12" data-motopress-wrapper-file="page-faq.php" data-motopress-wrapper-type="content">
                             <%--   <div class="row" style="margin-left: -60px">
                                    <div class="span12" data-motopress-type="static" data-motopress-static-file="static/static-title.php">

                                        <section class="title-section">
                                            <%--<h1 class="title-header">Đăng nhập</h1>
                                            <ul class="breadcrumb breadcrumb__t">
                                                <li><a href="../Home.aspx">Trang chủ</a></li>
                                                <li class="active">Đăng nhập</li>
                                            </ul>
                                        </section>

                                    </div>
                                </div>--%>

                                <h4 style="margin-left: -10px; width: 1165px;font-family:'Times New Roman'"><font color="010101"><strong>Truy cập tài khoản</strong></font></h4>

                                <div id="content" class="row">
                                    <div class="span12" data-motopress-type="loop" data-motopress-loop-file="loop/loop-page.php">
                                        <div id="post-14" class="post-14 page type-page status-publish hentry page">
                                            <div class="row">

                                                <div class="span4">
                                                    <img src="/images/slide9.jpg"/>
                                                    <address>
                                                        <h5 style="font-family:'Times New Roman'"><font color="010101">Thông tin liên lạc.</font></h5>
                                                        <strong>Tòa nhà Bitexco ,02 Hải Triều, Quận 1, Thành phố Hồ Chí Minh, Việt Nam</strong>
                                                        <ul>
                                                            <li>Số ĐT: +44 20 7156 6217</li>
                                                            <li>FAX: +44 20 7156 6220</li>
                                                            <li>E-mail: <a href="mailto:admin@lifebetter.com.vn">admin@lifebetter.com.vn</a></li>
                                                        </ul>
                                                    </address>
                                                </div>

                                                <div class="span8" style="margin-top: -20px;">
                                                    <h2 style="font-family:'Times New Roman'"><b>Thông tin đăng nhập</b></h2>
                                                <%--<h5><font color="010101">Please, enter your Username and MAT_KHAU for access to Account.</font></h5>--%>
                                                    <%--<br>--%>
                                                    <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or MAT_KHAU is not valid" Visible="false"></asp:Label>
                                                    <br />
                                                    <%-- <input type="email" name="log" value="" size="60" style="width: 350px; height: 41px;" placeholder="EMAIL ADDRESS:" required="">
                                                        <br>
                                                        <br>
                                                        <input type="MAT_KHAU" name="passwd" value="" size="60" style="width: 350px; height: 41px;" placeholder="MAT_KHAU:" required="">--%>
                                                    <asp:TextBox ID="txtMA_KH" runat="server" class="form-control" Style="width: 350px; height: 41px;" placeholder="Mã khách hàng:" />
                                                    <asp:RequiredFieldValidator ErrorMessage="Bạn chưa nhập mã khách hàng" ControlToValidate="txtMA_KH" runat="server" ForeColor="#cc0066" Text="Bạn chưa nhập mã khách hàng" Display="Dynamic" />
                                                    <br />
                                                    <asp:TextBox ID="txtMAT_KHAU" runat="server" TextMode="Password" class="form-control" Style="width: 350px; height: 41px;" placeholder="Mật khẩu:" />
                                                    <asp:RequiredFieldValidator ErrorMessage="Bạn chưa nhập mật khẩu" ControlToValidate="txtMAT_KHAU" runat="server" ForeColor="#cc0066" Text="Bạn chưa nhập mật khẩu" Display="Dynamic" />

<%--                                                     <input type="text" name="code1" value="" size="40" style="width: 168px; height: 41px;" placeholder="CAPTCHA CODE:" required="">
                                                        ﻿&nbsp;<img src="captcha.php?n1=5&amp;n2=6&amp;n3=8&amp;n4=2&amp;n5=1" style="margin-top: -12px;">
                                                        <input type="hidden" name="code" value="56821"><input type="hidden" name="dogo" value="1">--%>

                                                    <br>
                                                   <%--<asp:LinkButton ID="btnLink" runat="server" Text="Lost your MAT_KHAU? Click here to reset MAT_KHAU via email."> </asp:LinkButton><br>--%>
                                                        <%--<a href="LossPass">Lost your MAT_KHAU? Click here to reset MAT_KHAU via email.</a>--%>
                                                    <a href="LossPass">Có phải bạn quên mật khẩu ? Gửi link tới hòm thư điện tử để reset password</a>
                                                    <br>
                                                    <br>
                                                    <%-- <input type="reset" value="clear" class="btn btn-primary">--%>
                                                    <%--  <input type="submit" value="access to account" class="btn btn-primary">--%>
                                                    <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" class="btn btn-primary" />

                                                </div>


                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <br/>
                                <br/>
                                <br/>
                            </div>
                        </div>
                    </div>
                </div>
                

            </div>
        

        <input type="button" id="btn1" value="Show modal" class="btn btn-primary dropdown-toggle" style="display: none" />

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog" style="width: 100%">
            <div class="modal-dialog modal-lg" style="width: 60%">
                <div class="modal-content" style="width: 100%">
                    <div class="modal-header" style="width: 100%">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title" style="border: none">Modal Confirm send</h4>
                    </div>
                    <div class="modal-body" style="width: 100%">
                        <div class="col-md-2 control-label">
                            Transaction Link
                        <label style="color: red;">(*)</label>
                        </div>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtTransaction" CssClass="form-control" placeholder="Transaction Link">

                            </asp:TextBox>
                        </div>

                        <br />
                        <br />
                        <br />

                        <div class="col-md-12">
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                        <input type="button" value="Check link" class="btn btn-success" id="btnCheckLink" />
                            <asp:Label runat="server" ID="lblID"></asp:Label>
                            <asp:HiddenField ID="hidden" runat="server" />
                        </div>

                    </div>
                    <div class="modal-footer" style="width: 100%">
                        <asp:Button runat="server" ID="btnSaveConfirm" Text="Save" class="btn btn-default" Style="background-color: #cccccc; height: auto" />
                        <button type="button" class="btn btn-default" id="btnHide" style="background-color: #cccccc">Close</button>
                    </div>

                    <div id="div1">
                    </div>

                </div>
            </div>
        </div>
     

</asp:Content>
