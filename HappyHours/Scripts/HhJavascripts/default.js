var timer;
function show_message(msg) {
    clearTimeout(timer);
    $("#flash_message").html(msg);
    $("#flash_shower").fadeIn(300);
    timer = setTimeout(function () {
        $("#flash_shower").fadeOut(300)
    }, 3000)
}