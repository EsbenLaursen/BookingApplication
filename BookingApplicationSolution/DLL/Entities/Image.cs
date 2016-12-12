using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLL.Entities
{
    
    public class Image
    {
        public int ImageId { get; set; }
        public string PublicId { get; set; }
        public int Bytes { get; set; }
        public string Url { get; set; }
        public string SecureUrl { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
    }
}