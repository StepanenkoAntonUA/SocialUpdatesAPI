using Models;

namespace DataAccess
{
    public class UpdateStore : IUpdateStore
    {
        private Dictionary<Guid, SocialUpdateItem> _socialUpdateDictionary = new Dictionary<Guid, SocialUpdateItem>();

        public async Task<SocialUpdateItem> SaveAsync(SocialUpdateItem data)
        {
            data.Id = Guid.NewGuid();
            _socialUpdateDictionary.TryAdd(data.Id, data);
            return _socialUpdateDictionary[data.Id];
        }

        public async Task<SocialUpdateItem> UpdateAsync(Guid id, SocialUpdateItem data)
        {
            _socialUpdateDictionary[id] = data;
            return _socialUpdateDictionary[id];
        }

        public async Task<SocialUpdateItem> DeleteAsync(Guid id)
        {
            if (_socialUpdateDictionary.ContainsKey(id))
            {
                var deletedItem = new SocialUpdateItem();
                _socialUpdateDictionary.Remove(id, out deletedItem);
                return deletedItem;
            }
            else
                return null;
        }

        public async Task<SocialUpdateItem> GetSocialUpdateByIdAsync(Guid id)
        {
            SocialUpdateItem socialUpdatedItem = null;

            _socialUpdateDictionary.TryGetValue(id, out socialUpdatedItem);

            return socialUpdatedItem;
        }

        public async Task<IEnumerable<SocialUpdateItem>> GetSocialUpdateItems()
        {
            return _socialUpdateDictionary.Values.ToList();
        }
    }
}
