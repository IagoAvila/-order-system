using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using OrderManagement.Api.Models;

namespace OrderManagement.Api.Services
{
    public class ServiceBusSenderService
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public ServiceBusSenderService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureServiceBus:ConnectionString"];
            var queueName = configuration["AzureServiceBus:QueueName"];

            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(queueName);
        }

        public async Task SendMessageAsync(Order order)
        {
            var messageBody = JsonSerializer.Serialize(order);
            var message = new ServiceBusMessage(messageBody);
            await _sender.SendMessageAsync(message);
        }
    }
}
