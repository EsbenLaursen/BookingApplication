using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookingAppAdmin.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DLL;
using DLL.Gateways;
using Newtonsoft.Json.Linq;
using Image = DLL.Entities.Image;

namespace BookingAppAdmin.Controllers
{

    public class ImageController : Controller
    {
        static Cloudinary m_cloudinary;
        IServiceGateway<Image> ig = new DllFacade().GetImageGateway();
        private CloudGateway cg = new DllFacade().GetCloudGateway();
        
        // GET: Image
        public ActionResult Index()
        {

            return View(ig.Read().ToList());
        }

        public ActionResult Upload()
        {
            var List = cg.GetAcc();
            Account acc = new Account()
            {
                Cloud = List[0],
                ApiKey = List[1],
                ApiSecret = List[2]
            }
           ;
            m_cloudinary = new Cloudinary(acc);

            return View(new Model(m_cloudinary));
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadServer()
        {

            Dictionary<string, string> results = new Dictionary<string, string>();

            for (int i = 0; i < HttpContext.Request.Files.Count; i++)
            {
                var file = HttpContext.Request.Files[i];

                if (file.ContentLength == 0) return RedirectToAction("Upload");

                var result = m_cloudinary.Upload(new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.Actions.FileDescription(file.FileName,
                        file.InputStream),
                    Tags = "backend_photo_album"
                });

                foreach (var token in result.JsonObj.Children())
                {
                    if (token is JProperty)
                    {
                        JProperty prop = (JProperty)token;
                        results.Add(prop.Name, prop.Value.ToString());
                    }
                }

                Image im = new Image()
                {
                    Bytes = (int)result.Length,
                    Path = result.Uri.AbsolutePath,
                    PublicId = result.PublicId,
                    SecureUrl = result.SecureUri.AbsoluteUri,
                    Type = result.JsonObj["type"].ToString(),
                    Url = result.Uri.AbsoluteUri,

                };

                ig.Create(im);

            }

            return View(new DictionaryModel(m_cloudinary, results));
        }


        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ig.Read(id));
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ig.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
