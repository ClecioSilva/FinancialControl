using System.Text;
using System.Text.Json;
using FinancialControl.Infrastructure.Configurations;
using RabbitMQ.Client;
using FinancialControl.Application.Messaging;

namespace FinancialControl.Infrastructure.Messaging;

public class RabbitMqPublisher : IMessagePublisher
{
    private readonly RabbitMqSettings _settings;


    public RabbitMqPublisher(
        RabbitMqSettings settings)
    {
        _settings = settings;
    }


    public async Task PublishAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password
        };


        await using var connection =
            await factory.CreateConnectionAsync(
                cancellationToken);


        await using var channel =
            await connection.CreateChannelAsync(
                cancellationToken: cancellationToken);



        await channel.QueueDeclareAsync(
            queue: _settings.QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            cancellationToken: cancellationToken);



        var json =
            JsonSerializer.Serialize(message);


        var body =
            Encoding.UTF8.GetBytes(json);



        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: _settings.QueueName,
            body: body,
            cancellationToken: cancellationToken);
    }
}