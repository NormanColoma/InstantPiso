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
        statusCode: {
            200: function () {
                window.location.href = "http://localhost:" + port + "/Pisos/Confirmacion/Cita";
            },
            404: function () {
                alert("Su cita no podido ser creada")
            }
        },
        error: function () {
            alert("mal")
        }
    });
}