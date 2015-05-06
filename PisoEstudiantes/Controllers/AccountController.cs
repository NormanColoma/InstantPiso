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
        private BOEmail emailModel = new BOEmail();
        private BOFlat flatModel = new BOFlat();
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
                if (model.City == "0")
                    model.City = current.City;
                if (model.Age == "0")
                    model.Age = current.Age;
                if (model.Gender == "0")
                    model.Gender= current.Gender;
                User u = new User(model.Email, model.Name, model.Phone, model.Age, current.Leaseholder, model.Surname, model.Password,
               model.Gender, null, model.City);
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

        public ActionResult Close()
        {
            User u = userModel.getUser(User.Identity.Name);
            userModel.deleteUser(u);
            emailModel.mannageCenter(u, "canceled");
            return LogOff();
        }

        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string leaseHolder = "no";
                string city = null;
                string gender = null;
                string age = null;
                if (model.selectedAge != "0")
                    age = model.selectedAge;
                if (model.selectedCity != "0")
                    city = model.selectedCity;
                if (model.selectedGender != "0")
                    gender = model.selectedGender;
                if (model.Leaseholder)
                    leaseHolder = "yes";
                User u = new User(model.Email, model.Name, model.Phone, age, leaseHolder, model.Surname, model.Password,
                gender, null, city);
                if (userModel.insertUser(u))
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
                        IsPersistent = false
                    }, identity);
                    emailModel.mannageCenter(u, "created");
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Ya existe una cuenta asociada al email " + model.Email);
            }
            return View(model);
        }

        public ActionResult MisPisos()
        {

            return View(flatModel.getFlatsByOwner(User.Identity.Name));
        }

        public ActionResult updateFlat(int id)
        {
            AnnouncementViewModel fModel = new AnnouncementViewModel();
            ViewData["id"] = id;
            return View(fModel.returnFlat(id));
        }

        [HttpPost]
        public ActionResult updateFlat(AnnouncementViewModel model, int id, HttpPostedFileBase main_img)
        {
            Owner owner = new Owner();
            owner.Email = User.Identity.Name;
            if (main_img == null)
            {
                model.main_img = flatModel.getFlat(id).Profile;
            }
            else
            {
                string pic = System.IO.Path.GetFileName(main_img.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/img"), pic);
                // file is uploaded
                main_img.SaveAs(path);
                model.main_img = main_img.FileName;
            }

            Flat f = new Flat(model.province, model.city, model.postal_code, model.address, model.description, model.tittle,
            model.bedrooms, owner, model.main_img, model.rentPerMonth, model.bathrooms, model.bedrooms_availables, model.minimum, model.property_type,
            model.avialableDate);
            f.ID = id;
            if (flatModel.updateFlat(f))
            {
                TempData["Updated"] = "updated";
                return Redirect("~/Account/MisPisos/Actualizar/" + id);
            }
            else
            {
                ModelState.AddModelError("", "No se ha podido actualizar el anuncio en estos momentos. Inténtelo de nuevo.");
            }
            return View(model);
        }
    }




}