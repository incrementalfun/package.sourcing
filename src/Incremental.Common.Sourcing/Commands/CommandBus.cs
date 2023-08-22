using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Abstractions.Commands;
using MassTransit;

namespace Incremental.Common.Sourcing.Commands;

/// <summary>
/// Default implementation of ICommandBus.
/// </summary>
public class CommandBus : ICommandBus
{
    private readonly IPublishEndpoint _provider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="provider"></param>
    public CommandBus(IPublishEndpoint provider)
    {
        _provider = provider;
    }

    /// <inheritdoc />
    public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : Command
    {
        await _provider.Publish(command, cancellationToken)
            .ConfigureAwait(false);
    }
}