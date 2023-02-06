namespace SocialUpdatesAPI.Models
{
    public class NullSocialUpdate : ISocialUpdate
    {
        string ISocialUpdate.Description { get => string.Empty; set { } }
        Guid ISocialUpdate.Id { get => Guid.Empty; set { } }
    }
}
