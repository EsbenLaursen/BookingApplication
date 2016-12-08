using System;
using System.Collections.Generic;

namespace BookingApp.Entities
{
   
    public class Room
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Persons { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<Booking> Booking { get; set; }
        public List<TemporaryBooking> TemporaryBookings { get; set; }

    }
}