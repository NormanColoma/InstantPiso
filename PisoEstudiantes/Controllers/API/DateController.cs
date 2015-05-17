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
        private BOUser bu = new BOUser();
        private BONotification bn = new BONotification();
        [System.Web.Http.HttpPost]
        public IHttpActionResult createDate([FromBody] Date date)
        {
            string message_to_renter = "Tienes una cita reservada el "+date.BookingDate;
            string message_to_owner = "Han reservado una nueva cita para el " + date.BookingDate;
            User renter = new User();
            renter.Email = User.Identity.Name;
            User owner = new User();
            owner.Email = bu.getOwnerEmail(date.IDOwner);
            Notification n_to_renter = new Notification(message_to_renter,false,renter,"Cita para visita");
            Notification n_to_owner = new Notification(message_to_owner, false, owner,"Visita");
            n_to_owner.IDFlat = date.IDFlat;
            n_to_renter.IDFlat = date.IDFlat;
            bn.createNotification(n_to_owner);
            bn.createNotification(n_to_renter);
            date.UserEmail = User.Identity.Name;
            if(bd.createDate(date))
                return Ok("Su cita ha sido reservada correctamente. Recuerde que puede anular la cita, asi como el propietario del inmueble.");
            return NotFound();
        }
    }
}
