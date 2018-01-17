$(document).ready(function () {
    $(".deleteButton").click(function () {
        if (!confirm("Are you sure you want to delete this car ?")) {
            return false;
        }

        var carID = $(this).attr("value");
        var parent = $(this).parent('td').parent('tr');
        $.ajax({
            type: "post",
            url: "/Car/Delete",
            data: { id: carID },
            success: function () {
                parent.fadeOut();
            },
            error: function () {
                alert("You couldn't delete this");
            }
        });
    });
});