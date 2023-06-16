using System.Collections.Generic;

namespace Incremental.Common.Sourcing.Configuration;

/// <summary>
/// Incremental Sourcing Options
/// </summary>
public class SourcingOptions
{
    private readonly Dictionary<string, object> _options;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public SourcingOptions()
    {
        _options = new Dictionary<string, object>();
    }
    
    /// <summary>
    /// Try to register an option.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public bool TryRegisterOption(string key, object option)
    {
        return _options.TryAdd(key, option);
    }
        
    /// <summary>
    /// Force the registration of an options, overwriting previous values if necessary.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="option"></param>
    public void ForceRegisterOption(string key, object option)
    {
        _options.Remove(key);

        TryRegisterOption(key, option);
    }

    /// <summary>
    /// Retrieves an option.
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="TType"></typeparam>
    /// <returns></returns>
    public TType? RetrieveOption<TType>(string key)
    {
        if (_options.TryGetValue(key, out var option))
        {
            return (TType) option;
        }

        return default;
    }

    /// <summary>
    /// Retrieves all options.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, object> RetrieveAllOptions()
    {
        return _options;
    }
}