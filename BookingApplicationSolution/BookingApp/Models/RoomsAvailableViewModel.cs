using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingApp.Entities;

namespace BookingApp.Models
{
    public class RoomsAvailableViewModel
    {
        public List<Room> Rooms { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }


    }
}