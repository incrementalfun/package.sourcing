using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Abstractions.Commands;
using MediatR;

namespace Incremental.Common.Sourcing.Commands;

/// <summary>
/// Default implementation of ICommandBus.
/// </summary>
public class CommandBus : ICommandBus
{
    private readonly ISender _sender;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="sender"></param>
    public CommandBus(ISender sender)
    {
        _sender = sender;
    }


    /// <inheritdoc />
    public Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : Command
    {
        return _sender.Send(command, cancellationToken);
    }
}