namespace SocialUpdatesAPI.Models
{
    public class SocialUpdate : ISocialUpdate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
    }
}
