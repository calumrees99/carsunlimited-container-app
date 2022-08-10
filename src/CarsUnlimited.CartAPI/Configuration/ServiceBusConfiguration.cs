namespace CarsUnlimited.CartAPI.Configuration
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
