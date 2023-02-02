namespace SocialUpdatesAPI.Models
{
    public class SocialUpdate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
    }
}
