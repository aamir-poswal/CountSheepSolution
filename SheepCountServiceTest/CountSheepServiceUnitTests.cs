
using AmazonSQS;

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

namespace CountSheepServiceTest
{
    public class CountSheepServiceUnitTests
    {

        //todo: later  it to common test project
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
        public async Task TestAmazonSQSReceiver()
        {
            //AmazonSQSHelper
            var amazonSQSHelperLogMock = new Mock<ILogger<AmazonSQSHelper>>();
            ILogger<AmazonSQSHelper> amazonSQSHelperLogger = amazonSQSHelperLogMock.Object;
            var configurationRoot = TestHelper.GetConfiguration();

            var amazonSQSHelper = new AmazonSQSHelper(amazonSQSHelperLogger, configurationRoot);

            //AmazonSQSReceiver
            var amazonSQSReceiverLogMock = new Mock<ILogger<AmazonSQSReceiver>>();
            ILogger<AmazonSQSReceiver> amazonSQSReceiverLogger = amazonSQSReceiverLogMock.Object;

            var sut = new AmazonSQSReceiver(configurationRoot, amazonSQSReceiverLogger, amazonSQSHelper);

            var results = await sut.ReceiveMessage();

            Assert.Pass();

        }

    }
}