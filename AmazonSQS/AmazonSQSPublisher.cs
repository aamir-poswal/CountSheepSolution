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
    public class AmazonSQSPublisher : IAmazonSQSPublisher
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IAmazonSQSHelper _amazonSQSHelper;
        public AmazonSQSPublisher(IConfiguration configuration, ILogger<AmazonSQSPublisher> logger, IAmazonSQSHelper amazonSQSHelper)
        {
            _configuration = configuration;
            _logger = logger;
            _amazonSQSHelper = amazonSQSHelper;
        }

        public async Task<SendMessageResponse> SendMessage()
        {

            var amazonClient = _amazonSQSHelper.GetAmazonSQSClient();
            var queueUrl = _configuration.GetValue<string>("AmazonSQSSettings:QueueUrl");
            var sendRequest = new SendMessageRequest();
            sendRequest.QueueUrl = queueUrl;
            var payload = $"Add Sheep {DateTime.Now.Millisecond}";
            sendRequest.MessageBody = "{ 'message' : '{" + payload + "}' }";
            sendRequest.MessageGroupId = "AddSheepService";

            var response = await amazonClient.SendMessageAsync(sendRequest);
            _logger.LogDebug($"Message Id {response.MessageId}");

            return response;

        }
    }
}
