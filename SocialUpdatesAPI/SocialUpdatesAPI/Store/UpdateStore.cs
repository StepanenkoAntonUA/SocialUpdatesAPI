using SocialUpdatesAPI.Models;
using NuGet.Protocol;
using System.Globalization;
using Microsoft.Extensions.Hosting.Internal;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        public async Task SaveAsync(PostItem data)
        {          
            var currentDir = Path.Combine(Directory.GetCurrentDirectory());
            var currentTimeStr = DateTime.UtcNow.ToString("yyyyMMdd");
            var fileName = $"{currentDir}\\{currentTimeStr}.log";

            var message = data.ToJson();
            using (var sw = new StreamWriter(fileName, true ))
            {
                await sw.WriteLineAsync(message);
            }
        }
    }
}
