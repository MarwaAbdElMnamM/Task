using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Task.Models;
using TaskApi.Helpers;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Task.Controllers
{
    public class Client2Controller : Controller
    {
        Helper api = new Helper();
        public async Task<ActionResult> GetAllClient()
        {
            List<Client> clint = new List<Client>();
            HttpClient client = api.initial();
            HttpResponseMessage res = await client.GetAsync("api/Clients");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                clint = JsonConvert.DeserializeObject<List<Client>>(result);
            }
            return View(clint);
        }
        public async Task<ActionResult> GetClient(int id)
        {
            var client1 = new Client();
            HttpClient client = api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/Clients/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                client1= JsonConvert.DeserializeObject<Client>(result);
            }
            return View(client1);
        }
        
        public ActionResult CreateClient()
        {
            return View();
        }
        

        public async Task<ActionResult> CreateClient(Client client)
        {
            HttpClient client1 = api.initial();
            string stringData = JsonConvert.
       SerializeObject(client);
            var contentData = new StringContent
        (stringData, Encoding.UTF8, "application/json");

            var response = client1.PostAsync(
               "api/Clients", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllClient");
            }
            return View();

        }
        public async Task<ActionResult> EditClient(int id)
        {
            var client2 = new Client();
            HttpClient client = api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/Clients/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                client2 = JsonConvert.DeserializeObject<Client>(result);
            }
            return View(client2);
        }

        [HttpPost]
        public async Task<ActionResult> EditClient(Client client)
        {
            HttpClient client3 = api.initial();
            string stringData = JsonConvert.
       SerializeObject(client);
            var contentData = new StringContent
        (stringData, Encoding.UTF8, "application/json");

            var response = client3.PutAsync(
               $"api/Clients/{client.ID}", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllClient");
            }
            return View();

        }


    }
}
