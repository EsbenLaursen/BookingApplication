using BookingApp.Gateways;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{
    
    public class BookingController : Controller
    {

        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        // GET: Booking
        public ActionResult Index()
        {

            BookingIndexViewModel viewModel = new BookingIndexViewModel() {
                Bookings = bg.Read()
            };
            return View(viewModel);
        }

        //Post: booking
        
        public ActionResult BookingCheckout()
        {
            return View();
        }
    }
}