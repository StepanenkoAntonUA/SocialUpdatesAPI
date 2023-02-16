using SocialUpdateModule.Models;

namespace PostsManagement.Stores
{
    public interface ISocialGroupsStore
    {
        Task<IEnumerable<SocialGroupItem>> GetAllAsync();
        Task<SocialGroupItem> GetByIdAsync(Guid id);
    }
}
