using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SheepApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheepController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IAddSheepService _addSheepService;
        private readonly ICountSheepService _countSheepService;
        public SheepController(ILogger<SheepController> logger, IAddSheepService addSheepService, ICountSheepService countSheepService)
        {
            _logger = logger;
            _addSheepService = addSheepService;
            _countSheepService = countSheepService;

        }

        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            try
            {
                _logger.LogDebug("Inside Get Sheep API Method");
                return Ok(await _countSheepService.GetSheepCount());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            try
            {
                _logger.LogDebug("Inside Add Sheep");
                await _addSheepService.AddSheep();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}