namespace SocialUpdatesAPI.Models
{
    public class SocialGroup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Post { get; set; }
    }
}
