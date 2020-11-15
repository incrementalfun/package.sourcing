using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Incremental.Common.Sourcing.Commands.Contract;
using Incremental.Common.Sourcing.Events.Contract;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Sourcing.Pipeline
{
    /// <summary>
    /// Pipeline for validating commands.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class CommandValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Unit> where TRequest : ICommand
    {
        private readonly ILogger<CommandValidationPipeline<TRequest, TResponse>> _logger;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceProvider"></param>
        public CommandValidationPipeline(ILogger<CommandValidationPipeline<TRequest, TResponse>> logger,
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

            if (validator is not null)
            {
                var result = await validator.ValidateAsync(request, cancellationToken);

                _logger.LogInformation("Result of validating {Request}: {ValidationResult}", typeof(TRequest).Name, result.IsValid);

                if (result.IsValid is false)
                {
                    return Unit.Value;
                }
            }

            return await next();
        }
    }
}