using DataAccess;
using Domain.Services;
using Models;

namespace Domain
{
    public class SocialGroupService : ISocialGroupService
    {
        private ISocialGroupStore _store;

        public SocialGroupService(ISocialGroupStore socialPostStore)
        {
            _store = socialPostStore;
        }

        public Task<IEnumerable<SocialGroupItem>> GetAllAsync()
        {
            return _store.GetAllAsync();
        }

        public Task<SocialGroupItem> GetByIdAsync(Guid id)
        {
            return _store.GetByIdAsync(id);
        }

        public Task<SocialGroupItem> SaveAsync(SocialGroupItem data)
        {
            return _store.SaveAsync(data);
        }
    }
}
