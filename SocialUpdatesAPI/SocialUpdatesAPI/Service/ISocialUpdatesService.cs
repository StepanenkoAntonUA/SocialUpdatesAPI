using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Service
{
    public interface ISocialUpdatesService
    {
        Task<SocialUpdate> SaveAsync(SocialUpdate data);
        Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id);
        Task<SocialUpdate> UpdateAsync(Guid Id, SocialUpdate data);
        Task<SocialUpdate> DeleteAsync(Guid Id);

    }
}
