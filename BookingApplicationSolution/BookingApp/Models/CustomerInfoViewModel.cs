using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class CustomerInfoViewModel
    {
        public Customer Customer { get; set; }
        public List<Room> Rooms { get; set; }
    }
}