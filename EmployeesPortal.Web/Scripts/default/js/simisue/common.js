function init() {
    window.addEventListener('scroll', function (e) {
        var distanceY = window.pageYOffset || document.documentElement.scrollTop,
            shrinkOn = 300,
            header = document.querySelector("header");
        if (distanceY > shrinkOn) {
            classie.add(header, "smaller");
        } else {
            if (classie.has(header, "smaller")) {
                classie.remove(header, "smaller");
            }
        }
    });
}
window.onload = init();

// Toggle Search Action.
$(function () {
    var $searchlink = $('#searchtoggl i');
    var $searchbar = $('#searchbar');

    $('a#searchtoggl').on('click', function (e) {
        e.preventDefault();

        if ($(this).attr('id') == 'searchtoggl') {
            if (!$searchbar.is(":visible")) {
                // if invisible we switch the icon to appear collapsable
                $searchlink.removeClass('fa-search').addClass('fa-search-minus');
            } else {
                // if visible we switch the icon to appear as a toggle
                $searchlink.removeClass('fa-search-minus').addClass('fa-search');
            }

            $searchbar.slideToggle(300, function () {
                // callback after search bar animation
            });
        }
    });

    $('#searchform').submit(function (e) {
        e.preventDefault(); // stop form submission
    });
});

// Header delete cart action.
jQuery(function () {
    $(document).on('click', '#btndeletemycart', function () {
        // remove any existing notification.
        //removeNotification();

        var li = $(this).closest("li");
        var id = $(this).data('cartid');
        var p = parseFloat($(this).data('cartprice'));
        var q = parseFloat($(this).data('cartquantity'));
        var carttotal = parseFloat($("#cart-totall").data('carttotal'));
        $.ajax({
            url: '/Mycart/DeleteConfirmed/' + id,
            data: '',
            type: 'GET',
        }).done(function (data) {

            //get price and quanity before remove

            var tp = p * q;
            // remove selected product from the cart.
            $(li).remove();
            var count = parseInt($("#cart-count").text()) - 1;
            $("#cart-count").text(count);
            var total = carttotal - tp;
            $("#cart-totall").text("$" + total);
            ($("#cart-totall").data('carttotal', total));
            if (count == 0) {
                $(".aa-cartbox-summary ul").prepend('<li id="cartempty"> Your cart is empty. </li>');
            }
            if ($("#hiddencart").length)
            {
                window.location.href = window.location.href;
            }
            return false;

        });
        return false;
    });
});

jQuery(function () {
    $(document).on("click", ".searchproduct", function () {
        var searchstring = $(".searchstring").val();
        var newsearchstring = searchstring.replace(/[^a-zA-Z0-9\s]/g, '');
        var url = "/search/" + newsearchstring;
        if (newsearchstring!="") {
            window.location.href = url;
        }
        //$.ajax({
        //    url: '/search/',
        //    data: 'searchstring=' + searchstring,
        //    type: 'GET',
        //    success: function (result) {
        //        return false;
        //    }
        //});
        return false;
    });
});
