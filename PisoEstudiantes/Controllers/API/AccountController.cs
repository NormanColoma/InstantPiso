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
        public IHttpActionResult getPassword(string id)
        {
            User u = new User(User.Identity.Name, id);
            return Ok(bo.checkPassword(u));
        }
    }
}
