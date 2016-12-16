using DLL;
using DLL.Gateways;
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
        EmailGateway gateway = new DllFacade().GetEmailGateway();
        // GET: Main
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOn(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(string username, string password, string ReturnUrl)
        {
            var user = gateway.getAdmin();
            if (user[0] == username && user[1] == password)
            {
                FormsAuthentication.SetAuthCookie(user[0], false);
                return RedirectToAction("../" + ReturnUrl);
            }
            else
            {
                return RedirectToAction("LogOn");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
       
    }
}