$(".position-card").click(function(e) {
    const src = $(this).attr("data-src");
    window.location.href = src;
});