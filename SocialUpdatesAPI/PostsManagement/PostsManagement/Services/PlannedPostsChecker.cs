namespace PostsManagementAPI.Services
{
    public class PlannedPostsChecker : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private int _secondsInterval;

        public PlannedPostsChecker()
        {
            // тоже самое - конфигурацию брать только в program.cs. брать 1 раз и через IoC прокидывать по проекту
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            _secondsInterval = int.Parse(configuration["UpdateInterval"]);
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(
                    Check,
                    null,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(_secondsInterval)
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
