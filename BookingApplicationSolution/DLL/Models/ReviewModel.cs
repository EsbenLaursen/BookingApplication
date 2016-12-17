using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Entities;
using NUnit.Framework.Constraints;

namespace DLL.Models
{
    public class ReviewModel
    {
        
        public string Name { get; set; }
        
        public string Message { get; set; }
        public List<Review> review { get; set; }
    }
}
