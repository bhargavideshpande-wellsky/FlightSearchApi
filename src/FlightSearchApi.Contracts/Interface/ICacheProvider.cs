using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Contracts
{
    public interface ICacheProvider
    {
        Task<T> GetItemAsync<T>(string key, CancellationToken cancellationToken);
        Task SaveItemAsync<T>(T item, string key, CancellationToken cancellationToken);
    }
}
