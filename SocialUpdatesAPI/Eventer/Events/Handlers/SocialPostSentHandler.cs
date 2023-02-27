using Eventer.Events.Events;

namespace Eventer.Events.Handlers
{
    public class SocialPostSentHandler : Handler, IIntegrationEventHandler<SocialPostSentEvent>
    {
        public async Task HandleAsync(SocialPostSentEvent value)
        {
            await base.HandleAsync(value);
        }
    }
}
