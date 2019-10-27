using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SheepApiGateway
{
    public class CountSheepService : ICountSheepService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CountSheepService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<int> GetSheepCount()
        {
            var result = 0;
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:1747/api/Sheep");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content
                .ReadAsAsync<int>();
            }

            return result;
        }
    }
}
