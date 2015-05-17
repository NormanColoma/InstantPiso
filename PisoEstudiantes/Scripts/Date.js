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

    var date = {}
}