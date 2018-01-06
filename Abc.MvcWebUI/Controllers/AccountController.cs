using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.UserName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kayıt işlemi gercekleştiyse .succeeded
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabiliriz.

                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }

            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    //var olan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);


                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }


            }

            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}