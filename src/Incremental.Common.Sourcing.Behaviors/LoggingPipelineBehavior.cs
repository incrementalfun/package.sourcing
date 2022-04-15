using System.Diagnostics;
using System.Text.Json;
using Incremental.Common.Sourcing.Abstractions.Commands;
using Incremental.Common.Sourcing.Abstractions.Queries;
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

        var requestType = request switch
        {
            Command => "Command",
            Query<TResponse> => "Query",
            _ => "Request"
        };

        _logger.LogInformation("{RequestType} {RequestName} started", requestType, requestName);

        TResponse response;

        try
        {
            _logger.LogInformation("{RequestType} {RequestName} has properties {@Properties}", 
                requestType, requestName, JsonSerializer.Serialize(request));

            response = await next();
        }
        finally
        {
            stopwatch.Stop();
                
            if (stopwatch.Elapsed > TimeSpan.FromSeconds(15))
            {
                _logger.LogWarning("{RequestType} {RequestName} ended in {ExecutionTime}", 
                    requestType, requestName, $"{stopwatch.ElapsedMilliseconds}ms");
            }
            else
            {
                _logger.LogInformation("{RequestType} {RequestName} ended in {ExecutionTime}",
                    requestType, requestName, $"{stopwatch.ElapsedMilliseconds}ms");
            }
        }

        return response;
    }
}