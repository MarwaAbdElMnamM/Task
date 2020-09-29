using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TaskApi.Helpers
{
    public class Helper
    {
        public HttpClient initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:49898/");
            return Client;

        }

    }
}