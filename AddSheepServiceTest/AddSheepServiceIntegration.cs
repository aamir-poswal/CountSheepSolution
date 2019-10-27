using AddSheepService;
using AddSheepService.Commands;
using AddSheepService.Controllers;
using AmazonSQS;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AddSheepServiceTest
{
    public class AddSheepServiceIntegration
    {

        [Test]
        public async Task AddSheepServiceApiEndpointTest()
        {

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();

            var response = await client.PostAsync($"/api/AddSheep", null);

            response.EnsureSuccessStatusCode();

            Assert.Pass();
        }

    }
}