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
    
    public class BookingController : Controller
    {

        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        IServiceGateway<Customer> cm = new DllFacade().GetCustomerGateway();
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
            BookingIndexViewModel viewModel = new BookingIndexViewModel()
            {
                Bookings = bg.Read()
            };
            CheckRoomAvailability check = new CheckRoomAvailability();
            List<DateTime> dates = check.Check(DateTime.Now, DateTime.Now.AddDays(10));


            return View(viewModel);
        }
        [HttpPost]
        public ActionResult BookingCheckout(Customer c)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("BookingCheckout");
            }
            return View(c);
        }
    }
}