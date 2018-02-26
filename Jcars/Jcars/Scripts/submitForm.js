$(document).ready(function () {
    $('.page').click(function () {

        var pageNumber = $(this).attr("data-pageNum");
        var pageSize = $(this).attr("data-pageSize");
        $('.pageNumProperty').val(pageNumber);

        $.ajax({
            type: "get",
            url: "/home/index?pageNum=" + pageNumber + "&pageSize=" + pageSize,
            success: function () {
                $('.criteriaForm').submit();
            },
            error: function () {
                alert("FAIL");
            }
        });
    });
});

$(document).on('change', '.pro_pag_tf1', function (e) {
    var pageSize = this.options[e.target.selectedIndex].text
    $('.page').attr("data-pageSize", pageSize);

    $.ajax({
        type: "get",
        url: "/home/index?pageSize=" + pageSize,
        success: function () {
            $('.criteriaForm').submit();
        },
        error: function () {
            alert("FAIL");
        }
    });
});