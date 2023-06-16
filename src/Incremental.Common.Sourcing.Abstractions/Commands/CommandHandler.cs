using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace Incremental.Common.Sourcing.Abstractions.Commands;

/// <summary>
/// Command Handler.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public abstract class CommandHandler<TCommand> : IConsumer<TCommand> where TCommand : Command
{
    /// <inheritdoc />
    public abstract Task Consume(ConsumeContext<TCommand> context);
}