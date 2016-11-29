using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Entities
{
    [Serializable]
    public class FootCare
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
    }
}