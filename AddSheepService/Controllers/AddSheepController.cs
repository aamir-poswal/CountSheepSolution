using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddSheepService.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AddSheepService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSheepController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILogger _logger;
        public AddSheepController(ILogger<AddSheepController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> Post()
        {
            try
            {
                _logger.LogDebug($"Add Sheep Count {DateTime.Now.ToShortTimeString()}");
                var command = new AddSheepCommand();
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}