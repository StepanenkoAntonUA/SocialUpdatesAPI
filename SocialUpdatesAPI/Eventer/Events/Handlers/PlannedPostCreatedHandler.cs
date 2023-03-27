using Eventer.Events.DTO;
using Eventer.Events.Events;
using Eventer.Events.Services;

namespace Eventer.Events.Handlers
{
    public class PlannedPostCreatedHandler : Handler, IIntegrationEventHandler<PlannedPostCreatedEvent>
    {
        private ISocialUpdatesServiceClient _serviceClient;
        private IStatisticServiceClient _statisticServiceClient;

        public PlannedPostCreatedHandler(IServiceProvider _services
            , ISocialUpdatesServiceClient serviceClient
            , IStatisticServiceClient statisticServiceClient) : base(_services)
        {
            _serviceClient = serviceClient;
            _statisticServiceClient = statisticServiceClient;
        }

        public async Task HandleAsync(PlannedPostCreatedEvent value)
        {
            var requestDto = new UploadEventRequestDto
            {
                PlannedPostEvent = value
            };
            await _serviceClient.CreatePlannedPostAsync(requestDto);
            await _statisticServiceClient.UpdateStatisticAsync(requestDto);
        }
    }
}
