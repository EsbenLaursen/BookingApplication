using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingApp;
using DLL.Entities;
using DLL.Gateways;
using DLL.Models;
using DLL;


namespace BookingAppAdmin.Controllers
{
    
    public class BookingController : Controller
    {
        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        IServiceGateway<Customer> cm = new DllFacade().GetCustomerGateway();
        IServiceGateway<Room> rm = new DllFacade().GetRoomGateway();

        // GET: Booking
        public ActionResult Index()
        {
            return View(bg.Read().ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            var model = new CustomerInfoViewModel()
            {
                Rooms = rm.Read()

            };

            return View(model);
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(Booking booking, Customer customer, int[] ids, DateTime from, DateTime to)
        {

            List<Room> rooms = new List<Room>();
            try
            {
                foreach (var i in ids)
                {
                    rooms.Add(rm.Read(i));
                    
                }
                booking.StartDate = from;
                booking.EndDate = to;
                booking.Customer = customer;
                booking.Room = rooms;
                bg.Create(booking);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bg.Read(id));
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bg.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
