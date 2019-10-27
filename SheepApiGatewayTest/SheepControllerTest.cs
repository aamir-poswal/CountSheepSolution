using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using SheepApiGateway;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheepApiGatewayTest
{
    public class SheepControllerTest
    {
        [Test]
        public async Task AddSheepTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();

            var response = await client.PostAsync($"/api/Sheep", null);

            response.EnsureSuccessStatusCode();

            Assert.Pass();
        }

        [Test]
        public async Task GetSheepCoundTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();

            var response = await client.GetAsync($"/api/Sheep");

            response.EnsureSuccessStatusCode();

            Assert.Pass();
        }
    }
}
