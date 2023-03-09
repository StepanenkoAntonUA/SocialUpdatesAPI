namespace PostsManagementAPI.Services
{
    public class PlannedPostsChecker : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private const int SecondsInterval = 5;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(
                    Check,
                    null, 
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(SecondsInterval)
                );

            return Task.CompletedTask;
        }

        private async void Check(object? state)
        {
            var currentDir = Path.Combine(Directory.GetCurrentDirectory());
            var fileName = $"{currentDir}\\Checker.txt";
            var message = $"Checking {DateTime.UtcNow}";

            using (var sw = new StreamWriter(fileName, true))
            {
                await sw.WriteLineAsync(message);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
