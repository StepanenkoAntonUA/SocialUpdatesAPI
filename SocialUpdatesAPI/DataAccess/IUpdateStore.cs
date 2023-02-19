using Models;

namespace DataAccess
{
    public interface IUpdateStore
    {
        Task<SocialUpdateItem> SaveAsync(SocialUpdateItem data);
        Task<SocialUpdateItem> GetSocialUpdateByIdAsync(Guid id);
        Task<SocialUpdateItem> UpdateAsync(Guid id, SocialUpdateItem data);
        Task<SocialUpdateItem> DeleteAsync(Guid id);
        Task<IEnumerable<SocialUpdateItem>> GetSocialUpdateItems();
    }
}
