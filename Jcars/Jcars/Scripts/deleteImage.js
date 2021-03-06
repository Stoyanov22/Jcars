﻿$(document).ready(function () {
    $(".deleteButton").click(function () {
        if (!confirm("Are you sure you want to delete this image ?")) {
            return false;
        }

        var fileID = $(this).attr("value");
        var carID = $(this).attr("data-value");
        var parent = $(this).parent('div');
        $.ajax({
            type: "post",
            url: "/Car/DeleteImage",
            data: { id: fileID, carID : carID },
            success: function () {
                parent.fadeOut();
            },
            error: function () {
                alert("You couldn't delete this");
            }
        });
    });
});