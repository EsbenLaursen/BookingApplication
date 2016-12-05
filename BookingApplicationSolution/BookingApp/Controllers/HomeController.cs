using BookingApp.Entities;
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
        private IServiceGateway<FootCare> fc = new DllFacade().GetSFootCareGateway();
        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
             return View();
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
            PriceIndexViewModel viewmodel = new PriceIndexViewModel()
            {
                FootCares = fc.Read()
            };
            return View(viewmodel);
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