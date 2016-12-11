using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookingApp.Gateways
{
    public class AvailableDates
    {
        public List<DateTime> GetAvailableDates()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Calendar/GetAvailableDates").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<DateTime>>().Result;
                }
            }
            return new List<DateTime>();
        }

        public List<Room> GetAvailableRooms(DateTime to, DateTime from)
        {
            
            var toFormat = to.ToString("MM-dd-yyyy");
            var fromFormat = from.ToString("MM-dd-yyyy");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Calendar/GetRooms?to=" + toFormat + "&from=" + fromFormat).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Room>>().Result;
                }
            }
            return new List<Room>();
        }
    }
}