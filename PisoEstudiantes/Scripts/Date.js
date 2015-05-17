$(document).ready(function () {
    $(".book-date").click(function () {
        var date = $(".select option:selected").text();
        createDate(date);
    })
})

function createDate(date) {
    if (date == "Selecciona la cita")
        $(".date-danger").show();
    else
        $(".date-danger").hide();

    var date = { Date: date, IDFlat: $(".f-id"), IDOwner: $(".f-owner") }
    var port = location.port;
    var uri = "http://localhost:" + port + "/api/Date";
    var data = JSON.stringify(date);
    $.ajax({
        type: "POST",
        url: uri,
        dateType: "json",
        contentType: "application/json",
        data: data,
        success: function (result) {
           alert(result)
        },
        error: function () {
            alert("mal")
        }
    });
}