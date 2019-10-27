using AmazonSQS;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SheepCountService
{
    public class AmazonSQSBackgroundConsumer : BackgroundService
    {
        private readonly ILogger<AmazonSQSBackgroundConsumer> _logger;
        private readonly IAmazonSQSReceiver _amazonSQSReceiver;
        private readonly IAddSheepService _addSheepService;
        public AmazonSQSBackgroundConsumer(ILogger<AmazonSQSBackgroundConsumer> logger, IAmazonSQSReceiver amazonSQSReceiver, IAddSheepService addSheepService)
        {
            _logger = logger;
            _amazonSQSReceiver = amazonSQSReceiver;
            _addSheepService = addSheepService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: {DateTime.Now}");
                var sheepToAddCount = await _amazonSQSReceiver.ReceiveMessage();
                _addSheepService.AddSheep(sheepToAddCount);
                await Task.Delay(500, stoppingToken);
            }
        }

    }
}
