namespace PostsManagement.Models
{
    public class PlannedPost
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Post { get; set; }
    }
}
