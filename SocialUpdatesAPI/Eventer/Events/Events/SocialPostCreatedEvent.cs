namespace Eventer.Events.Events
{
    public class SocialPostCreatedEvent : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}
