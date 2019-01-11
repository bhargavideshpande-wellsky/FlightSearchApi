using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSearchApi.Contracts
{
    public interface IDataStore
    {
        List<Flight> GetFlightData();
    }
}
