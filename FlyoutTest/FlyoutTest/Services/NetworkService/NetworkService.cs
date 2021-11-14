using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlyoutTest.Services.NetworkService
{
   public  class NetworkService : INetworkService
    {
        private HttpClient httpClient;

        public NetworkService()
        {
            httpClient = new HttpClient();
        }
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;
        }
    }
}
