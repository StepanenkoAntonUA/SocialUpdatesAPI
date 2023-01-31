using SocialUpdatesAPI.Models;
using NuGet.Protocol;
using System.Globalization;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {

        public UpdateStore(ILogger<PostItem> log)
        {
        }

        public async Task SaveAsync(PostItem data)
        {
            var message = data.ToJson();
            using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory()) + "\\" + DateTime.UtcNow.ToString("yyyyMMdd") + ".log", true))
            {
                sw.WriteLine(String.Format("[{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), message));
            }
        }
    }
}
