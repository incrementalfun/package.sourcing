using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Incremental.Common.Sourcing.Commands.Contract;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Sourcing.Pipeline
{
    /// <summary>
    /// Pipeline for validating commands.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class CommandValidationPipeline<TRequest> : IPipelineBehavior<TRequest, Unit> where TRequest : ICommand
    {
        private readonly ILogger<CommandValidationPipeline<TRequest>> _logger;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceProvider"></param>
        public CommandValidationPipeline(ILogger<CommandValidationPipeline<TRequest>> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Checks if a command is valid and cancels it otherwise.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                var result = await validator.ValidateAsync(request, cancellationToken);

                _logger.LogInformation("Validation of {Request}: {ValidationResult}", nameof(request), result.IsValid);

                if (!result.IsValid)
                {
                    return Unit.Value;
                }
            }

            return await next();
        }
    }
}