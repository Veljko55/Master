using AutoMapper;
using MasterWebApp.Models.User;
using SqlDomain.Entities;
using SqlDomain.Services;
using SqlDomain.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterWebApp.Controllers
{
    public class BaseController : Controller
    {
        protected UserCookieData userCookieData;
        private IUserService userService;

        public BaseController()
        {

            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
            {
                userCookieData = System.Web.HttpContext.Current.Session["userData"] as UserCookieData;
                if (userCookieData == null)
                {
                    userService = new UserService();

                    User userEntity = userService.GetByUsername(System.Web.HttpContext.Current.User.Identity.Name);
                    userCookieData = Mapper.Map<UserCookieData>(userEntity);
                    System.Web.HttpContext.Current.Session["userData"] = userCookieData;
                }
                ViewBag.UserCookieData = userCookieData;
            }
        }
    }
}