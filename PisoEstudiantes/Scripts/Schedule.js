$(document).ready(function () {
    $(".add-schedule").click(function () {
        var size = $(".schedule-list").find("li").size();
        addSchedule(size);
    })

    $(".submit-schedule").click(function () {
        createSchedule();
    })

    $(".remove-all-schedule").click(function () {
        var ids = [];
        $(".current-schedule li").each(function () {
            ids.push(parseInt($(this).attr("class")));
        })
        removeSchedule(ids,"all");
    })

    $(".remove-selected-schedule").click(function () {
        var ids = [];
        $(".current-schedule li").each(function () {
            if ($(this).find("input[type=checkbox]").is(':checked'))
                ids.push(parseInt($(this).attr("class")));
        })
        removeSchedule(ids);
    })

})

function addSchedule(size) {
    var n = size + 1;
    var new_schedule = "<li><p>Horario "+n+"</p><select class='select day-schedule'><option>Día</option><option>Lunes</option><option>Martes</option><option>Miércoles</option><option>Jueves</option><option>Viernes</option><option>Sábado</option><option>Domingo</option></select><select class='select hour-schedule'><option>Hora</option><option>De 8-9</option><option>De 9-10</option><option>De 10-11</option><option>De 11-12</option><option>De 12-13</option><option>De 13-14</option><option>De 14-15</option><option>De 15-16</option><option>De 16-17</option><option>De 17-18</option><option>De 18-19</option><option>De 19-20</option><option>De 20-21</option></select><span><i class='fa fa-close remove-schedule'></i></span></li>";
    $(".schedule-list").append(new_schedule);
    $(".remove-schedule").click(function () {
        $(this).closest("li").remove();
    })
    
}

function createSchedule() {
   
    var days = [];
    var hours = [];
    var id = $(".id-flat").text();
    var schedule = [];
    var sched;
    
    $(".day-schedule option:selected").each(function () {
        var day = $(this).text();
        days.push(day);
    })

    $(".hour-schedule option:selected").each(function () {
        var hour = $(this).text();
        hours.push(hour);
    })
    for (var i = 0; i < days.length; i++) {  //Creamos la lista de schedule para pasársela al método
        var new_schedule = days[i] + " " + hours[i];
        if (!searchSchedule(new_schedule)) {
            var sched = { day: days[i], hour: hours[i], idflat: id };
            schedule.push(sched);
        }
        else {
            showAlert("ko", 'El horario: "' + new_schedule + '" ya está establecido')
        }
    }
    if (schedule.length > 0) {
        var port = location.port;
        var uri = "http://localhost:" + port + "/api/Schedule";
        var data = JSON.stringify(schedule);
        $.ajax({
            type: "POST",
            url: uri,
            dateType: "json",
            contentType: "application/json",
            data: data,
            success: function (result) {
                if (result) {
                    refreshSchedule("add",[])
                    showAlert("ok", "Sus horarios de visita han sido establecidos correctamente")
                }
                else
                    showAlert("ko", "Sus horarios de visita no han podido ser establecidos")
            },
            error: function () {
                alert("mal")
            }
        });
    }
}

function removeSchedule(ids,opt) {
    var port = location.port;
    var uri = "http://localhost:" + port + "/api/Schedule";
    var data = JSON.stringify(ids);
    $.ajax({
        type: "DELETE",
        url: uri,
        dateType: "json",
        contentType: "application/json",
        data: data,
        statusCode:{
            200: function (result) {
                if (opt == "all")
                    refreshSchedule("clear",ids);
                else
                    refreshSchedule("remove",ids);
                showAlert("ok", result)
            },
            404: function () {
                showAlert("ko", "No se han podido borrar todos los horarios")
            }
        },
        error: function () {
            alert("mal")
        }
    });
}

function showAlert(status, message) {
    if (status == "ok") {
        $(".alert").removeClass("alert-danger").addClass("alert-success")
    }
    else {
        $(".alert").removeClass("alert-success").addClass("alert-danger")
    }
    $(".alert").find("p").text(message);
    $(".alert").show();
    $(".alert").fadeIn('slow').delay(4000).fadeOut('slow');
}

function refreshSchedule(action,ids) {
    switch (action) {
        case "clear": 
            $(".current-schedule ul").empty();
            var li = "<li class='empty-schedule'>Sin horarios</li>";
            $(".current-schedule ul").append(li);
            break;
        case "add":
            var id = $(".id-flat").text();
            loadSchedule(id);
            break;
        case "remove":
            for (var i = 0; i < ids.length; i++) {
                $(".current-schedule ." + ids[i]).remove();
            }
            break;
    }
    
}

function loadSchedule(id) {
    var port = location.port;
    var uri = "http://localhost:" + port + "/api/Schedule/" + id;
    $(".empty-schedule").remove();
    $.getJSON(uri)
        .done(function (data) {
            var list = data
            for (var i = 0; i < list.length; i++) {
                $("." + list[i].ID).remove();
                var new_schedule = "<li class='" + list[i].ID + "'>" + list[i].Day + " " + list[i].Hour + "<span class='schedule-selected'><input type='checkbox' /></span></li>";
                $(".current-schedule ul").append(new_schedule);
            }
        })
        .fail(function (jqXHR, textStatus, err) {

        });
}

function searchSchedule(schedule) {
    var found = false;
    $(".current-schedule li").each(function () {
        var current = $(this).text();
        if (current == schedule) {
            found = true;
            return false;
        }
    })

    return found;
}