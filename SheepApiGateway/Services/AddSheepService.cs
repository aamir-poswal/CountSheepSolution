using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SheepApiGateway
{
    public class AddSheepService : IAddSheepService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AddSheepService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task AddSheep()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("http://localhost:1991/api/AddSheep", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
