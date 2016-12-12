using DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLL.Models
{
    public class CustomerInfoViewModel
    {
        public Customer Customer { get; set; }
        public List<Room> Rooms { get; set; }
    }
}