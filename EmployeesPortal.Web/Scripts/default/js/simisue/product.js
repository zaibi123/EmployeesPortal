jQuery(function () {
    $(document).on("click", ".addwishlist",function () {
        var product = $(this);
        var productid = $(this).data('productid');

        $.ajax({
            url: '/mycart/addwishlist/',
            data: 'id=' + productid.toString(),
            type: 'GET',

        }).done(function (data) {

            if (data.error) {
                switch (data.errorcode) {
                    case 0: // Exception Occured.
                        //alert(data.errortext);
                        break;
                    case 1: // Invalid Request.
                        //alert(data.errortext);
                        break;
                    case 2: // Already in cart.
                        $(product).prop('title', 'Added in Wishlist');
                        $(product).data('original-title', 'Added in Wishlist');
                        
                        break;
                    default:
                        break;
                }
                return false;
            }

            $(product).removeClass('active').addClass('active');
            $(product).prop('title', 'Added in Wishlist');
            $(product).data('original-title', 'Added in Wishlist');
            $(product).tooltip('hide');
            $(product).tooltip();

            return false;
        });

        return false;
    });

});