using SocialUpdatesAPI.Models;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private readonly ILogger<PostItem> _log;

        public UpdateStore()
        {
        }

        public UpdateStore(ILogger<PostItem> log)
        {
            _log = log;
        }

        public async Task SaveAsync(PostItem data)
        {
            _log.LogInformation(data.ToJson());

        }
    }
}
