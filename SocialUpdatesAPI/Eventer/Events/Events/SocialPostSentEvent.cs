namespace Eventer.Events.Events
{
    public class SocialPostSentEvent : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}