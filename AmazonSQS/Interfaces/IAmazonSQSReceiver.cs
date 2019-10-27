using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSQS
{
    public interface IAmazonSQSReceiver
    {
        Task<int> ReceiveMessage();
    }
}
