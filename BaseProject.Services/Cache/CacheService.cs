using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly RedisSettings _redisSettings;
        private readonly IDatabase db;

        public CacheService(RedisSettings redisSettings)
        {
            _redisSettings = redisSettings;
            db=redisSettings.GetDb(2);
        }
        public async Task<string> GetCache(string key)
        {
            var data=await db.StringGetAsync(key);

            return data.ToString();
        }

        public async Task SetCache(string key, string value)
        {
            await db.StringSetAsync(key, value);
        }
    }
}
