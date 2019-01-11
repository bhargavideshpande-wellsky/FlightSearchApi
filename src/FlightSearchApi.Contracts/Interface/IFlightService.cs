using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Contracts
{
    public interface IFlightService
    {
         Task<SearchResponse> GetFlightByNumber(AchorFlightSearchRequest flightNumber, CancellationToken cancellationToken);
    }
}
