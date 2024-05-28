using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace UserManagement.Infrastructure.Messaging
{
    public abstract class BaseUserMessageConsumer : BackgroundService
    {
        protected readonly IConnection _connection;
        protected readonly IModel _channel;
        protected readonly IMediator _mediator;

        protected BaseUserMessageConsumer(string queueName, IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQ:Host"],
                Port = Convert.ToInt32(configuration["RabbitMQ:Port"])
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await ProcessMessageAsync(message);
            };
            _channel.BasicConsume(queue: GetQueueName(), autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        protected abstract Task ProcessMessageAsync(string message);
        protected abstract string GetQueueName();

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
