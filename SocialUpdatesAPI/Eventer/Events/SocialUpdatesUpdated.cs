namespace Eventer.Events
{
    public class SocialUpdatesUpdated : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

    }
}
