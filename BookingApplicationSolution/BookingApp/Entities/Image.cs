using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Entities
{
    [Serializable]
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}