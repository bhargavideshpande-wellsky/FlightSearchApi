using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Contracts
{
    public interface IFlightEngine
    {
        Task<SearchResponse> GetFightByNumber(AchorFlightSearchRequest flightNumber, CancellationToken cancellationToken);
    }
}
