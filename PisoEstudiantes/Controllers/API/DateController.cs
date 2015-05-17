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
        [System.Web.Http.HttpPost]
        public IHttpActionResult createDate([FromBody] Date date)
        {
            date.UserEmail = User.Identity.Name;
            return Ok();
        }
    }
}
