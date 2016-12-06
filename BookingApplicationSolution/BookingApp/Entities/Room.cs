using System;

namespace BookingApp.Entities
{
   
    public class Room
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Persons { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Booking Booking { get; set; }

    }
}