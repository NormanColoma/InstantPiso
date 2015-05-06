using PisoEstudiantes.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PisoEstudiantes.Controllers
{
    public class HomeController : Controller
    {
        private BOFlat flatModel = new BOFlat();
        // GET: Home
        public ActionResult Index()
        {

            return View(flatModel.getLastFlats());
        }
    }
}