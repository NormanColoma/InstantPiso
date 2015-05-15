$(document).ready(function () {
    $(".add-schedule").click(function () {
        var size = $(".schedule-list").find("li").size();
        addSchedule(size);
    })

   
})

function addSchedule(size) {
    var n = size + 1;
    var new_schedule = "<li><p>Horario "+n+"</p><select class='select day-schedule'><option>Día</option><option>Lunes</option><option>Martes</option><option>Miércoles</option><option>Jueves</option><option>Viernes</option><option>Sábado</option><option>Domingo</option></select><select class='select hour-schedule'><option>Hora</option><option>De 8-9</option><option>De 9-10</option><option>De 10-11</option><option>De 11-12</option><option>De 12-13</option><option>De 13-14</option><option>De 14-15</option><option>De 15-16</option><option>De 16-17</option><option>De 17-18</option><option>De 18-19</option><option>De 19-20</option><option>De 20-21</option></select><span><i class='fa fa-close remove-schedule'></i></span></li>";
    $(".schedule-list").append(new_schedule);
    $(".remove-schedule").click(function () {
        $(this).closest("li").remove();
    })
    $(".submit-schedule").click(function () {
        createSchedule();
    })
}

function createSchedule() {
    days = new Array();
    hours = new Array();
    $(".day-schedule option:selected").each(function () {
        var day = $(this).text();
        days.push(day);
    })

    $(".hour-schedule option:selected").each(function () {
        var hour = $(this).text();
        hours.push(hours);
    })
}