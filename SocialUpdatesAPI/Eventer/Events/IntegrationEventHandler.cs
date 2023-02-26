using Eventer.Events.Handlers;

namespace Eventer.Events
{
    public class IntegrationEventHandler : Handler
    {
        public async Task HandleAsync(IEvent value)
        {
            await base.HandleAsync(value);
        }
    }
}
