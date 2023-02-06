namespace SocialUpdatesAPI.Store.Caches
{
    public interface ICache<in TKey, TValue>
    {
        Task<TValue> GetAsync(TKey key);
        TValue Get(TKey key);
        void Set(TKey key, TValue value);
        Task SetAsync(TKey key, TValue value);
        Task SetAsync(TKey key, TValue value, DateTimeOffset expiresAt);
        void Remove(TKey key);
        Task RemoveAsync(TKey key);
    }
}
