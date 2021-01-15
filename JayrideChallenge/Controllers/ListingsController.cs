using System.Threading.Tasks;
using JayrideChallenge.Interfaces;
using JayrideChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JayrideChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ILogger<ListingsController> _logger;
        private readonly IListingsService _listingsService;

        public ListingsController(ILogger<ListingsController> logger, IListingsService listingsService)
        {
            _logger = logger;
            _listingsService = listingsService;
        }

        [HttpPost]
        public async Task<ActionResult<ListingsVm>> GetListings([FromQuery] int passengers)
        {
            var listings = await _listingsService.GetListings(passengers);
            return Ok(listings);
        }
    }
}
