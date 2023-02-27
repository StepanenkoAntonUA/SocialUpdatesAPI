using Eventer.Events.Events;

namespace Eventer.Events.Handlers
{
    public class SocialPostCreatedHandler : Handler, IIntegrationEventHandler<SocialPostCreatedEvent>
    {
        public async Task HandleAsync(SocialPostCreatedEvent value)
        {
            await base.HandleAsync(value);
        }
    }
}
