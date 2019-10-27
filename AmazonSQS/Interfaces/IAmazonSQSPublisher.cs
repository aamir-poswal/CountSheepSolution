using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSQS
{
    public interface IAmazonSQSPublisher
    {
        Task<SendMessageResponse> SendMessage();
    }
}
