using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingApp.Entities;

namespace BookingApp.Models
{
    public class PriceViewModel
    {
        public List<FootCare> footCare { get; set; }
        public List<Room> Rooms { get; set; }
    }
}