$(".position-card").dblclick(function(e) {
    const src = $(this).attr("data-src");
    window.location.href = src;
});

//Functionality for Search
$(".form-control").on("keyup", function () {
    var input = $(this).val().toUpperCase();

    $(".card-title").each(function () {
        if ($(this).data("string").toUpperCase().indexOf(input) < 0) {
            $(this).hide();
        } else {
            $(this).show();
        }
    })
});
