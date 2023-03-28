using Eventer.Events.DTO;
using Eventer.Events.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events.Services
{
    public class StatisticServiceClient : IStatisticServiceClient
    {
        private readonly IServiceProvider _serviceProvider;

        public StatisticServiceClient(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<SocialUpdatesRequestResult> UpdateStatisticAsync(UploadEventRequestDto requestData)
        {
            var request = NewRequest();
            var res = await request.ExecutePostAndCloseAsync<UploadEventRequestDto, UploadEventResponseDto>(requestData);

            var response = new UploadEventResponseDto
            {
                EventId = res.EventId,
                EventTime = res.EventTime,
                Payload = res.Payload
            };

            var statusResponse = new SocialUpdatesRequestResult
            {
                ResponseDto = response
            };

            return statusResponse;
        }

        private StatisticRequest NewRequest()
        {
            var logger = _serviceProvider.GetService<ILogger<StatisticRequest>>();
            var clientFactory = _serviceProvider.GetService<IHttpClientFactory>();

            return new StatisticRequest(logger, clientFactory);
        }


    }
}
