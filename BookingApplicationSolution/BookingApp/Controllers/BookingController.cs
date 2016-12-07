using BookingApp.Entities;
using BookingApp.Gateways;
using BookingApp.Models;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{

    public class BookingController : Controller
    {

        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        IServiceGateway<Customer> cm = new DllFacade().GetCustomerGateway();
        IServiceGateway<Room> rm = new DllFacade().GetRoomGateway();
        public ActionResult Index()
        {
            CheckRoomAvailability check = new CheckRoomAvailability();
            List<DateTime> dates = check.FetchUnavailableDates2();
            BookingIndexViewModel viewModel = new BookingIndexViewModel()
            {
                Bookings = bg.Read(),
                UnavailableDates = dates
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult RoomsAvailable(DateTime from, DateTime to)
        {
            CheckRoomAvailability check = new CheckRoomAvailability();
            List<Room> AvailableRooms = check.Check(from, to);

            //Test
            List<DateTime> dates = check.FetchUnavailableDates2();


            return View(AvailableRooms);
        }
        [HttpGet]
        public ActionResult CustomerInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerInformation(Customer c)
        {
            if (ModelState.IsValid)
            {
                Session["Customer"] = c;
                return RedirectToAction("BookingCheckout");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult BookingCheckout()
        {
            BookingConfirmViewModel viewModel = new BookingConfirmViewModel()
            {
                
                Customer = Session["Customer"] as Customer,
                Rooms = Session["Rooms"] as List<Room>
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetRooms(int[] ids)
        {
            if (ids.Length == 0)
            {
                return RedirectToAction("RoomsAvailable");
            }
            List<Room> rooms = new List<Room>();
            foreach (var i in ids)
            {
                rooms.Add(rm.Read(i));
            }
            Session["Rooms"] = rooms;
            return RedirectToAction("CustomerInformation", FormMethod.Get);
        }

    }
}