using PisoEstudiantes.Models;
using PisoEstudiantes.Models.BO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PisoEstudiantes.Controllers
{
    public class PisosController : Controller
    {
        private BOFlat flatModel = new BOFlat();
        private BOEmail emailModel = new BOEmail();
        // GET: Pisos
        public ActionResult Alquiler()
        {
            return View();
        }

        //POST: Pisos 
        [HttpPost]
        public ActionResult Alquiler(AnnouncementViewModel model){

            if (ModelState.IsValid)
            {
                Owner owner = new Owner();
                owner.Email = User.Identity.Name;
                Flat f = new Flat(model.province, model.city, model.postal_code, model.address, model.description, model.tittle,
                model.bedrooms, owner, model.main_img, model.rentPerMonth, model.bathrooms, model.bedrooms_availables,
                model.minimum, model.property_type, model.avialableDate);
                if (flatModel.insertFlat(f))
                {
                    ModelState.AddModelError("", "ha ido bien");
                }
                else
                    ModelState.AddModelError("", "ha ido mal");
                /*ModelState.AddModelError("", "@model.inHome" + model.rentPerMonth + model.province + model.city + model.address + model.postal_code + model.avialableDate+model.minimum+model.bedrooms+
                model.bathrooms + model.property_type + model.bedrooms_availables+model.tittle+model.description+model.main_img);*/
            }
            return View(model);
        }
    }
}