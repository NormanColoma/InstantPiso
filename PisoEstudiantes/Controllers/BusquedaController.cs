using PisoEstudiantes.Models.BO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PisoEstudiantes.Controllers
{
    public class BusquedaController : Controller
    {
        private BOFlat flatModel = new BOFlat();
        // GET: Busqueda
        public ActionResult Pisos(string id)
        {
            List<Flat> flats = flatModel.getFlatsByProvince(id);
            ViewData["city"] = id;
            ViewData["num"] = flats.Count;
            return View(flats);
        }
    }
}