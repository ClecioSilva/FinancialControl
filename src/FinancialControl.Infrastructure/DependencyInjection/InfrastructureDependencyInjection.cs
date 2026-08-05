using FinancialControl.Domain.Interfaces;
using FinancialControl.Infrastructure.Mongo;
using FinancialControl.Infrastructure.Repositories;
using FinancialControl.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FinancialControl.Infrastructure.DependencyInjection;


public static class InfrastructureDependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var mongoSettings =
            configuration
            .GetSection("MongoSettings")
            .Get<MongoSettings>();


        services.AddSingleton(mongoSettings!);


        services.AddSingleton<MongoContext>();


        services.AddScoped<ITransactionRepository, TransactionRepository>();


        return services;
    }
}