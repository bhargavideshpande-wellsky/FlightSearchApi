using FlightSearchApi.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Plugins
{
    public class FlightDataService:IFlightDataService
    {

        private readonly ICacheProvider _cacheProvider;
        private readonly IDataStore _dataStore;
        public FlightDataService(ICacheProvider cacheProvider, IDataStore dataStore)
        {
            _cacheProvider = cacheProvider;
            _dataStore = dataStore;
        }
        public async Task<List<Flight>> GetFlightDataAsync(CancellationToken cancellationToken)
        {
            var response = await _cacheProvider.GetItemAsync<List<Flight>>("CacheFlightData", cancellationToken);
            if (response == null)
            {
                var flightResult = _dataStore.GetFlightData();
                await _cacheProvider.SaveItemAsync(flightResult, "CacheFlightData", cancellationToken);
                return flightResult;
            }
            else
            {
                return response;
            }
        }
    }
}
