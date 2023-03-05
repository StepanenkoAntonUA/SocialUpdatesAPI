using System.Text.Encodings.Web;
using System.Text.Json;

namespace Eventer.Common
{
    public class Serializer : ISerializer
    {
        public string Serialize(object data)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            return JsonSerializer.Serialize(data, options);
        }
    }
}
