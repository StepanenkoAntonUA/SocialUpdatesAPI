using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface ISocialGroupStore
    {
        Task<SocialGroup> SaveAsync(SocialGroup data);
         Task<IEnumerable<SocialGroup>> GetAllAsync();
         Task<SocialGroup> GetByIdAsync(Guid id);
    }
}
