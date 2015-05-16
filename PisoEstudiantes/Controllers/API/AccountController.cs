using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PisoEstudiantes.Models.DTO;
using PisoEstudiantes.Models.BO;
using Newtonsoft.Json.Linq;
using System.Collections;
using Newtonsoft.Json;
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



        
       
    }
}
