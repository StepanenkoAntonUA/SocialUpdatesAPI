using Eventer.Events.DTO;
using Eventer.Events.Events;
using Eventer.Events.Services;
using Microsoft.Extensions.Logging;

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
            var requestData = new UploadEventRequestDto()
            {
                EventId = value.EventId,
                EventTime = value.EventTime,
                Payload = value.Payload
            };

            // нет смысла копировать событие 1 к 1. RequestDto должен содержать в себе внутри весь Event. Не являться копией Event. См. Event Grid Event как пример

            // открытых методов UploadXXX не должно быть в Service Client. Все доступные методы в Ыукмшсу Сдшуте должны иметь такие же именования, как и API endpoints самого удаленного сервиса.
            await _serviceClient.UploadRequestBodyAsync(requestData);
        }
    }
}
