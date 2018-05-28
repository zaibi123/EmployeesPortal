jQuery(function () {
    $(".aa-subscribe-form").submit(function () {
        $('.fa-paper-plane').click();
        return false;
        
    });
    $(document).on('click', '.fa-paper-plane', function () {
        //romove any existing notification
        $("#successdiv").remove();
        $("#errordiv").remove();
        var email = $("#subscriberemail").val();
        var url = '/newsletter/newslettersub/';
        var data = "email=" + email.toString();
        if (email !== "") {  // If something was entered
            if (isValidEmailAddress(email)) {

                $.ajax({
                    url: url,
                    data: data,
                    type: 'GET',

                }).done(function (data) {
                    if (data.error) {
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#error-notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#newsnotification").append(successhtml);
                        $("#subscriberemail").val('');
                        return false;
                    }
                    var successjson = {
                        successtext: data.successtext
                    };
                    var successtemplhtml = $("#success-notification-template").html();
                    var successtemplate = Handlebars.compile(successtemplhtml);
                    var successhtml = successtemplate(successjson);
                    $("#newsnotification").append(successhtml);
                    $("#subscriberemail").val('');
                    return false;
                });

            } else {
                //$("label#email_error").show(); //error message
                //$("input#sc_email").focus();   //focus on email field
                return false;
            }
        }
    });

    $('.quickviewproduct').click(function () {
        var productid = $(this).data('productid');

        $.ajax({
            url: '/product/quickview/',
            data: 'productid=' + productid.toString(),
            type: 'GET',

        }).done(function (data) {
            if (data.error) {
                return false;
            }
            return false;
        });

        return false;
    });
});

function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^(("[\w-+\s]+")|([\w-+]+(?:\.[\w-+]+)*)|("[\w-+\s]+")([\w-+]+(?:\.[\w-+]+)*))(@((?:[\w-+]+\.)*\w[\w-+]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][\d]\.|1[\d]{2}\.|[\d]{1,2}\.))((25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\.){2}(25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\]?$)/i);
    return pattern.test(emailAddress);
};