using PostsManagement.Models;
using PostsManagement.Store;
using SocialUpdatesAPI.Models;

namespace PostsManagement.Service
{
    public class PostsManagementService : IPostsManagementService
    {
        private IPostsManagementStore _postsManagementStore;

        public PostsManagementService(IPostsManagementStore postsManagementStore)
        {
            _postsManagementStore = postsManagementStore;
        }
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            return await _postsManagementStore.SaveAsync(data);
        }
    }
}
