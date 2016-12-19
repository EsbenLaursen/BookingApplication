    using DLL.Entities;
using DLL.Gateways;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLL;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        private EmailGateway eg = new DllFacade().GetEmailGateway();
        private IServiceGateway<Image> im = new DllFacade().GetImageGateway();
        IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        private IServiceGateway<FootCare> fc = new DllFacade().GetSFootCareGateway();
        private IServiceGateway<Room> rm = new DllFacade().GetRoomGateway();
        private ReviewGateway rg = new DllFacade().GetReviewGateway();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        public ActionResult Review()
        {
            var rm = new ReviewModel()
            {
                review = rg.Read()
            
            };
            return View(rm);
        }

        public ActionResult Price()
        {
            var vm = new PriceViewModel()
            {
                footCare = fc.Read(),
                Rooms = rm.Read()
            };
            return View(vm);
        }

        public ActionResult Gallery()
        {
            var ig = new ImageViewModel()
            {
                Images = im.Read()
            };
            return View(ig);
        }

        public ActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string email, string name, string message)
        { 
            if (email != null || name != null || message != null)
            { EmailFormModel efm = new EmailFormModel();
                efm.FromName = name;
            efm.FromEmail = email;
            efm.Message = message;
            efm.Subject = "Support";
            var b =  eg.SendMail(efm);
                if (! b)
                {
                    return HttpNotFound("Could not send");
                }
            }
            
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public ActionResult Review(string name, string message)
        {
            if (name != null || message != null)
            {
               var r = new Review()
               {
                  Name = name,
                  Description = message
            };
                rg.Create(r);


            }
            return RedirectToAction("Review");
        }

        public ActionResult GoToAdminView()
        {
            return Redirect("http://localhost:6263");
        }
    }
}