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
    public class DateController : ApiController
    {
        private BODate bd = new BODate();
        [System.Web.Http.HttpPost]
        public IHttpActionResult createDate([FromBody] Date date)
        {
            date.UserEmail = User.Identity.Name;
            if(bd.createDate(date))
                return Ok("Su cita ha sido reservada correctamente. Recuerde que puede anular la cita, asi como el propietario del inmueble.");
            return NotFound();
        }
    }
}
