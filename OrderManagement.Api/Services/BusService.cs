using Azure.Messaging.ServiceBus;
using System.Text.Json;
using OrderManagement.Api.Models;
using Microsoft.Extensions.Configuration;

namespace OrderManagement.Api.Services
{
    public class BusService : IBusService
    {
        private readonly string _connectionString;
        private readonly string _queueName;

        public BusService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureServiceBus")!;
            _queueName = "orders"; // nome da fila
        }

        public async Task SendMessageAsync(Order order)
        {
            await using var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(_queueName);

            var messageBody = JsonSerializer.Serialize(new
            {
                order.Id,
                order.CustomerId,
                order.CreatedAt,
                Products = order.OrderProducts.Select(op => new
                {
                    op.ProductId
                })
            });

            var message = new ServiceBusMessage(messageBody);
            await sender.SendMessageAsync(message);
        }
    }
}
