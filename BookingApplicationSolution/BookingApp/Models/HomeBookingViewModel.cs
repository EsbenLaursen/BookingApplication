using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class HomeBookingViewModel
    {
        public List<Booking> Bookings { get; set; }
        public Booking boo { get; set; }
    }
}