using PostsManagement.Models;
using SocialUpdatesAPI.Models;

namespace PostsManagement.Store
{
    public interface IPostsManagementStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);

    }
}
