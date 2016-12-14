using DLL.Entities;
using DLL.Gateways;
using DLL;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookingApp.Controllers
{

    public class BookingController : Controller
    {

        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        IServiceGateway<Customer> cm = new DllFacade().GetCustomerGateway();
        IServiceGateway<Room> rm = new DllFacade().GetRoomGateway();
        IServiceGateway<TemporaryBooking> tm = new DllFacade().GetTempBookingGateway();
        AvailableDates ad = new DllFacade().GetAvailableGateway();
        EmailGateway egw = new DllFacade().GetEmailGateway();

        // GET: Booking
        public ActionResult Index()
        {
            
            List<DateTime> dates = ad.GetAvailableDates();

            BookingIndexViewModel viewModel = new BookingIndexViewModel()
            {
                Bookings = bg.Read(),
                UnavailableDates = dates
            };

            return View(viewModel);
        }

       
        public ActionResult RoomsAvailable(DateTime ?from, DateTime ?to)
        {
            if (from != null || to != null)
            {
            
            CheckRoomAvailability check = new CheckRoomAvailability();
            RoomsAvailableViewModel ravm = new RoomsAvailableViewModel()
            {
                Rooms = ad.GetAvailableRooms(from.Value, to.Value),
                To = to.Value,
                From = from.Value
            };
            return View(ravm);
        }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetRooms(int[] ids, DateTime to, DateTime from)
        {
            if (from != null || to != null)
            {
                if (ids ==null || ids.Length == 0)
                {
                    return RedirectToAction("RoomsAvailable", new {to = to, from =from});
                }
                List<Room> rooms = new List<Room>();

                foreach (var i in ids)
                {
                    rooms.Add(rm.Read(i));
                }
                Session["Rooms"] = rooms;
                Session["to"] = to;
                Session["from"] = from;

                return RedirectToAction("CustomerInformation", FormMethod.Get);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CustomerInformation()
        {
            if (Session["to"] !=null || Session["from"] != null)
                return View();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CustomerInformation(Customer c)
        {
            if (ModelState.IsValid)
            {
                Session["customer"] = c;
                return RedirectToAction("BookingCheckout");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult BookingCheckout()
        {

            if (Session["to"] != null || Session["from"] != null || Session["customer"]!= null || Session["Rooms"] !=null)
            {
                 var c = Session["customer"] as Customer;

            var vm = new CheckoutViewModel();
            vm.TemporaryBooking = new TemporaryBooking()
            {
                Rooms = Session["Rooms"] as List<Room>,

                CustomerEmail = c.Email,
                CustomerFirstname = c.FirstName,
                CustomerLastname = c.LastName,
                CustomerPhoneNr = c.Telephone,
                EndDate = (DateTime)Session["to"],
                StartDate = (DateTime)Session["from"],
            };
            Session["temp"] = vm.TemporaryBooking;
            return View(vm);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult SendEmail( )
        {
            if (Session["temp"] != null)
            {
                 var email = Session["temp"] as TemporaryBooking;
            EmailFormModel efm = new EmailFormModel();

            efm.FromName = email.CustomerFirstname + " " + email.CustomerLastname;
            efm.FromEmail = email.CustomerEmail;
            efm.Message = "Dates: " + email.StartDate.ToShortDateString()
                + " - " + email.EndDate.ToShortDateString() + "<br />"+ "<a href='http://localhost:58771/'>Confirm booking</a>";
            efm.Subject = "new booking";     


            var check = egw.SendMail(efm);
            if (check)
            {
                tm.Create(email);
            }
            else
            {
                return new HttpNotFoundResult("Could not send email");
            }
            return View();
            }
           return new HttpStatusCodeResult(409,"Session is not available, you have to start over");
        }


    }
}