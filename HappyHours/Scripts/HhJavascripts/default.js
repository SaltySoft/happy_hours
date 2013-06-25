define([

], function () {

    var timer = 0;
    var defaults = {
        show_message: function (msg) {
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
