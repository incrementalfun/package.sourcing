using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Commands.Contract
{
    /// <summary>
    /// Bus for sending command requests.
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Sends a command.
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="TCommand"></typeparam>
        /// <returns></returns>
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}