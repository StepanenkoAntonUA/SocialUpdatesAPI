using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Service
{
    public interface ISocialGroupService
    {
        Task<SocialGroup> SaveAsync(SocialGroup data);
        Task<IEnumerable<SocialGroup>> GetAllAsync();
        Task<SocialGroup> GetByIdAsync(Guid id);
    }
}
