using PisoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PisoEstudiantes.Controllers
{
    public class PisosController : Controller
    {
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
                ModelState.AddModelError("", "@model.inHome" + model.rentPerMonth + model.province + model.city + model.address + model.postal_code + model.avialableDate+model.minimum+model.bedrooms+
                model.bathrooms + model.property_type + model.bedrooms_availables+model.tittle+model.description+model.main_img);
            }
            return View(model);
        }
    }
}