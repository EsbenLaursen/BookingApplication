using BookingApp.Gateways;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
        
            HomeBookingViewModel viewModel = new HomeBookingViewModel() {
                boo = bg.Read(3) 
            };
            

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }
    }
}