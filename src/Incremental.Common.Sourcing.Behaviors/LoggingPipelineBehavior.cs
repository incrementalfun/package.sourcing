using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Sourcing.Behaviors;

internal class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var stopwatch = Stopwatch.StartNew();
        var requestName = request.GetType().FullName;

        _logger.LogInformation("Request {RequestName} started", requestName);

        TResponse response;

        try
        {
            try
            {
                _logger.LogInformation("{RequestName} has properties {@Properties}", requestName, JsonSerializer.Serialize(request));
            }
            catch (NotSupportedException)
            {
                _logger.LogWarning("{RequestName} properties could not be serialized", requestName);
            }

            response = await next();
        }
        finally
        {
            stopwatch.Stop();
                
            if (stopwatch.Elapsed.TotalSeconds >= 30)
            {
                _logger.LogWarning("Request {RequestName} ended in {ExecutionTime}", 
                    requestName, $"{stopwatch.ElapsedMilliseconds}ms");
            }
            else
            {
                _logger.LogInformation("Request {RequestName} ended in {ExecutionTime}",
                    requestName, $"{stopwatch.ElapsedMilliseconds}ms");
            }
        }

        return response;
    }
}