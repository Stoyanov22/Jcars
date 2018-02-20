$(document).ready(function () {
    $('.page').click(function () {

        var pageNumber = $(this).attr("data-pageNum");

        $.ajax({
            type: "get",
            url: "/home/index/pageNum=" + pageNumber,
            success: function () {
                $('.criteriaForm').submit();
            },
            error: function () {
                alert("FAIL");
            }
        });
    });
});