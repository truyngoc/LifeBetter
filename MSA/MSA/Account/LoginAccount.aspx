<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginAccount.aspx.vb" Inherits="MSA.LoginAcount" %>--%>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MSA.Master" CodeBehind="LoginAccount.aspx.vb" Inherits="MSA.LoginAcount" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainLoginAccount" runat="server">

    <div id="motopress-main" class="main-holder">

        <div class="motopress-wrapper content-holder clearfix">
            <div class="container">
                <div class="row">
                    <div class="span12" data-motopress-wrapper-file="page-faq.php" data-motopress-wrapper-type="content">
                        <h4 style="margin-left: -10px; width: 1165px; font-family: 'Times New Roman'"><font color="010101"><strong>Truy cập tài khoản</strong></font></h4>

                        <div id="content" class="row">
                            <div class="span12" data-motopress-type="loop" data-motopress-loop-file="loop/loop-page.php">
                                <div id="post-14" class="post-14 page type-page status-publish hentry page">
                                    <div class="row">

                                        <div class="span4">
                                            <img src="/images/slide9.jpg" />
                                            <address style="color: black">
                                                <h5 style="font-family: 'Times New Roman'"><font color="#010101">Thông tin liên lạc.</font></h5>
                                                <strong>Tòa nhà Bitexco ,02 Hải Triều, Quận 1, Thành phố Hồ Chí Minh, Việt Nam</strong>
                                                <ul>
                                                    <li>Số ĐT: +44 20 7156 6217</li>
                                                    <li>FAX: +44 20 7156 6220</li>
                                                    <li>E-mail: <a href="mailto:admin@lifebetter.com.vn">admin@lifebetter.com.vn</a></li>
                                                </ul>
                                            </address>
                                        </div>

                                        <div class="span8" style="margin-top: -20px; color: black">
                                            <h2 style="font-family: 'Times New Roman'"><b>Thông tin đăng nhập</b></h2>

                                            <asp:Label runat="server" ID="lblMessage" ForeColor="#cc0066" Text="*Username or MAT_KHAU is not valid" Visible="false"></asp:Label>
                                            <br />
                                            
                                            <asp:TextBox ID="txtMA_KH" runat="server" class="form-control" Style="width: 350px; height: 41px;" placeholder="Mã khách hàng:" />
                                            <asp:RequiredFieldValidator ErrorMessage="Bạn chưa nhập mã khách hàng" ControlToValidate="txtMA_KH" runat="server" ForeColor="#cc0066" Text="Bạn chưa nhập mã khách hàng" Display="Dynamic" />
                                            <br />
                                            <asp:TextBox ID="txtMAT_KHAU" runat="server" TextMode="Password" class="form-control" Style="width: 350px; height: 41px;" placeholder="Mật khẩu:" />
                                            <asp:RequiredFieldValidator ErrorMessage="Bạn chưa nhập mật khẩu" ControlToValidate="txtMAT_KHAU" runat="server" ForeColor="#cc0066" Text="Bạn chưa nhập mật khẩu" Display="Dynamic" />

                                            <br />
                                            <a href="#">Có phải bạn quên mật khẩu ? Gửi thông tin tới LIFE BETTER để reset password</a>
                                            <br />
                                            <br />
                                            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" class="btn btn-primary" />

                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>

                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>


    </div>

    <div id="back-top-wrapper" class="visible-desktop">
        <p id="back-top" style="display: none;">
            <a href="#top"><span></span></a>
        </p>
    </div>

    <script type="text/javascript" src="Scripts/superfish.js?ver=1.5.3"></script>
    <script type="text/javascript" src="Scripts/jquery.mobilemenu.js?ver=1.0"></script>
    <script type="text/javascript" src="Scripts/jquery.easing.1.3.js?ver=1.3"></script>
    <script type="text/javascript" src="Scripts/jquery.magnific-popup.min.js?ver=0.9.3"></script>
    <script type="text/javascript" src="Scripts/camera.min.js?ver=1.3.4"></script>
</asp:Content>
