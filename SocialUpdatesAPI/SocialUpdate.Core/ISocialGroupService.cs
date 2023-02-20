using Models;

namespace Domain.Services
{
    public interface ISocialGroupService
    {
        Task<SocialGroupItem> SaveAsync(SocialGroupItem data);
        Task<IEnumerable<SocialGroupItem>> GetAllAsync();
        Task<SocialGroupItem> GetByIdAsync(Guid id);
    }
}
