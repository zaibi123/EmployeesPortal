jQuery(function () {
    
    $('.aa-add-card-btn').click(function () {
        var productid = $(this).data('productid');
        
        $.ajax({
            url: '/Dashboard/addtocart/',
            data: 'productid='+productid.toString(),
            type: 'POST',

        }).done(function (data) {

            if (data.error)
            {
                alert(data.errortext);
            }
            swal("", "", "success")

            //alert("added to cart...!");
            return false;
        });


        return false;
    });

    $('.addwishlist').click(function () {
        var productid = $(this).data('productid');
        alert(productid);

        return false;
    });

    $('.quickviewproduct').click(function () {
        var productid = $(this).data('productid');
        alert(productid);

        return false;
    });

});