using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLL.Entities;
using CloudinaryDotNet;

namespace BookingAppAdmin.Models
{
    public class DictionaryModel : Model
    {
        public DictionaryModel(Cloudinary cloudinary, Dictionary<string, string> dict)
            : base(cloudinary)
        {
            Dict = dict;
        }

        public Dictionary<string, string> Dict { get; set; }
    }

    public class PhotosModel : Model
    {
        public PhotosModel(Cloudinary cloudinary, List<Image> images)
            : base(cloudinary)
        {
            Images = images;
        }

        public List<Image> Images { get; set; }
    }

    public class Model
    {
        public Model(Cloudinary cloudinary)
        {
            Cloudinary = cloudinary;
        }

        public Cloudinary Cloudinary { get; set; }
    }
}
