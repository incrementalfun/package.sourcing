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
    internal class CommandValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Unit> where TRequest : ICommand
    {
        private readonly ILogger<CommandValidationPipeline<TRequest, TResponse>> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly Watcher _watcher;

        public CommandValidationPipeline(ILogger<CommandValidationPipeline<TRequest, TResponse>> logger,
            IServiceProvider serviceProvider, Watcher watcher)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _watcher = watcher;
        }

        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var requestName = request.GetType().FullName;
            var requestId = _watcher.Get(request);
            
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator is not null)
            {
                var result = await validator.ValidateAsync(request, cancellationToken);

                _logger.LogInformation("{RequestName}:{RequestId} validation result is {ValidationResult}", 
                    requestName, requestId, result.IsValid);

                if (result.IsValid is false)
                {
                    return Unit.Value;
                }
            }

            return await next();
        }
    }
}