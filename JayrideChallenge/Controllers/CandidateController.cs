using JayrideChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JayrideChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {

        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ILogger<CandidateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Candidate> GetCandidate()
        {
            return Ok(new Candidate
            {
                Name = "test",
                Phone = "test"
            });
        }

    }
}
