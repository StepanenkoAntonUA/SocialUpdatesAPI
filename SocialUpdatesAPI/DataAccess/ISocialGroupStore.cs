using Models;

namespace DataAccess
{
    public interface ISocialGroupStore
    {
        Task<SocialGroupItem> SaveAsync(SocialGroupItem data);
        Task<IEnumerable<SocialGroupItem>> GetAllAsync();
        Task<SocialGroupItem> GetByIdAsync(Guid id);
    }
}
