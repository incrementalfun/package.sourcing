using System;
using System.Collections.Generic;
using System.Reflection;
using MassTransit;

namespace Incremental.Common.Sourcing.Configuration;

/// <summary>
/// Extensions for <see cref="SourcingOptions"/>.
/// </summary>
public static class SourcingOptionsExtensions
{
    #region Assemblies

    private const string SourcingAssembliesKey = "_incremental.sourcing.options.sourcing_assemblies";

    /// <summary>
    /// Register assemblies to examine for sourcing usages.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="assemblies"></param>
    public static void FromAssemblies(this SourcingOptions options, params Assembly[] assemblies)
    {
        var registeredAssemblies = options.RetrieveOption<Assembly[]>(SourcingAssembliesKey);

        if (registeredAssemblies?.Length > 0)
        {
            var combinedAssemblies = new List<Assembly>(registeredAssemblies);
            combinedAssemblies.AddRange(assemblies);
                
            options.TryRegisterOption(SourcingAssembliesKey, combinedAssemblies);
        }
        else
        {
            options.TryRegisterOption(SourcingAssembliesKey, assemblies);
        }
    }

    /// <summary>
    /// Get assemblies to examine for sourcing usages.
    /// </summary>
    /// <param name="options"><see cref="SourcingOptions"/></param>
    /// <returns><see cref="IReadOnlyList{T}"/> of <see cref="Assembly"/>.</returns>
    public static IReadOnlyList<Assembly> GetAssemblies(this SourcingOptions options)
    {
        return options.RetrieveOption<Assembly[]>(SourcingAssembliesKey) ?? new[] { Assembly.GetCallingAssembly()};
    }

    #endregion

    #region MassTransitConfiguration

    private const string MassTransitConfiguration = "_incremental.sourcing.options.masstransit_configuration";

    /// <summary>
    /// Configure MassTransit.
    /// </summary>
    /// <param name="options"><see cref="SourcingOptions"/></param>
    /// <param name="busConfiguration"><see cref="IBusRegistrationConfigurator"/></param>
    public static void ConfigureBus(this SourcingOptions options, Action<IBusRegistrationConfigurator> busConfiguration)
    {
        options.TryRegisterOption(MassTransitConfiguration, busConfiguration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static Action<IBusRegistrationConfigurator>? GetBusConfiguration(this SourcingOptions options)
    {
        return options.RetrieveOption<Action<IBusRegistrationConfigurator>>(MassTransitConfiguration);
    }
    
    #endregion
    
    #region EndpointNameFormatter

    private const string EndpointNameFormatter = "_incremental.sourcing.options.endpoint_formatter";

    /// <summary>
    /// Configure MassTransit.
    /// </summary>
    /// <param name="options"><see cref="SourcingOptions"/></param>
    /// <param name="busConfiguration"><see cref="IBusRegistrationConfigurator"/></param>
    public static void ConfigureEndpointFormatter(this SourcingOptions options, Action<IBusRegistrationConfigurator> busConfiguration)
    {
        options.TryRegisterOption(EndpointNameFormatter, busConfiguration);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static Action<IBusRegistrationConfigurator>? GetEndpointFormatter(this SourcingOptions options)
    {
        return options.RetrieveOption<Action<IBusRegistrationConfigurator>>(EndpointNameFormatter);
    }
    
    #endregion
}