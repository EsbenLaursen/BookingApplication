using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(
                  "dn5ix6nlj",
                  "231761421384158",
                  "uBidVVrnr8MECH33_A3_TnkyzsI");

            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"C:\Images\background.jpg"),
                PublicId = "sample_id",
                Transformation = new Transformation().Crop("limit").Width(40).Height(40),
                EagerTransforms = new List<Transformation>()
  {
    new Transformation().Width(200).Height(200).Crop("thumb").Gravity("face").
      Radius(20).Effect("sepia"),
    new Transformation().Width(100).Height(150).Crop("fit").FetchFormat("png")
  },
                Tags = "special, for_homepage"
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            var ewfwef = 1;
        }
    }
}
