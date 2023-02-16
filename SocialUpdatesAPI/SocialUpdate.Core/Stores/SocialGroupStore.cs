using SocialUpdateModule.Models;
using System.Collections.Generic;

namespace SocialUpdateModule.Stores
{
    public class SocialGroupStore : ISocialGroupStore
    {
        private Dictionary<Guid, SocialGroupItem> _socialPostDictionary = new Dictionary<Guid, SocialGroupItem>();

        public async Task<SocialGroupItem> GetByIdAsync(Guid id)
        {
            {
                SocialGroupItem socialGroupItem = null;
                _socialPostDictionary.TryGetValue(id, out socialGroupItem);
                return socialGroupItem;
            }
        }

        public async Task<IEnumerable<SocialGroupItem>> GetAllAsync()
        {
            return _socialPostDictionary.Values.ToList();
        }

        public async Task<SocialGroupItem> SaveAsync(SocialGroupItem data)
        {
            data.Id = Guid.NewGuid();
            _socialPostDictionary.TryAdd(data.Id, data);
            return _socialPostDictionary[data.Id];
        }

    }
}
