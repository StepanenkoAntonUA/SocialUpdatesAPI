using Eventer.Events.Services;
using Microsoft.Extensions.Logging;

namespace Eventer.Events.Service
{
    public class StatisticRequest : HttpRequestBase
    {
        const string BaseApiAddress = "https://localhost:7098/api/Statistic/add";
        public StatisticRequest(ILogger<HttpRequestBase> logger, IHttpClientFactory httpClientFactory)
            : base(logger, httpClientFactory)
        {
            SetBaseUri(BaseApiAddress);
        }
    }
}
