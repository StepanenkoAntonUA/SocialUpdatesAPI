using Eventer.Events.Events;

namespace Eventer.Events.Handlers
{
    public class SocialPostCreatedHandler : Handler, IIntegrationEventHandler<SocialPostCreatedEvent>
    {
        public SocialPostCreatedHandler(IServiceProvider _services) : base(_services)
        {
        }

        public async Task HandleAsync(SocialPostCreatedEvent value)
        {
            await base.HandleAsync(value);
        }
    }
}
