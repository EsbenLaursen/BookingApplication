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

        public EmailGateway GetEmailGateway()
        {
            return new EmailGateway();
        }
        public IServiceGateway<TemporaryBooking> GetTempBookingGateway()
        {
            return new TemporaryBookingGateway();
        }
        public IServiceGateway<Booking> GetBookingGateway()
        {
            return new BookingGateway();
        }

        public IServiceGateway<FootCare> GetSFootCareGateway()
        {
            return new FootCareGateway();
        }

        public AvailableDates GetAvailableGateway()
        {
            return new AvailableDates();
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