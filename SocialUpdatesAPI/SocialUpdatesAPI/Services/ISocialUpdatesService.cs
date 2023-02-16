using SocialUpdateModule.Models;

namespace SocialUpdateModule.Services
{
    public interface ISocialUpdatesService
    {
        Task<SocialUpdateItem> SaveAsync(SocialUpdateItem data);
        Task<SocialUpdateItem> GetSocialUpdateByIdAsync(Guid id);
        Task<SocialUpdateItem> UpdateAsync(Guid id, SocialUpdateItem data);
        Task<SocialUpdateItem> DeleteAsync(Guid id);
        Task<IEnumerable<SocialUpdateItem>> GetSocialUpdateItems();

    }
}
