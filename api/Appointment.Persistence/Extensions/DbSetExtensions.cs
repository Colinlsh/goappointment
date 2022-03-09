using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Persistence.Extentions
{
    public static class DbSetExtensions
    {
        public static List<T> GetFromCache<T>(this IQueryable<T> t, IMemoryCache memoryCache) where T : class
        {
            var assemblyName = t.GetType().FullName;

            var result = memoryCache.GetOrCreate($"Cache_{assemblyName}", (cacheEntry) => {
                Log.Debug($"Populating {assemblyName} memory cache.");
                try
                {
                    var mappings = t.AsNoTracking().ToList();

                    Log.Debug($"{assemblyName} successfully populated in memory cache.");

                    return mappings;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Unable to populate {assemblyName} in memory cache.");

                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);

                    return null;
                }
            });
            return result;
        }
    }
}

