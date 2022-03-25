using System.Reflection;
using Incremental.Common.Sourcing.Abstractions.Commands;
using Incremental.Common.Sourcing.Abstractions.Events;
using Incremental.Common.Sourcing.Abstractions.Queries;
using Incremental.Common.Sourcing.Commands;
using Incremental.Common.Sourcing.Events;
using Incremental.Common.Sourcing.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Sourcing
{
    /// <summary>
    /// Registers bus and pipelines.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all the buses and requests.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IServiceCollection AddSourcing(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            
            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<IQueryBus, QueryBus>();
            services.AddTransient<IEventBus, EventBus>();

            return services;
        }
    }
}