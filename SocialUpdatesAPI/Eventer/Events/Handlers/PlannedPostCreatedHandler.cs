using Eventer.Events.DTO;
using Eventer.Events.Events;
using Eventer.Events.Services;
using Microsoft.Extensions.Logging;

namespace Eventer.Events.Handlers
{
    public class PlannedPostCreatedHandler : Handler, IIntegrationEventHandler<PlannedPostCreatedEvent>
    {
        private ISocialUpdatesServiceClient _serviceClient;
        public PlannedPostCreatedHandler(IServiceProvider _services, ISocialUpdatesServiceClient serviceClient) : base(_services)
        {
            _serviceClient = serviceClient;
        }

        public async Task HandleAsync(PlannedPostCreatedEvent value)
        {
            var requestData = new UploadEventRequestDto()
            {
                EventId = value.EventId,
                EventTime = value.EventTime,
                Payload = value.Payload
            };

            await _serviceClient.UploadRequestBodyAsync(requestData);
        }
    }
}
