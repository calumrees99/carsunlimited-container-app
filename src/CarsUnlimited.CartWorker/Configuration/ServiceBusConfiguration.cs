using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsUnlimited.CartWorker.Configuration
{
    public interface IServiceBusConfiguration
    {
        string HostName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }

    public class ServiceBusConfiguration : IServiceBusConfiguration
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
