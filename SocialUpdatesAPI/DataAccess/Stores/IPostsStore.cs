using Models;

namespace DataAccess.Stores
{
    public interface IPostsStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<IEnumerable<PlannedPost>> GetPostsAsync(int delay);
        Task SetIsPostedAsync(Guid id);
    }
}
