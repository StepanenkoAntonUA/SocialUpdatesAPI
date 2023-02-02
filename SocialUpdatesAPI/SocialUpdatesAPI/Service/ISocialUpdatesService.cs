using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Service
{
    public interface ISocialUpdatesService
    {
        Task SaveAsync(SocialUpdate data);
        Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id);
        Task UpdateAsync(SocialUpdate data);

    }
}
