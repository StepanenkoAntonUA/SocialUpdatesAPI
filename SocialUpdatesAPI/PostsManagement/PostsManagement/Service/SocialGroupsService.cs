using PostsManagement.Models;
using PostsManagement.Store;

namespace PostsManagement.Service
{
    public class SocialGroupsService : ISocialGroupsService
    {
        private ISocialGroupsStore _socialGroupsStore;

        public SocialGroupsService(ISocialGroupsStore socialGroupsStore)
        {
            _socialGroupsStore = socialGroupsStore;
        }

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            return await _socialGroupsStore.SaveAsync(data);
        }
    }
}
