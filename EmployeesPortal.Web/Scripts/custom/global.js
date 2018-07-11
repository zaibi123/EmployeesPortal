$(function () {

    $(document).on('click', '.loadbookmenu', function () {

        var postcatid = $(this).attr('data-postcategory');

        $.getJSON("/home/LoadChapters/" + postcatid, function (data) {
          
            //alert(data);
               $.each(data, function (name, key) {
                   var lilist = '<li>' + key + '</li>';
                   $('.hidden-ul').append(lilist);
              });
                //$("<table border='1'><tr><td>" + val.name + "</td><td>" + val.address
                //       + "</td></tr></table>").appendTo("#tbPerson");
               
           
        });
    });
});