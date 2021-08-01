using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Sourcing.Pipeline
{
    internal class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Unit> where TRequest : IRequest
    {
        private readonly ILogger<ValidationPipeline<TRequest, TResponse>> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Watcher _watcher;

        public ValidationPipeline(ILogger<ValidationPipeline<TRequest, TResponse>> logger,
            IServiceScopeFactory scopeFactory, Watcher watcher)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _watcher = watcher;
        }

        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            using var scope = _scopeFactory.CreateScope();

            var requestId = _watcher.Get(request);

            var validator = scope.ServiceProvider.GetService<IValidator<TRequest>>();
            
            if (validator is not null)
            {
                var result = await validator.ValidateAsync(request, cancellationToken);

                _logger.LogInformation("Request {RequestName}:{RequestId} validation result is {ValidationResult}", 
                    request.GetType().FullName, requestId, result.IsValid);

                if (result.IsValid is false)
                {
                    return Unit.Value;
                }
            }

            return await next();
        }
    }
}