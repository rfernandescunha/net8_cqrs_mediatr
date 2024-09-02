using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace Gertec.Api.Application.Handlers
{
    public class LoggingHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingHandler(ILogger<TRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {JsonSerializer.Serialize(request)} > start: {DateTime.Now}");
            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                var response = await next().ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, $"Handling > end: {DateTime.Now} | seconds: {stopwatch.Elapsed.TotalSeconds:n7} | err: {ex.Message}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation($"Handled {JsonSerializer.Serialize(request)} > end: {DateTime.Now} | seconds: {stopwatch.Elapsed.TotalSeconds:n7}");
            }
        }
    }
}