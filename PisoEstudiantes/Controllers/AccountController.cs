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
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User u = new User(model.Email, model.Password);
                var user = userModel.login(u);
                if (user != false)
                {
                    var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, model.Email),
                        },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name, ClaimTypes.Role);

                    //Necesario crear el interfaz para poder tener acceso a la operación SignIn
                    IOwinContext owinContext = HttpContext.GetOwinContext();
                    IAuthenticationManager authenticationManager = owinContext.Authentication;
                    authenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña no válidos.");
                }
            }
            
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public ActionResult LogOff()
        {
            IOwinContext owinContext = HttpContext.GetOwinContext();
            IAuthenticationManager authenticationManager = owinContext.Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Manage()
        {
            User u = userModel.getUser(User.Identity.Name);
            AccountViewModel avm = new AccountViewModel();
            avm = avm.returnAccount(u);
            if (TempData["Redirected"] != null)
                ViewData["Success"] = "Su perfil ha sido acutalizado";
            return View(avm);
        }
        
        [HttpPost]
        public ActionResult Manage(AccountViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User current = userModel.getUser(User.Identity.Name);
                string email = current.Email;
                if (model.Password == null)
                    model.Password = current.Password;
                User u = new User(model.Email, model.Name, model.Surname, model.Phone, model.Password);
                if (userModel.updateUser(u, email))
                {
                    TempData["Redirected"] = true;
                    ViewData["Success"] = "Su perfil ha sido acutalizado";
                    return RedirectToAction("Manage", "Account");
                    
                }
                else
                {
                     ModelState.AddModelError("", "No se puede actualizar el perfil en estos momentos");
                }
                
            }
            return View(model);
        }
    }




}