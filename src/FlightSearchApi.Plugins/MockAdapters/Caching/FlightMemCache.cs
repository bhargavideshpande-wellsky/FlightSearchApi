using FlightSearchApi.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSearchApi.Plugins
{
    public class MemoryCacheProvider:ICacheProvider
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<T> GetItemAsync<T>(string key, CancellationToken cancellationToken)
        {
            var item =  await Task.Run(()=> _memoryCache.Get<T>(key), cancellationToken);
            return item;
        }

        public async Task SaveItemAsync<T>(T item, string key, CancellationToken cancellationToken)
        {
            var memoryCachingOption = new MemoryCacheEntryOptions();
            memoryCachingOption.SlidingExpiration = TimeSpan.FromSeconds(60);
            Task.Run(() => _memoryCache.Set(key, item, memoryCachingOption), cancellationToken);
        }
    }
}
