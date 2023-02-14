namespace Eventer.Events
{
    public class SocialUpdatesDeleted : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}
