using FinancialControl.Domain.Interfaces;
using FinancialControl.Infrastructure.Mongo;
using FinancialControl.Infrastructure.Repositories;
using FinancialControl.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FinancialControl.Infrastructure.Messaging;
using FinancialControl.Application.Messaging;



namespace FinancialControl.Infrastructure.DependencyInjection;


public static class InfrastructureDependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        MongoConfiguration.Configure();

        var mongoSettings =
            configuration
            .GetSection("MongoSettings")
            .Get<MongoSettings>();

        services.AddSingleton(mongoSettings!);

        var rabbitMqSettings =
            configuration
                .GetSection("RabbitMq")
                .Get<RabbitMqSettings>();

        services.AddSingleton(rabbitMqSettings!);


        services.AddSingleton<MongoContext>();

        services.AddSingleton<IMessagePublisher, RabbitMqPublisher>();

        services.AddScoped<ITransactionRepository, TransactionRepository>();


        return services;
    }
}