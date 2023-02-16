using SocialUpdateModule.Models;
using SocialUpdateModule.Stores;

namespace SocialUpdateModule.Services
{
    public class PostsManagementService : IPostsManagementService
    {
        private IPostsStore _postsStore;

        public PostsManagementService(IPostsStore postsManagementStore)
        {
            _postsStore = postsManagementStore;
        }
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            return await _postsStore.SaveAsync(data);
        }
    }
}
