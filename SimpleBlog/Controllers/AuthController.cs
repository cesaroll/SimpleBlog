using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            //return Content("Login!");
            return View(new AuthLogin
            {
                //Test = "This is my test value set in my controller"
            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            //return Content("Hey there, " + form.Username);
            //form.Test = "This is a value set in my POST Action.";

            if(!ModelState.IsValid)
                return View(form);

            if (form.Username != "rainbow dash")
            {
                ModelState.AddModelError("Username", "Username or password isn't 20% cooler.");
                return View(form);
            }

            return Content("The form is valid!");
        }
    }
}