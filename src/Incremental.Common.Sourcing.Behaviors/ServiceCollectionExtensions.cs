using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Sourcing.Behaviors;

/// <summary>
/// Registers pipelines behaviors.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the logging behavior.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddLoggingBehavior(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            
        return services;
    }
}