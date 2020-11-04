using System.Threading.Tasks;
using Incremental.Common.Sourcing.Commands.Contract;
using MediatR;

namespace Incremental.Common.Sourcing.Commands
{
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
        public Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _sender.Send(command);
        }
    }
}