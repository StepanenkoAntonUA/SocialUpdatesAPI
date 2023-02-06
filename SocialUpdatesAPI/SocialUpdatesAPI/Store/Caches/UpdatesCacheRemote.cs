namespace SocialUpdatesAPI.Store.Caches
{
    public class UpdatesCacheRemote<TKey, TVlue> : ICache<TKey, TVlue>
    {
        public TVlue Get(TKey key)
        {
            // ws -> Redis 
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
