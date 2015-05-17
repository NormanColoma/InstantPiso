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

    
    var bookingDate = { BookingDate: date, IDFlat: $(".f-id").text(), IDOwner: $(".f-owner").text() }
    var port = location.port;
    var uri = "http://localhost:" + port + "/api/Date";
    var data = JSON.stringify(bookingDate);

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