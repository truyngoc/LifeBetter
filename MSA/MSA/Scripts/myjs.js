$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 116) {
            $('.navbar').css("height", "85px");
            $('.navbar').css("background-color", "#fff");
            $('.navbar').css("padding", "17px");
            $('.navbar a').css("color", "#888");
        } else {
            $('.navbar').css("background-color", "rgba(169, 169, 169, 0.55)");
            $('.navbar').css("height", "116px");
            $('.navbar').css("padding", "30px");
            $('.navbar a').css("color", "#fff");
        }
    });
});