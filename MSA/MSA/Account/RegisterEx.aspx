<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MSA.Master" CodeBehind="RegisterEx.aspx.vb" Inherits="MSA.RegisterEx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainLoginAccount" runat="server">

    <div id="motopress-main" class="main-holder">


        <div class="motopress-wrapper content-holder clearfix">
            <div class="container">
                <div class="row">
                    <div class="span12" data-motopress-wrapper-file="page-faq.php" data-motopress-wrapper-type="content">

                        <h4 style="margin-left: -10px; width: 1165px; font-family: 'Times New Roman'"><font color="010101"><strong>Đăng ký tài khoản</strong></font></h4>

                        <div id="content" class="row">
                            <div class="span12" data-motopress-type="loop" data-motopress-loop-file="loop/loop-page.php">
                                <div id="post-14" class="post-14 page type-page status-publish hentry page">
                                    <div class="row">

                                        <div class="span4">
                                            <img src="/images/slide9.jpg" />
                                            <address>
                                                <h5 style="font-family: 'Times New Roman'"><font color="010101">Thông tin liên lạc.</font></h5>
                                                <strong>Tòa nhà Bitexco 02 Hải Triều, Quận 1, </br>Thành phố Hồ Chí Minh, Việt Nam</strong>
                                                <ul>
                                                    <li>Số ĐT: +44 20 7156 6217</li>
                                                    <li>FAX: +44 20 7156 6220</li>
                                                    <li>E-mail: <a href="mailto:support@lifebetter.com.vn">support@lifebetter.com.vn</a></li>
                                                </ul>
                                            </address>
                                        </div>

                                        <div class="span8" style="margin-top: -20px; margin-left: auto">
                                            <asp:Panel runat="server" ID="pnForm">
                                                <fieldset class="fdb-scheduler-border">
                                                    <div class="row">
                                                        <asp:Label runat="server" ID="lblMessages" ForeColor="Blue" Font-Bold="true"> <br />    
                                                        </asp:Label>
                                                        <br />
                                                        <asp:Label runat="server" ID="lblMessages2" ForeColor="Blue"  Font-Bold="true"> <br />    
                                                        </asp:Label>
                                                        <asp:Label runat="server" ID="lblMaKHMOI" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                                                        <br />

                                                        <div class="row">
                                                            <label class="col-md-3 control-label">Họ tên:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtTEN" runat="server" class="form-control" />
                                                                <asp:RequiredFieldValidator ErrorMessage="Tên người tham gia không được để trống" ControlToValidate="txtTEN" runat="server" ForeColor="#cc0066" Text="Tên người tham gia không được để trống" Display="Dynamic" />
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <label class="col-md-3 control-label">Số điện thoại:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtDIEN_THOAI" runat="server" class="form-control" />
                                                                <asp:RequiredFieldValidator ErrorMessage="Số điện thoại không được để trống" ControlToValidate="txtDIEN_THOAI" runat="server" ForeColor="#cc0066" Text="Số điện thoại không được để trống" Display="Dynamic" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <label class="col-md-3 control-label" for="Email">Email:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtDIA_CHI" runat="server" class="form-control" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="txtDIA_CHI" ForeColor="#cc0066" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
<%--                                                        <div class="row">
                                                            <label class="col-md-3 control-label">Số tài khoản:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtSO_TAI_KHOAN" runat="server" class="form-control" />

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <label class="col-md-3 control-label">Ngân hàng:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtNGAN_HANG" runat="server" class="form-control" />

                                                            </div>
                                                        </div>--%>

                                                        <div class="row">
                                                            <label class="col-md-3 control-label">Mật khẩu:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtMAT_KHAU" runat="server" TextMode="Password" class="form-control" />
                                                                <asp:RequiredFieldValidator ErrorMessage="Mật khẩu không được để trống." ControlToValidate="txtMAT_KHAU" runat="server" ForeColor="#cc0066" Text="Mật khẩu không được để trống." Display="Dynamic" />
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <label class="col-md-3 control-label" for="ConfirmPassword">Xác nhận mật khẩu:</label>
                                                            <div class="col-md-5">
                                                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" />
                                                                <asp:RequiredFieldValidator ErrorMessage="Xác nhận mật khẩu không được để trống" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" Text="Xác nhận mật khẩu không được để trống" Display="Dynamic" />
                                                                <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtMAT_KHAU" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="#cc0066" ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-offset-2 col-md-8">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="ĐĂNG KÝ" class="btn btn-primary" />
                                                                    <asp:Label ID="lblMA_BAO_TRO_TT" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </asp:Panel>




                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>

                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
