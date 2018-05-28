jQuery(function () {
    //$(document).ready(function () {
    //    var count = $("#cart-count").text();
    //    if (count == 0) {
    //        $("#place-order-btn").attr('disabled', true);
    //        return false;

    //    }
    //    else
    //    {
    //        $("#place-order-btn").attr('disabled', false);
    //    }
    //    $("#place-order-btn").click(function () {
    //        $(this).attr('disabled', true);
    //    });
    //});
    $('#btnlogincheckout').click(function () {
        
        var username, password, rememberme;

        username = $('#username').val();
        password = $('#password').val();
        if ($('#rememberme').is(':checked')) {
            rememberme = 1;
        } else {
            rememberme = 0;
        }

        $.ajax({
            url: '/account/logincheckout/',
            data: 'username=' + username + '&password=' + password + '&remember='+rememberme.toString(),
            type: 'POST',

        }).done(function (data) {
            if (data.success) {
                window.location = "/home/checkout";
                return true;
            } else {
                sweetAlert("Login failed",data.errortext,"error");
            }
        });

        return false;
    });
});