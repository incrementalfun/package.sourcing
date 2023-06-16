using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Sourcing.Messaging;

/// <summary>
/// Registers bus and pipelines for messaging.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all the buses and requests for messaging
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddTransient<IMessageBus, MessageBus>();

        return services;
    }
}