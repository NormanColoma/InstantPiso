$(document).ready(function () {
    $(".check-notification").click(function () {
        var parent = $(this).closest(".notification");
        if ($(this).hasClass("fa-minus")) {
            $(this).removeClass("fa-minus").addClass("fa-plus");
            parent.find(".notification-body").hide();
            
            if ($(this).hasClass("unchecked")) {
                var id = parent.find(".notification-id").text();
                checkNotification(id);
            }   
        }
        else {
            $(this).removeClass("fa-plus").addClass("fa-minus");
            $(this).closest(".notification-body").show();
            parent.find(".notification-body").show();
        }
    })
})

function checkNotification(id) {
    
    var port = location.port;
    var uri = "http://localhost:" + port + "/api/Notification";
    var data = JSON.stringify(id);
    $.ajax({
        type: "POST",
        url: uri,
        dateType: "json",
        contentType: "application/json",
        data: data,
        success: function () {
            
        },
        error: function () {
            alert("mal")
        }
    });
}