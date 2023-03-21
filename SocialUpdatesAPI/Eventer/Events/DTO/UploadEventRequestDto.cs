namespace Eventer.Events.DTO
{
    public class UploadEventRequestDto
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
        public string Payload { get; set; }
    }
}
