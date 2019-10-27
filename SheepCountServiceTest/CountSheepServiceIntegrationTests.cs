using AmazonSQS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SheepCountService;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CountSheepServiceTest
{
    public class CountSheepServiceIntegrationTests
    {

        [Test]
        public async Task CountSheepServiceApiEndpointTest()
        {

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();

            var response = await client.GetAsync($"/api/Sheep");

            response.EnsureSuccessStatusCode();

            Assert.Pass();
        }

    }
}