define([

], function () {

    var timer = 0;
    var defaults = {
        isNormalInteger:function (str) {
            var intRegex = /^\d+$/;
            return (intRegex.test(str));
//            return /^\+?(0|[1-9]\d*)$/.test(str);
        },
        show_message:function (msg) {
            clearTimeout(timer);
            $("#flash_message").html(msg);
            $("#flash_shower").fadeIn(300);
            timer = setTimeout(function () {
                $("#flash_shower").fadeOut(300)
            }, 3000)
        }
    };

    return defaults;
})
