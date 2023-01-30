using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface IUpdateStore
    {
        Task SaveAsync(PostItem data);
    }
}
