using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class BookingConfirmViewModel
    {
        public List<Room> Rooms { get; set; }
        public Customer Customer { get; set; }
    }
}