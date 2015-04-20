using PisoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PisoEstudiantes.Models.DTO;
using PisoEstudiantes.Models.BO;
using System.Web.Security;
namespace PisoEstudiantes.Controllers
{
    public class AccountController : Controller
    {
        private BOUser userModel = new BOUser();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User u = new User(model.Email, model.Password);
                var user = userModel.login(u);
                if (user != false)
                {
                   FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña no válidos."+user);
                }
            }
            
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }
    }




}