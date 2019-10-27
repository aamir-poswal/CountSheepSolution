using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SheepCountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheepController : ControllerBase
    {
        private readonly ICountSheepService _countSheepService;
        private readonly ILogger _logger;
        public SheepController(ICountSheepService countSheepService, ILogger<SheepController> logger)
        {
            _countSheepService = countSheepService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<int> SheepCount()
        {
            try
            {
                return Ok(_countSheepService.GetSheepCount());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}