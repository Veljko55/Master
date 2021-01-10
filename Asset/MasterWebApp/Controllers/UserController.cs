using AutoMapper;
using MasterWebApp.Models;
using MasterWebApp.Models.User;
using SqlDomain.Entities;
using SqlDomain.Services;
using SqlDomain.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace MasterWebApp.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService userService;
        public UserController()
        {
            this.userService = new UserService();
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login(Uri ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl.ToString() != "/User/Logout" ? ReturnUrl.ToString() : "/";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModelView userDataIn)
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            System.Web.Helpers.AntiForgery.Validate();


            if (ModelState.IsValid)
            {
                if (this.userService.IsValidUser(userDataIn.Username, userDataIn.Password))
                {
                    User userEntity = this.userService.GetByUsername(userDataIn.Username);
                    UserCookieData userCookieData = Mapper.Map<UserCookieData>(userEntity);

                    var authTicket = new FormsAuthenticationTicket(
                    1,                             // version
                    userCookieData.Username,                // user name
                    DateTime.Now,                  // created
                    DateTime.Now.AddMinutes(20),   // expires
                    true,                    // persistent?
                    string.Empty                    // can be used to store roles
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                    if (!string.IsNullOrEmpty(userDataIn.ReturnUrl.ToString()))
                    {
                        return Redirect(userDataIn.ReturnUrl.ToString());
                    }
                    return RedirectToAction("Home", "Index");
                }
            }
            ModelState.AddModelError("General", "Invalid Username or Password");
            return View(userDataIn);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            FormsAuthentication.RedirectToLoginPage();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}