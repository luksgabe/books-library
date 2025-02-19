using BooksLibrary.Application.Interfaces;

namespace BooksLibrary.WorkerService
{
    public class Worker(ILogger<Worker> _logger, IBooksApiService _googleApiService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RecurringJob.AddOrUpdate("RecurringJob", () => _googleApiService.ProccessBooksAsync().GetAwaiter(), Cron.Minutely);

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
            await base.StopAsync(stoppingToken);
        }
    }
}
