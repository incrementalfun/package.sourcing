using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Commands;

/// <summary>
/// Command Handler.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : Command
{
    /// <inheritdoc />
    public abstract Task<Unit> Handle(TCommand command, CancellationToken cancellationToken);
}