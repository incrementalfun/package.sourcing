﻿using System.Reflection;
using Incremental.Common.Sourcing.Commands;
using Incremental.Common.Sourcing.Commands.Contract;
using Incremental.Common.Sourcing.Events;
using Incremental.Common.Sourcing.Events.Contract;
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
        public static IServiceCollection AddSourcing(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();
            
            return services;
        }
    }
}