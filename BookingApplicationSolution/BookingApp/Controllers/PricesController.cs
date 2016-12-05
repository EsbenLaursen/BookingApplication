using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingApp.Entities;
using BookingApp.Gateways;
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class PricesController : Controller
    {
        IServiceGateway<FootCare> fc = new DllFacade().GetSFootCareGateway();
        // GET: Prices
        public ActionResult Index()
        {
            PriceIndexViewModel viewmodel = new PriceIndexViewModel()
            {
                FootCares = fc.Read()
            };
            
            return View(viewmodel);
        }
    }
}