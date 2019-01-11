using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Contracts
{
    public interface IFlightAdapter
    {
       Task<SearchResponse> GetFightByNumber(AchorFlightSearchRequest flightNumber, CancellationToken cancellationToken);
    }
}
