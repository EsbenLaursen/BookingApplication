﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingApp;
using DLL.Entities;
using DLL.Gateways;

namespace BookingAppAdmin.Controllers
{
    public class TempBookingController : Controller
    {

        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        IServiceGateway<Customer> cm = new DllFacade().GetCustomerGateway();
        IServiceGateway<Room> rm = new DllFacade().GetRoomGateway();
        private IServiceGateway<TemporaryBooking> tb = new DllFacade().GetTempBookingGateway();
        // GET: TempBooking
        public ActionResult Index()
        {
            var v = tb.Read().ToList();
            return View(tb.Read().ToList());
        }

        // GET: TempBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TempBooking/Create
        public ActionResult Create(int id)
        {
            var tembbook = tb.Read(id);

            return View(tembbook);
        }

        // POST: TempBooking/Create
        [HttpPost]
        public ActionResult Accept(int id)
        {
            try
            {
                var temp = tb.Read(id);
                var cus = new Customer()
                {
                    Email = temp.CustomerEmail,
                    FirstName = temp.CustomerEmail,
                    LastName = temp.CustomerLastname,
                    Telephone = temp.CustomerPhoneNr
                };
                var book = new Booking()
                {
                    EndDate = temp.EndDate,
                    StartDate = temp.StartDate,
                    Customer = cus,
                    Room = temp.Rooms
                    
                };
                cm.Create(cus);
                bg.Create(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: TempBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TempBooking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TempBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TempBooking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
