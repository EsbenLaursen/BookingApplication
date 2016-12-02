using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Gateways
{
    public class CustomerGateway : IServiceGateway<Customer>
    {
        public Customer Create(Customer t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Read()
        {
            throw new NotImplementedException();
        }

        public Customer Read(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}