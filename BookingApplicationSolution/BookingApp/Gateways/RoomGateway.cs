using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookingApp.Gateways
{
    public class RoomGateway : IServiceGateway<Room>
    {
        public Room Create(Room t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/rooms").Result;
                if (response.IsSuccessStatusCode)
                { 
                    return response.Content.ReadAsAsync<List<Room>>().Result;
                }
            }
            return new List<Room>();
        }

        public Room Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/rooms/" + id).Result;
                if (response.IsSuccessStatusCode)
                {

                    return response.Content.ReadAsAsync<Room>().Result;
                }
            }
            return null;
        }

        public Room Update(Room t)
        {
            throw new NotImplementedException();
        }
    }
}