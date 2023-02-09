$(document).ready(function () {
    $(".position-card").dblclick(function () {
    const src = $(this).attr("data-src");
    window.location.href = src;
    });
});