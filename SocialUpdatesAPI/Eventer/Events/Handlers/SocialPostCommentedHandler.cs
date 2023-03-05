using Eventer.Events.Events;

namespace Eventer.Events.Handlers
{
    public class SocialPostCommentedHandler : Handler, IIntegrationEventHandler<SocialPostCommentedEvent>
    {
        public SocialPostCommentedHandler(IServiceProvider _services) : base(_services)
        {
        }

        public async Task HandleAsync(SocialPostCommentedEvent value)
        {
            await base.HandleAsync(value);
        }
    }
}
