﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Sourcing.Pipeline
{
    internal class LoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipeline<TRequest, TResponse>> _logger;
        private readonly Watcher _watcher;

        public LoggingPipeline(ILogger<LoggingPipeline<TRequest, TResponse>> logger, Watcher watcher)
        {
            _logger = logger;
            _watcher = watcher;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = Stopwatch.StartNew();
            var requestName = request.GetType().FullName;
            var requestId = _watcher.Add(request);

            _logger.LogInformation("Request {RequestName}:{RequestId} started", 
                requestName, requestId);

            TResponse response;

            try
            {
                try
                {
                    if (request.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest)))
                    {
                        _logger.LogInformation("{RequestName}:{RequestId} has properties {@Properties}", 
                            requestName, requestId, JsonSerializer.Serialize(request));
                    }
                }
                catch (NotSupportedException)
                {
                    _logger.LogWarning("{RequestName}:{RequestId} properties could not be serialized", 
                        requestName, requestId);
                }

                response = await next();
            }
            finally
            {
                stopwatch.Stop();
                
                if (stopwatch.Elapsed.TotalSeconds >= 30)
                {
                    _logger.LogWarning("Request {RequestName}:{RequestId} ended in {ExecutionTime}", 
                        requestName, requestId, $"{stopwatch.ElapsedMilliseconds}ms");
                }
                else
                {
                    _logger.LogInformation("Request {RequestName}:{RequestId} ended in {ExecutionTime}",
                        requestName, requestId, $"{stopwatch.ElapsedMilliseconds}ms");
                }
            }

            return response;
        }
    }
}