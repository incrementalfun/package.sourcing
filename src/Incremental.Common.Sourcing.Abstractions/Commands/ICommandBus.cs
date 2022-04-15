using System.Threading;
using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Abstractions.Commands;

/// <summary>
/// Bus for sending command requests.
/// </summary>
public interface ICommandBus
{
    /// <summary>
    /// Sends a command.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand"></typeparam>
    /// <returns></returns>
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : Command;
}