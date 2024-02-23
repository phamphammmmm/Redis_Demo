using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using StackExchange.Redis.KeyspaceIsolation;

namespace Redis_Demo.Controllers
{
    [Route("api/cache")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;
        public CacheController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public string Get([FromQuery] string key)
        {
            return _database.StringGet(key);
        }

        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> keyValue)
        {
            _database.StringSet(keyValue.Key, keyValue.Value);
        }
    }
}
