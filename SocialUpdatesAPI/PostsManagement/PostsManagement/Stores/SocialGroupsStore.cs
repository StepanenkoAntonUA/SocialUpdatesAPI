using DataAccess;
using Models;

namespace PostsManagement.Stores
{
    public class SocialGroupsStore : ISocialGroupsStore
    {
        private SocialGroupStore _socialGroupStore;

        public SocialGroupsStore(SocialGroupStore socialGroupStore)
        {
            _socialGroupStore = socialGroupStore;
        }

        public async Task<IEnumerable<SocialGroupItem>> GetAllAsync()
        {
            return await _socialGroupStore.GetAllAsync();
        }

        public async Task<SocialGroupItem> GetByIdAsync(Guid id)
        {
            return await _socialGroupStore.GetByIdAsync(id);
        }
    }
}
