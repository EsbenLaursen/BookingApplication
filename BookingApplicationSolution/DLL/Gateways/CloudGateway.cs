using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using DLL.Entities;
using NUnit.Framework;
using System.Web;

namespace DLL.Gateways
{
    public class CloudGateway
    {
        public List<String> GetAcc()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52218/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                AddAuthorizationHeader(client);

                HttpResponseMessage response = client.GetAsync("api/Cloud/GetAcc").Result;

                if (response.IsSuccessStatusCode)
                {
                    //JsonConvert.DeserializeObject<List<Booking>>( 
                    return response.Content.ReadAsAsync<List<string>>().Result;
                }
            }
            return new List<string>();
        }

        private void AddAuthorizationHeader(HttpClient client)
        {
            if (HttpContext.Current.Session["token"] != null)
            {
                string token = HttpContext.Current.Session["token"].ToString();
                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
        }
    }
}
