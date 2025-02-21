using BooksLibrary.Application.Interfaces;

namespace BooksLibrary.WorkerService
{
    public class Worker(ILogger<Worker> _logger, IBooksApiService _googleApiService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            // Schedule the job to run every hour using Hangfire
            RecurringJob.AddOrUpdate("RecurringJob", () => _googleApiService.ProccessBooksAsync(), Cron.Hourly);

            // Optionally log periodically to keep the service alive
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker is alive at: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
            await base.StopAsync(stoppingToken);
        }
    }
}
