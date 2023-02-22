using Microsoft.AspNetCore.Mvc;

namespace Eventer.Events
{
    public class SocialUpdatesAdded : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}
