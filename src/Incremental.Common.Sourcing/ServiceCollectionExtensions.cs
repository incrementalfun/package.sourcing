using System;
using System.Reflection;
using Incremental.Common.Sourcing.Abstractions.Commands;
using Incremental.Common.Sourcing.Abstractions.Events;
using Incremental.Common.Sourcing.Abstractions.Queries;
using Incremental.Common.Sourcing.Commands;
using Incremental.Common.Sourcing.Configuration;
using Incremental.Common.Sourcing.Events;
using Incremental.Common.Sourcing.Queries;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Sourcing;

/// <summary>
/// Registers bus and pipelines.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all the buses and requests.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="optionsAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddSourcing(this IServiceCollection services, Action<SourcingOptions> optionsAction)
    {
        if (optionsAction == null)
        {
            throw new ArgumentNullException(nameof(optionsAction));
        }

        services.AddOptions<SourcingOptions>().Configure(optionsAction);

        var options = new SourcingOptions();
        optionsAction.Invoke(options);

        services.AddMassTransit(configurator =>
        {
            options.GetBusConfiguration()?.Invoke(configurator);
            options.GetEndpointFormatter()?.Invoke(configurator);
        });

        services.AddTransient<ICommandBus, CommandBus>();
        services.AddTransient<IQueryBus, QueryBus>();
        services.AddTransient<IEventBus, EventBus>();


        return services;
    }
}