using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ResponseCachingMiddleware.DotNet5.Bug
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var start = Stopwatch.GetTimestamp();
            await _next(httpContext);
            var elapsedMs = _GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());
            _logger.LogInformation($"Request handled in {elapsedMs:0} ms.");

        }

        private double _GetElapsedMilliseconds(long start, long stop)
        {
            return (stop - start) * 1000 / (double)Stopwatch.Frequency;
        }
    }
}