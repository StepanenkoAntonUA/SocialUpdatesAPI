using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;


namespace Eventer.Events.Services
{
    public class HttpRequestBase
    {
        private readonly ILogger<HttpRequestBase> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _uri;

        public HttpRequestBase(ILogger<HttpRequestBase> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
        }

        protected HttpRequestBase SetBaseUri(string baseUri)
        {
            _uri = baseUri;
            return this;
        }

        public virtual async Task<TResult> ExecutePostAndCloseAsync<TRequestDto, TResult>(TRequestDto data)
            where TResult : class
        {
            if (_uri == null)
                throw new ArgumentNullException("The Uri must me provided first");

            var uri = new Uri(string.Concat(_uri));

            return await ExecutePostAndCloseAsync<TRequestDto, TResult>(uri, data);
        }

        public virtual async Task<TResult> ExecutePostAndCloseAsync<TRequestDto, TResult>(Uri requestUri, TRequestDto data)
            where TResult : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(nameof(HttpRequestBase)))
            {
                try
                {
                    var bodyJsonStr = ToJsonStr(data);
                    var result = await httpClient.PostAsync(
                            requestUri,
                            new StringContent(bodyJsonStr, Encoding.UTF8, "application/json")
                        );
                    var responseString = await result.Content.ReadAsStringAsync();

                    _logger.LogInformation($"HttpRequestBase response str: {responseString}");

                    var resultDto = FromJsonStr<TResult>(responseString);
                    return resultDto;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"HttpRequestBase request err: {ex.Message} {ex}");
                    return null;
                }
            }
        }

        public virtual async Task<TResult> ExecuteGetAndCloseAsync<TResult>(Uri requestUri)
            where TResult : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(nameof(HttpRequestBase)))
            {
                try
                {
                    var result = await httpClient.GetAsync(requestUri);
                    var responseString = await result.Content.ReadAsStringAsync();
                    _logger.LogInformation($"HttpRequestBase response str: {responseString}");

                    var resultDto = FromJsonStr<TResult>(responseString);
                    return resultDto;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"HttpRequestBase request err: {ex.Message} {ex}");
                    return null;
                }
            }
        }


        private string ToJsonStr<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        private T FromJsonStr<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

    }
}
