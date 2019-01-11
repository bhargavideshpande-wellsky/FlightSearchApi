using FlightSearchApi.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Plugins
{
    public class MockFlightAdapter : IFlightAdapter
    {
        private readonly IFlightDataService _flightDataService;
        public MockFlightAdapter(IFlightDataService flightDataService)
        {
            _flightDataService = flightDataService;
        }
        public async Task<SearchResponse> GetFightByNumber(AchorFlightSearchRequest request, CancellationToken cancellationToken)
        {
           

            var errors = new List<Error>();
            var flights = await _flightDataService.GetFlightData(cancellationToken);
            var flight = flights.Find(x => CompareFlight(x, request.FlightNumber));

            if (flight == null)
            {
                errors.Add(new Error("1234", "No flight found for specified flight number"));
            }
            return new SearchResponse
            {
                Errors = errors,
                Flight = flight
            };
           
        }
        private bool CompareFlight(Flight flight, string flightNumber)
        {
            return flightNumber.Equals(flight.FlightNumber, StringComparison.InvariantCultureIgnoreCase);
        }
       

    }
}
