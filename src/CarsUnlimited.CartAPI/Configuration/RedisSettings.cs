using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUnlimited.CartAPI.Configuration
{
    public interface IRedisSettings
    {
        bool Ssl { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        string Password { get; set; }
    }

    public class RedisSettings : IRedisSettings
    {
        public bool Ssl { get; set; }
        public string Host { get; set; } = "redis";
        public int Port { get; set; } = 6379;
        public string Password { get; set; }
    }
}
