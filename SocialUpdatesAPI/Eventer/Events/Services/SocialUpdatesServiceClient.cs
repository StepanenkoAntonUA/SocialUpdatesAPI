using Eventer.Events.DTO;
using Eventer.Events.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Eventer.Events.Services
{
    public class SocialUpdatesServiceClient : ISocialUpdatesServiceClient
    {
        private readonly IServiceProvider _serviceProvider;

        public SocialUpdatesServiceClient(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<SocialUpdatesRequestResultDto> UploadRequestBodyAsync(UploadEventRequestDto requestData)
        {
            var request = NewRequest();
            var res = await request.ExecutePostAndCloseAsync<UploadEventRequestDto, UploadEventResponseDto>(requestData);

            var response = new UploadEventResponseDto
            {
                EventId = res.EventId,
                EventTime = res.EventTime,
                Payload = res.Payload
            };

            var statusResponse = new SocialUpdatesRequestResultDto // Result - не DTO. Просто Result
            {
                ResponseDto = response
            };

            return statusResponse;
        }

        private SocialUpdatesRequest NewRequest()
        {
            var logger = _serviceProvider.GetService<ILogger<SocialUpdatesRequest>>();
            var clientFactory = _serviceProvider.GetService<IHttpClientFactory>();

            return new SocialUpdatesRequest(logger, clientFactory);
        }

    }
}
