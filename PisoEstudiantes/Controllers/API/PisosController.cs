using PisoEstudiantes.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PisoEstudiantes.Controllers.API
{
    public class PisosController : ApiController
    {
        private BOFlat bo = new BOFlat();
        public IHttpActionResult DeleteFlat(int id)
        {
            return Ok(bo.deleteFlat(id));
        }
    }
}
