using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface IUpdateStore
    {
        Task<SocialUpdate> SaveAsync(SocialUpdate data);
        Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid id);
        Task<SocialUpdate> UpdateAsync(Guid id, SocialUpdate data);
        Task<SocialUpdate> DeleteAsync(Guid id);
        Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems();



    }
}
