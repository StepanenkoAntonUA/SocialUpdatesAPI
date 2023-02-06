using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace SocialUpdatesAPI.Store.Caches
{
    public class UpdatesCache<TKey, TVlue> : ICache<TKey, TVlue>
    {
        private static Dictionary<TKey, TVlue> _dict = new Dictionary<TKey, TVlue>();

        public TVlue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task<TVlue> GetAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Set(TKey key, TVlue value)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(TKey key, TVlue value)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(TKey key, TVlue value, DateTimeOffset expiresAt)
        {
            throw new NotImplementedException();
        }
    }
}
