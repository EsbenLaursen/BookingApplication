using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp
{
  
    public class Booking 
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Customer Customer { get; set; }
        public List<Room> Room { get; set; }
    }
}