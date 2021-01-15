using System.Threading.Tasks;
using JayrideChallenge.Interfaces;
using JayrideChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JayrideChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<CandidateController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> SearchLocation([FromBody] IPDetails ip)
        {
            
            var location = await _locationService.SearchIpLocation(ip);
            if (location == null)
            {
                return BadRequest("Data not found.");
            }

            return Ok(location);
        }
    }
}
