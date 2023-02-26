namespace Eventer.Events
{
    public interface IEvent
    {
        public string EventId { get; set; }
        public static DateTime EventTime { get; set; }
        public string EventTypeName
        {
            get
            {
                return GetType().FullName;
            }
        }
    }
}
