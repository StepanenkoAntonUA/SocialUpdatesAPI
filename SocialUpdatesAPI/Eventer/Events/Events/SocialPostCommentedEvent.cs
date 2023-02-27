namespace Eventer.Events.Events
{
    public class SocialPostCommentedEvent : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}
