using PostsManagement.Models;
using SocialUpdatesAPI.Models;

namespace PostsManagement.Service
{
    public interface IPostsManagementService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
    }
}
