$(document).ready(function () {
    $(".btn-password-show").click(function () {
        $(".btn-password-show").css("display", "none");
        $(".btn-password-hide").css("display", "inline");
        $("#Input_Password").attr("type", "text");
    });

    $(".btn-password-hide").click(function () {
        $(".btn-password-show").css("display", "inline");
        $(".btn-password-hide").css("display", "none");
        $("#Input_Password").attr("type", "password");
    });
});