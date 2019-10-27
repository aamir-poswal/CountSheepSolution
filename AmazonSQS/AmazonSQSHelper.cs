using Amazon.Runtime;
using Amazon.SQS;
using System;
using Microsoft.Extensions.Options;
using Amazon.SQS.Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Amazon;
using Microsoft.Extensions.Configuration;

namespace AmazonSQS
{
    public class AmazonSQSHelper : IAmazonSQSHelper
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public AmazonSQSHelper(ILogger<AmazonSQSHelper> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public AmazonSQSClient GetAmazonSQSClient()
        {
            _logger.LogDebug("inside GetAmazonSQSClient method");
            var apiKey = _configuration.GetValue<string>("AmazonSQSSettings:ApiKey");
            var apiSecret = _configuration.GetValue<string>("AmazonSQSSettings:ApiSecret");
            var serviceUrl = _configuration.GetValue<string>("AmazonSQSSettings:ServiceUrl");

            var awsCreds = new BasicAWSCredentials(apiKey, apiSecret);

            AmazonSQSConfig amazonSQSConfig = new AmazonSQSConfig();
            amazonSQSConfig.ServiceURL = serviceUrl;
            var amazonSQSClient = new AmazonSQSClient(awsCreds, amazonSQSConfig);

            return amazonSQSClient;

        }

    }
}
