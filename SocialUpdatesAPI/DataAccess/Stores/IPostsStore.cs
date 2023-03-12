using Models;

namespace DataAccess.Stores
{
    public interface IPostsStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        
    }
}
