jQuery(function () {
    $('.addtocart').click(function () {
        var btn = $(this);
        btn.prop('disabled', true);
        setTimeout(function () {
            btn.prop('disabled', false);
        }, 5 * 1000);
        // remove any existing notification
        $(".alert.alert-danger").remove();
        $(".alert.alert-success").remove();
        var price =$(".aa-product-view-price").data("price");
        if (price == 0)
        {
            var errorjson = {
                errortext: "Sorry this product can't add to cart due to 0 price"
            };
            var successtemplhtml = $("#notification-template").html();
            var successtemplate = Handlebars.compile(successtemplhtml);
            var successhtml = successtemplate(errorjson);
            $("#notification").append(successhtml);
            return false;
        }
        var btnaddtocart = $(this);
        var productid = $('#productid').val();
        var colorsizeid = $('#productcolorsizeid').val();
        var productqty = $('#productquantity').val();
        var colorid = $("#productcolorid").find(':selected').data("productcolorid");
        var colorcode = $("#productcolorid").find(':selected').val();
        var productsize = $("#productcolorsizeid").find(':selected').data("productsize");
        //var productqty =120;

        $.ajax({
            url: '/mycart/addtocart/',
            data: 'productid=' + productid.toString() + '&colorsizeid=' + colorsizeid.toString() + '&quantity=' + productqty.toString() + '&colorid=' + colorid,
            type: 'GET',

        }).done(function (data) {

            if (data.error) {
                switch (data.errorcode) {
                    case 0: // Exception Occured.
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 1: // Invalid Request.
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 2: // Already in cart.
                        $(btnaddtocart).html("ALREADY IN CART");
                        $(btnaddtocart).removeClass('addtocart');
                        var errorjson = {
                            successtext: data.errortext
                        };
                        var successtemplhtml = $("#success-notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        var productname = data.productname;
                        var price = data.productprice;
                        var cid = data.cartid;
                        var producturl = data.productlink;
                        var count = parseInt($("#cart-count").text()) - 1;
                        var p = parseFloat($("#" + cid).find("#btndeletemycart").data('cartprice'));
                        var q = parseFloat($("#" + cid).find("#btndeletemycart").data('cartquantity'));
                        var dcarttotal = parseFloat($("#cart-totall").data('carttotal'));
                        var tp = p * q;
                        var count = parseInt($("#cart-count").text()) - 1;
                        $("#cart-count").text(count);
                        var total = dcarttotal - tp;
                        $("#cart-totall").text("$" + total);
                        ($("#cart-totall").data('carttotal', total));
                        $("#"+cid).remove();
                        var productimage = data.imgpath;
                        var color = data.productcolor;
                        var colorname = data.colorname;
                        var productcode = data.productcode;
                        var previoustotal = parseFloat($("#cart-totall").data("carttotal"));
                        var carttotal = parseFloat(price) * parseFloat(productqty);
                        var cartcount = parseInt($("#cart-count").html());
                        if (cartcount != 0 && cartcount != null) {
                            carttotal = carttotal + previoustotal
                        }
                        $("#cart-totall").text("$" + carttotal.toString());
                        ($("#cart-totall").data('carttotal', carttotal));
                        cartcount = cartcount + 1;
                        $("#cart-count").html(cartcount.toString());
                        $(".aa-cartbox-summary ul").prepend('<li id="' + cid + '"><a class="aa-cartbox-img" href="/product/' + producturl + '"><img src="' + productimage + '" alt="img"></a><div class="aa-cartbox-info"><h4><a href="/product/' + producturl + '">' + productname + '</a></h4> <h4><a href="/product/' + producturl + '">' + productcode + '</a></h4><h4><span class="colorbox" style="background-color:' + color + ';"></span><a class="colorname" href="/product/' + producturl + '">' + colorname + '</a></h4><h4><span>' + productsize + '</span><span class="price">' + productqty + ' x' + '$' + price.toFixed(2) + '</span></h4><a href="#" data-cartprice="' + price + '" data-cartquantity="' + productqty + '" data-cartid="' + cid + '" class="remove removebutton" id="btndeletemycart"><fa class="fa fa-close"></fa></a></div></li>');
                        break;
                    case 3: // no stock available.
                        //$("#notification").removeClass("alert alert-success hide").addClass("alert alert-danger");
                        //$("#noti-text").html(data.errortext);
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    default:
                        break;
                }
                return false;
            }
            $(btnaddtocart).html("ADDED IN CART");
            $(btnaddtocart).removeClass('addtocart');
            var successjson = {
                successtext: data.sucesstext
            };
            var successtemplhtml = $("#success-notification-template").html();
            var successtemplate = Handlebars.compile(successtemplhtml);
            var successhtml = successtemplate(successjson);
            $("#notification").append(successhtml);
            $("#cartempty").remove();
            var productname = data.productname;
            var price = data.productprice;
            var cid = data.cartid;
            var producturl = data.productlink;
            var productimage = data.productimage;
            var color = data.productcolor;
            var colorname = data.colorname;
            var productcode = data.productcode;
            var previoustotal = parseFloat($("#cart-totall").data("carttotal"));
            var carttotal = parseFloat(price) * parseFloat(productqty);
            var cartcount = parseInt($("#cart-count").html());
            if (cartcount != 0 && cartcount != null)
            {
                carttotal = carttotal + previoustotal
            }
            $("#cart-totall").text("$" + carttotal.toFixed(2).toString());
            ($("#cart-totall").data('carttotal', carttotal));
            cartcount = cartcount + 1;
            $("#cart-count").html(cartcount.toString());
            $(".aa-cartbox-summary ul").prepend('<li id="' + cid + '"><a class="aa-cartbox-img" href="/product/' + producturl + '"><img src="' + productimage + '" alt="img"></a><div class="aa-cartbox-info"><h4><a href="/product/' + producturl + '">' + productname + '</a></h4> <h4><a href="/product/' + producturl + '">' + productcode + '</a></h4><h4><span class="colorbox" style="background-color:' + color + ';"></span><a class="colorname" href="/product/' + producturl + '">' + colorname + '</a></h4><h4><span>' + productsize + '</span><span class="price">' + productqty + ' x' + '$' + price.toFixed(2) + '</span></h4><a href="#" data-cartprice="' + price + '" data-cartquantity="' + productqty + '" data-cartid="' + cid + '" class="remove removebutton" id="btndeletemycart"><fa class="fa fa-close"></fa></a></div></li>');
                            
            return false;
        });

        return false;
    });
   
        
    $('.addwishlist').click(function () {
        var btn = $(this);
        btn.prop('disabled', true);
        setTimeout(function () {
            btn.prop('disabled', false);
        }, 5 * 1000);
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
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 1: // Invalid Request.
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 2: // Already in cart.
                        $(product).prop('title', 'ALREADY IN WISHLIST');
                        $(product).prop('data-original-title', 'ALREADY IN WISHLIST');
                        break;
                    default:
                        break;
                }
                return false;
            }

            $(product).prop('title', 'ADDED IN WISHLIST');
            $(product).prop('data-original-title', 'ADDED IN WISHLIST');
            return false;
        });

        return false;
    });

    $('.addwishlistdetail').click(function () {
        $(".alert.alert-danger").remove();
        $(".alert.alert-success").remove();
        $(this).prop('disabled',true);
        setTimeout(function () {
            $(this).prop('disabled', false);
        }, 5000);   // enable after 2 seconds
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
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 1: // Invalid Request.
                        var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);
                        break;
                    case 2: // Already in cart.
                        $(product).html('ALREADY IN WISHLIST');
                         var errorjson = {
                            errortext: data.errortext
                        };
                        var successtemplhtml = $("#notification-template").html();
                        var successtemplate = Handlebars.compile(successtemplhtml);
                        var successhtml = successtemplate(errorjson);
                        $("#notification").append(successhtml);

                        break;
                    default:
                        break;
                }
                return false;
            }
            $(product).html('ADDED IN WISHLIST');
            var successjson = {
                successtext: data.sucesstext
            };
            var successtemplhtml = $("#success-notification-template").html();
            var successtemplate = Handlebars.compile(successtemplhtml);
            var successhtml = successtemplate(successjson);
            $("#notification").append(successhtml);
            return false;
        });

        return false;
    });

    $('.productcolorbox').click(function () {
        var productcolorid = $(this).data('productcolorid');
        var size = $("#prosize").val();

        if (productcolorid)
        {
            $('#' + productcolorid.toString()).find('option').removeAttr('selected');
            $('#' + productcolorid.toString()).find("[data-productsize='" + size + "']").attr('selected', 'selected');

            var html = $('#' + productcolorid.toString()).html();
            $("#productcolorsizeid").html(html);
            $(".select2OptionPicker").remove();
            $("#productcolorsizeid").select2OptionPicker();
            
            return false;
        }
        return false;
        
    });

});