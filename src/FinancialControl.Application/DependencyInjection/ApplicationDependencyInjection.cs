using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FinancialControl.Application.DependencyInjection;


public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(
                typeof(ApplicationDependencyInjection)
                .Assembly);
        });


        services.AddValidatorsFromAssembly(
            typeof(ApplicationDependencyInjection)
            .Assembly);


        return services;
    }
}