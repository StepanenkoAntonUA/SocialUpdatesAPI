namespace Models
{
    public class PlannedPost
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public DateTime PublishTime { get; set; }
        public int RetryCount { get; set; }
        public bool IsPosted { get; set; }
    }
}
