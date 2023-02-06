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

        public async Task<SocialUpdate> UpdateAsync(Guid Id, SocialUpdate data)
        {
            _socialUpdateDic[Id] = data;
            return _socialUpdateDic[Id];
        }

        public async Task<SocialUpdate> DeleteAsync(Guid Id)
        {
            if (_socialUpdateDic.ContainsKey(Id))
            {
                var deletedItem = new SocialUpdate();
                _socialUpdateDic.Remove(Id, out deletedItem);
                return deletedItem;
            }
            else
                return null;
        }

        public async Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id)
        {
            SocialUpdate UpdatedItem = null;

            _socialUpdateDic.TryGetValue(Id, out UpdatedItem);

            return UpdatedItem;
        }

        public async Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems()
        {
            return _socialUpdateDic.Values.ToList();
        }
    }
}
