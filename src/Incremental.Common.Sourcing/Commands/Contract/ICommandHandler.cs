using MediatR;

namespace Incremental.Common.Sourcing.Commands.Contract
{
    /// <summary>
    /// Command Handler.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }
}