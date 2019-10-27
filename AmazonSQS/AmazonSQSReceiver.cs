using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSQS
{
    public class AmazonSQSReceiver : IAmazonSQSReceiver
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IAmazonSQSHelper _amazonSQSHelper;
        public AmazonSQSReceiver(IConfiguration configuration, ILogger<AmazonSQSReceiver> logger, IAmazonSQSHelper amazonSQSHelper)
        {
            _configuration = configuration;
            _logger = logger;
            _amazonSQSHelper = amazonSQSHelper;
        }

        public async Task<int> ReceiveMessage()
        {
            _logger.LogDebug("inside ReceiveMessage method");
            var receiveMessageRequest = new ReceiveMessageRequest();
            var amazonClient = _amazonSQSHelper.GetAmazonSQSClient();
            
            var queueUrl = _configuration.GetValue<string>("AmazonSQSSettings:QueueUrl");

            receiveMessageRequest.QueueUrl = queueUrl;
            var receiveMessageResponse = await amazonClient.ReceiveMessageAsync(receiveMessageRequest);

            if (receiveMessageResponse != null && receiveMessageResponse.HttpStatusCode == System.Net.HttpStatusCode.OK && receiveMessageResponse.Messages.Count > 0)
            {
                var messageCount = receiveMessageResponse.Messages.Count;
                foreach (var message in receiveMessageResponse.Messages)
                {
                    var deleteMessageRequest = new DeleteMessageRequest();
                    deleteMessageRequest.QueueUrl = queueUrl;
                    deleteMessageRequest.ReceiptHandle = message.ReceiptHandle;
                    var result = await amazonClient.DeleteMessageAsync(deleteMessageRequest);
                }

                return messageCount;
            }

            return 0;
        }



    }
}
