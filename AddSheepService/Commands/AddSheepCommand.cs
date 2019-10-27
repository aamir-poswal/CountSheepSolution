using AmazonSQS;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddSheepService.Commands
{
    public class AddSheepCommand : IRequest<bool>
    {
        public class AddSheepCommandCommandHandler : IRequestHandler<AddSheepCommand, bool>
        {
            private readonly IAmazonSQSPublisher _amazonSQSPublisher;
            private readonly ILogger _logger;
            public AddSheepCommandCommandHandler(IAmazonSQSPublisher amazonSQSPublisher, ILogger<AddSheepCommandCommandHandler> logger)
            {
                _amazonSQSPublisher = amazonSQSPublisher;
                _logger = logger;
            }

            public async Task<bool> Handle(AddSheepCommand request, CancellationToken cancellationToken)
            {
                var response = await _amazonSQSPublisher.SendMessage();
                _logger.LogDebug($"Message Id {response.MessageId}");

                return true;
            }
        }
    }
}
