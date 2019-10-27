using Amazon.SQS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonSQS
{
    public interface IAmazonSQSHelper
    {
        AmazonSQSClient GetAmazonSQSClient();
    }
}
