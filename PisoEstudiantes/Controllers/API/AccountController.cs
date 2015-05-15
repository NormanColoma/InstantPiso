using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PisoEstudiantes.Models.DTO;
using PisoEstudiantes.Models.BO;
namespace PisoEstudiantes.Controllers.API
{
    public class AccountController : ApiController
    {
        private BOUser bo = new BOUser();
        private BOFlat bf = new BOFlat();
        public IHttpActionResult getPassword(string id)
        {
            User u = new User(User.Identity.Name, id);
            return Ok(bo.checkPassword(u));
        }

        public IHttpActionResult createSchedule(string [] days, string [] hours, int flat){
            List<Schedule> schedule = new List<Schedule>();
            for (int i = 0; i < days.Length; i++)
            {
                Schedule s = new Schedule(days[i], hours[i]);
                s.IDFlat = flat;
                schedule.Add(s);
            }
            return Ok(bf.addSchedule(schedule));
        }
    }
}
