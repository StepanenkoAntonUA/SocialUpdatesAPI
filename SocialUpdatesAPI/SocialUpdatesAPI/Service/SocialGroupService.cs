using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;

namespace SocialUpdatesAPI.Service
{
    public class SocialGroupService : ISocialGroupService
    {
        private ISocialGroupStore _socialPostStore;

        public SocialGroupService(ISocialGroupStore socialPostStore)
        {
            _socialPostStore = socialPostStore;
        }

        public Task<SocialGroup> SaveAsync(SocialGroup data)
        {
            return _socialPostStore.SaveAsync(data);
        }
    }
}
