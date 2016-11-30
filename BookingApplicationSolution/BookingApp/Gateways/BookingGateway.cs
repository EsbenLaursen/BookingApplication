﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Gateways
{
    public class BookingGateway : IServiceGateway<Booking>
    {
        public Booking Create(Booking t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/bookings", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Booking>().Result;
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

                var response = client.DeleteAsync("/api/bookings/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public List<Booking> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/bookings").Result;
                if (response.IsSuccessStatusCode)
                { //JsonConvert.DeserializeObject<List<Booking>>(
                    return response.Content.ReadAsAsync<List<Booking>>().Result;
                }
            }
            return new List<Booking>();
        }

        public Booking Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/bookings/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    // return JsonConvert.DeserializeObject<Booking>(response.Content.ReadAsStringAsync().Result);
                    return response.Content.ReadAsAsync<Booking>().Result;
                }
            }
            return null;
        }

        public Booking Update(Booking t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync("api/bookings/" + t.Id, t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Booking>().Result;
                }
            }
            return new Booking();
        }
    }
}