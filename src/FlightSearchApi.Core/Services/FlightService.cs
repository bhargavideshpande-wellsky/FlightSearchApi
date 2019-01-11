using FlightSearchApi.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Core
{
    public class FlightService:IFlightService
    {
        private readonly IValidator _validator;
        private readonly IFlightEngine _flightEngine;
        public FlightService(IValidator validator, IFlightEngine flightEngine)
        {
            _validator = validator;
            _flightEngine = flightEngine;
        }
        public async Task<SearchResponse> GetFlightByNumber(AchorFlightSearchRequest request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);
            var response = await _flightEngine.GetFightByNumber(request, cancellationToken);
            return response;
        }
    }
}
