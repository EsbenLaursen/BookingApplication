using BookingApp.Entities;
using BookingApp.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp
{
    public class DllFacade
    {
        public IServiceGateway<Booking> GetBookingGateway()
        {
            return new BookingGateway();
        }

        public IServiceGateway<FootCare> GetSFootCareGateway()
        {
            return new FootCareGateway();
        }
        public IServiceGateway<Room> GetRoomGateway()
        {
            return new RoomGateway();
        }
        public IServiceGateway<Customer> GetCustomerGateway()
        {
            return new CustomerGateway();
        }
        public IServiceGateway<Image> GetImageGateway()
        {
            return new ImageGateway();
        }
    }
}