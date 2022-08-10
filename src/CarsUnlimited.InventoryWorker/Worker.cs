using CarsUnlimited.InventoryWorker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarsUnlimited.InventoryWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var serviceBusConfig = _config.GetSection("ServiceBusConfiguration").Get<ServiceBusConfiguration>();

                ConnectionFactory connectionFactory = new()
                {
                    HostName = serviceBusConfig.HostName,
                    UserName = serviceBusConfig.UserName,
                    Password = serviceBusConfig.Password
                };

                using (var connection = connectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "cmd-inventory",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                    channel.BasicQos(0, 1, false);

                    MessageReceiver messageReceiver = new(channel, _config);

                    channel.BasicConsume("cmd-inventory", false, messageReceiver);

                    Console.ReadLine();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
