using Eventer.Events.DTO;
using Eventer.Events.Events;
using Eventer.Events.Services;

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
            var requestDto = new UploadEventRequestDto
            {
                PlannedPostEvent = value
            };
               await _serviceClient.CreatePlannedPostAsync(requestDto);
         
        }
    }
}
