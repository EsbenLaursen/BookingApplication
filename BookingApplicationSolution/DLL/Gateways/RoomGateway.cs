using DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace DLL.Gateways
{
    public class RoomGateway : IServiceGateway<Room>
    {
        public Room Create(Room t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/rooms/PostRoom", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Room>().Result;
                }
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync("/api/rooms/DeleteRoom/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public List<Room> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/rooms/getrooms").Result;
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

                var response = client.GetAsync("api/rooms/getroom/" + id).Result;
                if (response.IsSuccessStatusCode)
                {

                    return response.Content.ReadAsAsync<Room>().Result;
                }
            }
            return null;
        }

        public Room Update(Room t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync("api/rooms/PutRoom/" + t.Id, t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Room>().Result;
                }
            }
            return new Room();
        }
    }
}
