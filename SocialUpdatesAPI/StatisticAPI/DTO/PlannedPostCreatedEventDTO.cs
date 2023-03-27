namespace StatisticAPI.DTO
{
    public class PlannedPostCreatedEventDTO
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
        public string Payload { get; set; }
    }
}
