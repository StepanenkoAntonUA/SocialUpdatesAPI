using Eventer.Events.Services;
using Microsoft.Extensions.Logging;

namespace Eventer.Events.Service
{
    public class SocialUpdatesRequest : HttpRequestBase
    {
            const string BaseApiAddress = "https://localhost:7119/api/SocialUpdates/add";
            public SocialUpdatesRequest(ILogger<HttpRequestBase> logger, IHttpClientFactory httpClientFactory)
                : base(logger, httpClientFactory)
            {
                SetBaseUri(BaseApiAddress);
            }
    }
}
