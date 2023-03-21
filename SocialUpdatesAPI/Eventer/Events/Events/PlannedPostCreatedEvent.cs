namespace Eventer.Events.Events
{
    public class PlannedPostCreatedEvent : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
        public string Payload { get; set; }

    }
}
