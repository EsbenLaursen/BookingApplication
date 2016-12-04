using BookingApp.Entities;
using BookingApp.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp
{
    
    public class CheckRoomAvailability
    {
        public IServiceGateway<Room> sg = new DllFacade().GetRoomGateway();
        public IServiceGateway<Booking> bg = new DllFacade().GetBookingGateway();
        List<Booking> Bookings;
        List<Room> Rooms;
        public CheckRoomAvailability()
        {
            Rooms = sg.Read();
            Bookings = bg.Read();
        }

        public List<DateTime> Check(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();
            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }


    }
}