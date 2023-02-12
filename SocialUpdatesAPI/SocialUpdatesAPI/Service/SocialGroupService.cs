using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;

namespace SocialUpdatesAPI.Service
{
    public class SocialGroupService : ISocialGroupService
    {
        private ISocialGroupStore _store;

        public SocialGroupService(ISocialGroupStore socialPostStore)
        {
            _store = socialPostStore;
        }

        public Task<IEnumerable<SocialGroup>> GetAllAsync()
        {
            return _store.GetAllAsync();
        }

        public Task<SocialGroup> GetByIdAsync(Guid id)
        {
            return _store.GetByIdAsync(id);
        }

        public Task<SocialGroup> SaveAsync(SocialGroup data)
        {
            return _store.SaveAsync(data);
        }
    }
}
