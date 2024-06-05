﻿using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"[START] Handle Request = {typeof(TRequest).Name} - Response = {typeof(TResponse).Name} - RequestData = {request}");

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();
        
        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)
            logger.LogWarning($"[PEFORMANCE] The request {typeof(TRequest).Name} took {timeTaken.Seconds} seconds to process.");
        
        logger.LogInformation($"[END] Handled Request = {typeof(TRequest).Name} - Response = {typeof(TResponse).Name} - TimeTaken = {timeTaken}");
        return response;
    }
}