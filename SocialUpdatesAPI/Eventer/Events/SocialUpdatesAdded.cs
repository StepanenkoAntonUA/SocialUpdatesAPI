using Microsoft.AspNetCore.Mvc;

namespace Eventer.Events
{
    public class SocialUpdatesAdded : IEventAction
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

    }
}
