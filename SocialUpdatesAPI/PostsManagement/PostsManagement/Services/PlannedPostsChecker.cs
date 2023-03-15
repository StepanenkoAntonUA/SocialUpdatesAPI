using Common;
using Domain;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.Extensions.Options;
using NuGet.Protocol;

namespace PostsManagementAPI.Services
{
    public class PlannedPostsChecker : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private int _secondsInterval;
        private int _delaySec;
        private IPostsManagementService _service;

        public PlannedPostsChecker(IOptions<PlannedPostsCheckerOptions> options,
            IPostsManagementService service)
        {
            _secondsInterval = options.Value.UpdateIntervalSec;
            _delaySec = options.Value.PlannedPostDelaySec;

            _service = service;
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

            var plannedPosts = await _service.GetPostsAsync(_delaySec);
            
            using (var sw = new StreamWriter(fileName, true))
            {
                foreach (var post in plannedPosts)
                {
                    var postId = post.Id;
                    await sw.WriteLineAsync(post.ToJson());
                    await _service.SetIsPostedAsync(postId);
                }
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
