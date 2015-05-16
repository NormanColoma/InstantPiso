using PisoEstudiantes.Models.BO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PisoEstudiantes.Controllers.API
{
    public class ScheduleController : ApiController
    {
        private BOUser bo = new BOUser();
        private BOFlat bf = new BOFlat();

        public IHttpActionResult getSchedule(int id)
        {
            return Ok(bf.getSchedule(id));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult createSchedule([FromBody] List<Schedule> schedule)
        {
            return Ok(bf.addSchedule(schedule));
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult createSchedule([FromBody] List<int> schedules)
        {
            if (bf.deleteAllSchedule(schedules))
                return Ok("Se han borrado los horarios correctamente");
            return NotFound();
        }
    }
}
