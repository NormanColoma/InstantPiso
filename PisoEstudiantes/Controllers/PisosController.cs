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
        private BOUser userModel = new BOUser();
        // GET: Pisos
        public ActionResult Alquiler()
        {
            User leaseholder = userModel.getUser(User.Identity.Name);
            if(leaseholder.Leaseholder == "yes")
                TempData["leaseholder"] = "yes";
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
                    userModel.insertOwner(owner);
                    return RedirectToAction("MisPisos", "Account");
                }
                else
                    ModelState.AddModelError("", "No se ha podido publicar el anuncio, inténtelo nuevamente");
                
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            Flat f = flatModel.getDetails(id);
            return View(f);
        }
    }
}