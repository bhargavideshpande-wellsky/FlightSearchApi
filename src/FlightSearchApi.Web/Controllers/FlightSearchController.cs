using FlightSearchApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightSearchApi.Web
{
    [Route("api/air/v1.0/search")]
    public class FlightSearchController : Controller
    {
        
        private readonly IFlightService _flightService;
        public FlightSearchController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Route("flight")]
        public async Task<IActionResult> GetFlightByNumber([FromBody]AchorFlightSearchRequest request, CancellationToken cancellationToken)
        {
            var response = await _flightService.GetFlightByNumber(request,cancellationToken);
                return Ok(response);
            
        }

        [HttpGet]
        [Route("healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok("Application is up");
        }
        
    }
}
