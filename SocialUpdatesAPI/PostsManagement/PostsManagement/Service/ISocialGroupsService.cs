using PostsManagement.Models;

namespace PostsManagement.Service
{
    public interface ISocialGroupsService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
    }
}
