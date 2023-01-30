using SocialUpdatesAPI.Models;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using SocialUpdatesAPI.Common;
using System.Globalization;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private readonly ILogger<PostItem> _log;

        public UpdateStore(ILogger<PostItem> log)
        {
            _log = log;
        }

        public async Task SaveAsync(PostItem data)
        {
            Logger.Info($"{data.ToJson()}");
            Logger.Error($"{data.ToJson()}");
        }
    }
}
