using PostsManagement.Models;

namespace PostsManagement.Store
{
    public interface ISocialGroupsStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<IEnumerable<PlannedPost>> GetPlannedPostItemsAsync();
        Task<PlannedPost> GetPlannedPostByIdAsync(Guid id);
    }
}
