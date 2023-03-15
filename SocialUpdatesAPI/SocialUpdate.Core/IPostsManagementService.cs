using Models;
using System.Net;

namespace Domain
{
    public interface IPostsManagementService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<IEnumerable<PlannedPost>> GetPostsAsync(int delay);
        Task SetIsPostedAsync(Guid id);
    }
}
