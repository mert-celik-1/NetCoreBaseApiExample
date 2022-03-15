using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Cache
{
    public interface ICacheService
    {
        Task<string> GetCache(string key);
        Task SetCache(string key,string value);
    }
}
