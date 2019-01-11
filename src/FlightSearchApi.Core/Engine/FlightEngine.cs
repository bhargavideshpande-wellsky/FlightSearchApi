using FlightSearchApi.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Core
{
    public class FlightEngine : IFlightEngine
    {
        private readonly IFlightAdapter _flightAdapter;
        public FlightEngine(IFlightAdapter flightAdapter)
        {
            _flightAdapter = flightAdapter;
        }
        public async Task<SearchResponse> GetFightByNumber(AchorFlightSearchRequest request, CancellationToken cancellationToken)
        {
            var response = await _flightAdapter.GetFightByNumber(request,cancellationToken);
            return response;
        }
    }
}
