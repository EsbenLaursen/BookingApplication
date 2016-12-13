
using DLL.Entities;
using DLL.Gateways;
using DLL;
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
            Rooms = new List<Room>();
            Bookings = new List<Booking>();
            Rooms = sg.Read();
            Bookings = bg.Read();
        }

        public List<Room> Check(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();
            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            List<Room> RoomsAvailable = new List<Room>();

            foreach (var r1 in Rooms)//3rooms
            {
                    bool succes = true;
                    foreach(var b in Bookings)
                    {
                        foreach(var r in b.Room)
                        {
                            if (r.Name == r1.Name)
                            {
                                for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                                {
                                    if (dates.Any(x => x.Day == dt.Day && x.Month == dt.Month && x.Year == dt.Year))
                                    {
                                      succes = false;
                                    }
                                }
                            }
                        }
                    }
                    if (succes)
                    {
                        RoomsAvailable.Add(r1);
                    }
            }  
            
            return RoomsAvailable;
        }


        public List<DateTime> FetchUnavailableDates2()
        {
            List<DateTime> room1 = new List<DateTime>();
            List<DateTime> room2 = new List<DateTime>();
            List<DateTime> room3 = new List<DateTime>();

            List<DateTime> UnavailableDates = new List<DateTime>();

            foreach (var b in Bookings)
            {
                foreach (var r in b.Room)
                {
                    if (r.Id == 1)
                    {
                        for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                        {
                            room1.Add(dt);
                        }
                    }
                    else if (r.Id == 2)
                    {
                        for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                        {
                            room2.Add(dt);
                        }
                    }
                    else
                    {
                        for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                        {
                            room3.Add(dt);
                        }
                    }
                }
            }

            foreach (var d in room1)
            {
                if (room2.Any(x => x.Day == d.Day && x.Month == d.Month && x.Year == d.Year) && room3.Any(x => x.Day == d.Day && x.Month == d.Month && x.Year == d.Year))
                {
                    UnavailableDates.Add(d);
                }
            }
            return UnavailableDates;
        }
        
    }
}