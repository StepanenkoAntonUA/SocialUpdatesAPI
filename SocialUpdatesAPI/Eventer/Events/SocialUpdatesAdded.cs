using Microsoft.AspNetCore.Mvc;

namespace Eventer.Events
{
    public class SocialUpdatesAdded : IEventAction
    {
        private IEventBus _eventBus;
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

    }
}
