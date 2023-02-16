using SocialUpdateModule.Models;

namespace SocialUpdateModule.Services
{
    public interface IPostsManagementService
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
    }
}
