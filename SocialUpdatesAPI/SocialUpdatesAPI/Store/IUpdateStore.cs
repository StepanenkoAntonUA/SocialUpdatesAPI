using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface IUpdateStore
    {
        Task<SocialUpdate> SaveAsync(SocialUpdate data);
        Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id);
        Task<SocialUpdate> UpdateAsync(Guid Id, SocialUpdate data);
        Task<SocialUpdate> DeleteAsync(Guid Id);
        Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems();



    }
}
