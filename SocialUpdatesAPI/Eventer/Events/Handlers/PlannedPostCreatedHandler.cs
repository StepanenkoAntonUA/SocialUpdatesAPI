using Eventer.Events.DTO;
using Eventer.Events.Events;
using Eventer.Events.Services;

namespace Eventer.Events.Handlers
{
    public class PlannedPostCreatedHandler : IIntegrationEventHandler<PlannedPostCreatedEvent>
    {
        private ISocialUpdatesServiceClient _serviceClient;

        public PlannedPostCreatedHandler(IServiceProvider _, ISocialUpdatesServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task HandleAsync(PlannedPostCreatedEvent value)
        {
            var requestDto = new UploadEventRequestDto
            {
                PlannedPostEvent = value
            };
               await _serviceClient.CreatePlannedPostAsync(requestDto);
        }
    }
}
