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
        // GET: Booking
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

        //Post: booking

        public ActionResult BookingCheckout()
        {
            CheckRoomAvailability check = new CheckRoomAvailability();
            //Test
            List<DateTime> dates = check.FetchUnavailableDates2();

            BookingIndexViewModel viewModel = new BookingIndexViewModel()
            {
                Bookings = bg.Read(),
                UnavailableDates = dates
            };
           
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CustomerInformation(int[] ids)
        {
            if (ids.Length==0)
            {
                return RedirectToAction("RoomsAvailable");
            }
            List<Room> rooms = new List<Room>();
            foreach(var i in ids)
            {
                rooms.Add(rm.Read(i));
            }
            CustomerInfoViewModel viewModel = new CustomerInfoViewModel() {
                Rooms = rooms
            };

         
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

        [HttpPost]
        public ActionResult RoomsAvailable(DateTime from, DateTime to)
        {
            CheckRoomAvailability check = new CheckRoomAvailability();
            List<Room> AvailableRooms = check.Check(from, to);

            //Test
            List<DateTime> dates = check.FetchUnavailableDates2();


            return View(AvailableRooms);
        }
    }
}