using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLL;
using DLL.Entities;
using DLL.Gateways;

namespace BookingAppAdmin.Controllers
{
    public class RoomController : Controller
    {
        IServiceGateway<Room> rg = new DllFacade().GetRoomGateway();

        // GET: Room
        public ActionResult Index()
        {
            return View(rg.Read());
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            Room r = rg.Read(id);
            return View(r);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Room r = new Room()
                {
                    Description = collection["description"].ToString(),
                    Persons = Convert.ToInt32(collection["persons"]),
                    Price = Convert.ToDouble(collection["price"]),
                    Name = collection["name"].ToString()
                };
                rg.Create(r);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            Room r = rg.Read(id);
            return View(r);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Room r = rg.Read(id);
                r.Description = collection["description"].ToString();
                r.Persons = Convert.ToInt32(collection["persons"]);
                r.Price = Convert.ToDouble(collection["price"]);
                r.Name = collection["name"].ToString();

                rg.Update(r);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View(rg.Read(id));
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                rg.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
