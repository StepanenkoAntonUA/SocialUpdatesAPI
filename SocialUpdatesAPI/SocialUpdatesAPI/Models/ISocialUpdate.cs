namespace SocialUpdatesAPI.Models
{
    public interface ISocialUpdate
    {
        string Description { get; set; }
        Guid Id { get; set; }
    }
}