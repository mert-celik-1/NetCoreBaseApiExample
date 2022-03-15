using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Cache
{
    public class RedisSettings
    { 
        ConnectionMultiplexer connectionMultiplexer;
        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
        public IDatabase GetDb(int db) => connectionMultiplexer.GetDatabase(db);
    }
}
