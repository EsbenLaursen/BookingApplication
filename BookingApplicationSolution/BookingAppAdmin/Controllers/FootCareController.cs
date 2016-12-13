using DLL;
using DLL.Entities;
using DLL.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppAdmin.Controllers
{
    [Authorize]
    public class FootCareController : Controller
    {
        IServiceGateway<FootCare> fg = new DllFacade().GetSFootCareGateway();
        // GET: FootCare
        public ActionResult Index()
        {
            return View(fg.Read());
        }

        // GET: FootCare/Details/5
        public ActionResult Details(int id)
        {
            FootCare f = fg.Read(id);
            return View(f);
        }

        // GET: FootCare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootCare/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                FootCare f = new FootCare() {
                    Description = collection["description"].ToString(),
                    Duration = Convert.ToDouble(collection["duration"]),
                    Price = Convert.ToDouble(collection["price"]),
                    Name = collection["name"].ToString()
                };
                fg.Create(f);

                return RedirectToAction("Index");
            }
            catch
            { 
                return View();
            }
        }

        // GET: FootCare/Edit/5
        public ActionResult Edit(int id)
        {
            FootCare f = fg.Read(id);
            return View(f);
        }

        // POST: FootCare/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                FootCare f = fg.Read(id);
                f.Description = collection["description"].ToString();
                f.Duration = Convert.ToDouble(collection["duration"]);
                f.Price = Convert.ToDouble(collection["price"]);
                f.Name = collection["name"].ToString();

                FootCare fUpdated = fg.Update(f);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FootCare/Delete/5
        public ActionResult Delete(int id)
        {
            return View(fg.Read(id));
        }

        // POST: FootCare/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                fg.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
