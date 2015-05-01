using PisoEstudiantes.Models;
using PisoEstudiantes.Models.BO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Alquiler(AnnouncementViewModel model, HttpPostedFileBase main_img){

            if (ModelState.IsValid)
            {
                if (main_img != null)
                {
                    string pic = System.IO.Path.GetFileName(main_img.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/Content/img"), pic);
                    // file is uploaded
                    main_img.SaveAs(path);
                }
                Owner owner = new Owner();
                owner.Email = User.Identity.Name;
                Flat f = new Flat(model.province, model.city, model.postal_code, model.address, model.description, model.tittle,
                model.bedrooms, owner, main_img.FileName, model.rentPerMonth, model.bathrooms, model.bedrooms_availables,
                model.minimum, model.property_type, model.avialableDate);
                if (flatModel.insertFlat(f))
                {
                    ModelState.AddModelError("", "ha ido bien" + main_img.FileName);
                }
                else
                    ModelState.AddModelError("", "ha ido mal");   
            }
            return View(model);
        }
    }
}