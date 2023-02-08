using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Service
{
    public interface ISocialGroupService
    {
        Task<SocialGroup> SaveAsync(SocialGroup data);
    }
}
