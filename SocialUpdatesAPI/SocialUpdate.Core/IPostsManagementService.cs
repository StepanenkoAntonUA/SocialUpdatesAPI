using Models;
using System.Net;

namespace Domain
{
    public interface IPostsManagementService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<List<PlannedPost>> GetPostsAsync(int delay);
    }
}
