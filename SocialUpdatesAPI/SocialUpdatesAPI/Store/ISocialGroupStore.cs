using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface ISocialGroupStore
    {
        Task<SocialGroup> SaveAsync(SocialGroup data);
    }
}
