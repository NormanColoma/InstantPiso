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
    public class NotificationController : ApiController
    {
        private BONotification bn = new BONotification();

        [System.Web.Http.HttpPost]
        public IHttpActionResult checkNotification([FromBody] int id)
        {
            Notification n = new Notification();
            n.ID = id;
            n.Check = true;
            bn.updateNotification(n);
            return Ok();
        }
    }
}
