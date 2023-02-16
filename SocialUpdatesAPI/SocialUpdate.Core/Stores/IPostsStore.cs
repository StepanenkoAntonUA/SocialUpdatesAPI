using SocialUpdateModule.Models;

namespace SocialUpdateModule.Stores
{
    public interface IPostsStore
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);

    }
}
