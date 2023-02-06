using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private Dictionary<Guid, SocialUpdate> _socialUpdateDic = new Dictionary<Guid, SocialUpdate>();

        public async Task<SocialUpdate> SaveAsync(SocialUpdate data)
        {
            _socialUpdateDic.TryAdd(data.Id, data);
            return _socialUpdateDic[data.Id];
        }

        public async Task<SocialUpdate> UpdateAsync(Guid id, SocialUpdate data)
        {
            _socialUpdateDic[id] = data;
            return _socialUpdateDic[id];
        }

        public async Task<SocialUpdate> DeleteAsync(Guid id)
        {
            if (_socialUpdateDic.ContainsKey(id))
            {
                var deletedItem = new SocialUpdate();
                _socialUpdateDic.Remove(id, out deletedItem);
                return deletedItem;
            }
            else
                return null;
        }

        public async Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid id)
        {
            SocialUpdate socialUpdatedItem = null;

            _socialUpdateDic.TryGetValue(id, out socialUpdatedItem);

            return socialUpdatedItem;
        }

        public async Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems()
        {
            return _socialUpdateDic.Values.ToList();
        }
    }
}
