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
    public class AddSheepServiceUnitTests
    {

        [Test]
        public void TestAmazonSQSHelper()
        {
            var logMock = new Mock<ILogger<AmazonSQSHelper>>();
            ILogger<AmazonSQSHelper> logger = logMock.Object;
            var configurationRoot = TestHelper.GetConfiguration();
            var sut = new AmazonSQSHelper(logger, configurationRoot);
            var results = sut.GetAmazonSQSClient();

            Assert.Pass();
        }

        [Test]
        public async Task TestAmazonSQSPublisher()
        {
            //AmazonSQSHelper
            var amazonSQSHelperLogMock = new Mock<ILogger<AmazonSQSHelper>>();
            ILogger<AmazonSQSHelper> amazonSQSHelperLogger = amazonSQSHelperLogMock.Object;
            var configurationRoot = TestHelper.GetConfiguration();

            var amazonSQSHelper = new AmazonSQSHelper(amazonSQSHelperLogger, configurationRoot);

            //AmazonSQSPublisher
            var amazonSQSPublisherLogMock = new Mock<ILogger<AmazonSQSPublisher>>();
            ILogger<AmazonSQSPublisher> amazonSQSPublisherLogger = amazonSQSPublisherLogMock.Object;

            var sut = new AmazonSQSPublisher(configurationRoot, amazonSQSPublisherLogger, amazonSQSHelper);

            var results = await sut.SendMessage();


            Assert.Pass();
        }

        [Test]
        public async Task TestAddSheepCommandHandler()
        {
            //AmazonSQSHelper
            var amazonSQSHelperLogMock = new Mock<ILogger<AmazonSQSHelper>>();
            ILogger<AmazonSQSHelper> amazonSQSHelperLogger = amazonSQSHelperLogMock.Object;
            var configurationRoot = TestHelper.GetConfiguration();

            var amazonSQSHelper = new AmazonSQSHelper(amazonSQSHelperLogger, configurationRoot);

            //AmazonSQSPublisher
            var amazonSQSPublisherLogMock = new Mock<ILogger<AmazonSQSPublisher>>();
            ILogger<AmazonSQSPublisher> amazonSQSPublisherLogger = amazonSQSPublisherLogMock.Object;

            var amazonSQSPublisher = new AmazonSQSPublisher(configurationRoot, amazonSQSPublisherLogger, amazonSQSHelper);

            //AddSheepCommandCommandHandler
            var addSheepCommandCommandHandlerLogMock = new Mock<ILogger<AddSheepCommand.AddSheepCommandCommandHandler>>();
            ILogger<AddSheepCommand.AddSheepCommandCommandHandler> addSheepCommandCommandHandlerLogger = addSheepCommandCommandHandlerLogMock.Object;

            var addSheepCommandCommandHandler = new AddSheepCommand.AddSheepCommandCommandHandler(amazonSQSPublisher, addSheepCommandCommandHandlerLogger);

            var command = new AddSheepCommand();
            var resutls = await addSheepCommandCommandHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(resutls);
            Assert.Pass();
        }

    }
}