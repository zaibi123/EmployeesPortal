$(document).ready(function () {
    //$(document).on('click', '#btndeletecartfromlist', function (){
    $(".deletecartitem").click(function () {
    
        // remove any existing notification.
        //removeNotification();

        var rowscount = $(this).closest("tbody").find('tr').length;
        var tr = $(this).closest("tr");
        var href = $(this).data("link");
        swal({
            title: "Delete Cart Item",
            text: "Are you sure, you want to delete this product from the cart?",
            type: "error",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonColor: "#2196F3",
            showLoaderOnConfirm: true
        },
        function () {

            $.ajax({
                url: href,
                data: '',
                type: 'GET',
            }).done(function (data) {

                if (data.error) {
                    var source = $("#error-notification-template").html();
                    var template = Handlebars.compile(source);
                    var html = template(data);
                    $("#mycartviewform").prepend(html);
                    return false;
                }

                // remove selected product from the list.
                $(tr).remove();
                //

                //
                if (rowscount == 2) {
                    var source = $("#no-data-found-template").html();
                    var template = Handlebars.compile(source);
                    var html = template();
                    $('#DataTables_Table_mycart tbody').prepend(html);
                }

                swal({
                    title: "The selected product has been removed from my cart successfully!",
                    confirmButtonColor: "#2196F3",
                    type: "success",

                });
                window.setTimeout(function () { window.location.href = window.location.href; }, 4000)
                return false;
                //return false;
            });
            //return false;
        });
        return false;
        });
        $(".quantity").numeric({
            allowMinus: false,
            allowThouSep: false
        });
});

