using BookingApp.Entities;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class BookingIndexViewModel
    {
        public List<Booking> Bookings { get; set; }
        public List<DateTime> UnavailableDates { get; set; }
    }
}