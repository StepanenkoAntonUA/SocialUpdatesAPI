using Models;

namespace DataAccess
{
    public interface IPostsStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
    }
}
