
$(function () {
    $(document).ajaxStart(function () {
        $("#spinner").show();
    });
    $(document).ajaxError(function () {
        $("#spinner").hide();
    });
    $(document).ajaxComplete(function () {
        $("#spinner").hide();
    });
});