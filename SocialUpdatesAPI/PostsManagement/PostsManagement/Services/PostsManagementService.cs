using SocialUpdateModule.Models;
using SocialUpdateModule.Stores;

namespace SocialUpdateModule.Services
{
    public class PostsManagementService : IPostsManagementService
    {
        // Скорей не PostsManagementStore а PostsStore. Т.к. это "хранилище постов" а не "хранилище менеджеров постов". Звучит "грубо и обидно"...
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
