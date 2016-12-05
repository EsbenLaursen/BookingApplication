using BookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookingApp.Gateways
{
    public class FootCareGateway : IServiceGateway<FootCare>
    {
        public FootCare Create(FootCare t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<FootCare> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Footcares").Result;
                if (response.IsSuccessStatusCode)
                { //JsonConvert.DeserializeObject<List<Footcare>>(
                    return response.Content.ReadAsAsync<List<FootCare>>().Result;
                }
            }
            return new List<FootCare>();
        }


        public FootCare Read(int id)
        {
            throw new NotImplementedException();
        }

        public FootCare Update(FootCare t)
        {
            throw new NotImplementedException();
        }
    }
}