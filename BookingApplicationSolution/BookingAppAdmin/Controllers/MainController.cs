using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookingAppAdmin.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(string username, string password)
        {
            if (username == "mor" && password == "lol123")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return View("Index");
            }
            else
            {

                return RedirectToAction("LogOn");
            }
        }
    }
}