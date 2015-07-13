
//$(function () {
//    $("#center").find('*').each().bind("mousemove", function (event) {
//        $(this).find("div.tooltip").css({
//            top: event.pageY + 50 + "px",
//            left: event.pageX + 5 + "px"
//        }).show();
//    })

//        .bind("mouseout", function () {
//            $("div.tooltip").hide();
//        });
//});


$(function () {
    $("#center").find('div.bookHover').each(function () {
        $(this).bind("mousemove", function (event) {
            $(this).find("div.tooltip").css({
                top: event.pageY + 50 + "px",
                left: event.pageX + 5 + "px"
            }).show();
        });

        $(this).bind("mouseout", function () {
            $(this).find("div.tooltip").hide();
        });
    });
});
