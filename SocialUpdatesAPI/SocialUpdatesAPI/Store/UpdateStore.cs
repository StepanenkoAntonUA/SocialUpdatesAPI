using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store.Caches;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private ICache<Guid, SocialUpdate> _socialUpdateDic;

        public UpdateStore(ICache<Guid, SocialUpdate> _socialUpdateDic)
        { }

        public async Task<SocialUpdate> SaveAsync(SocialUpdate data)
        {
            _socialUpdateDic.TryAdd(data.Id, data);
            return _socialUpdateDic[data.Id];
        }

        public async Task<SocialUpdate> UpdateAsync(Guid id, SocialUpdate data)
        {
            _socialUpdateDic[id] = data;
            return _socialUpdateDic[id];

            // сервис отправки постов по таймауту

            // в текущий сервис добавить API добавления канала
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

        public async Task<ISocialUpdate> GetSocialUpdateByIdAsync(Guid id)
        {

            /* 
             * preload cache на старте
             * смотрим в кэш (Dictionary)
                * если нет - забираем из БД Lazy Loading
                * если есть - возвращаем сразу из кэша
             * если в БД есть - добавляем в кэш
             * тогда возвращаем
             * 
             * Решение проблемы памяти + CPU -> Remote Caching = Redis (Memcached, SQL, Elastic Search)
            */

            /*
             * 1. лезем в БД
             * 1.1. А что если БД тормозит
             * 1.1.1. Сделаю Redis 
             * 2. возвращем
             * 
             */

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
