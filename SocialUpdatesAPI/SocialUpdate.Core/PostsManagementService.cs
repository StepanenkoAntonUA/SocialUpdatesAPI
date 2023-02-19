using DataAccess;
using Models;

namespace Domain
{
    public class PostsManagementService : IPostsManagementService
    {
        private IPostsStore _postsStore;

        public PostsManagementService(IPostsStore postsStore)
        {
            _postsStore = postsStore;
        }
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            return await _postsStore.SaveAsync(data);
        }
    }
}
