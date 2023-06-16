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
    private readonly ISendEndpointProvider _provider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="provider"></param>
    public CommandBus(ISendEndpointProvider provider)
    {
        _provider = provider;
    }

    /// <inheritdoc />
    public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : Command
    {
        await _provider.Send(command, cancellationToken)
            .ConfigureAwait(false);
    }
}