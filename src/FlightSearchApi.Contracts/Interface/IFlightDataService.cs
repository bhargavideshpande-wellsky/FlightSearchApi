using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Contracts
{
    public interface IFlightDataService
    {
        Task<List<Flight>> GetFlightData(CancellationToken cancellationToken);
    }
}
