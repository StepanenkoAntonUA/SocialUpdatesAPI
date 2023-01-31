using SocialUpdatesAPI.Models;
using NuGet.Protocol;
using System.Globalization;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {

        public UpdateStore()
        {
        }

        public async Task SaveAsync(PostItem data)
        {
            var message = String.Format("[{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), data.ToJson());
            var fileName = Path.Combine(Directory.GetCurrentDirectory()) + "\\" + DateTime.UtcNow.ToString("yyyyMMdd") + ".log";
            
            using (StreamWriter sw = new StreamWriter(fileName, true ))
            {
                await sw.WriteLineAsync(message);
            }
            
        }
    }
}
