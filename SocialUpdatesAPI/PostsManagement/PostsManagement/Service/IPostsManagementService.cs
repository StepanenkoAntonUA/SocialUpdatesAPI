using PostsManagement.Models;

namespace PostsManagement.Service
{
    public interface IPostsManagementService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<IEnumerable<PlannedPost>> GetPlannedPostItemsAsync();
    }
}
