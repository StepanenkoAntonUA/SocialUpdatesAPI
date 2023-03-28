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

            // retry - if exception. Повторять попытку 5 раз, через каждые 3 секунды, если предыдущая не выполнилась
            // dead-letter. Операцию кладем в отдельный Store. И поторяем через N - часов.

            await _serviceClient.CreatePlannedPostAsync(requestDto);
            await _statisticServiceClient.UpdateStatisticAsync(requestDto);
        }
    }
}
