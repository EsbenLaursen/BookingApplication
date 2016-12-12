using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLL.Entities
{
    public class TemporaryBooking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Room> Rooms { get; set; }

        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNr { get; set; }
    }
}