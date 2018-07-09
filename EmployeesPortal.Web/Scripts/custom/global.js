$(function(){

    $(document).on('click', '.loadbookmenu', function () {
        
        var postcatid = $(this).attr('data-postcategory');
        alert(postcatid);
        $.ajax({
            url: '/home/LoadChapters/',
            data: {
                id: postcatid
            },
            type: 'GET',

        }).done(function (data) {
            if (data.success==true) {
                alert("Enter");
                $.each(data.chapterlist, function (key, value) {
                    alert(value);
                });
               
            }
        });
    });
});