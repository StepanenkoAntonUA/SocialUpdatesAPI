using PostsManagement.Models;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;

namespace PostsManagement.Store
{
    public class PostsManagementStore : IPostsManagementStore
    {
        private ISocialGroupStore  _store;

        public PostsManagementStore(ISocialGroupStore store)
        {
            _store = store;
        }

        // обьявление переменных в одном месте должно быть. Dictinary почему-о тут а _store выше конструктора
        private Dictionary<Guid, PlannedPost> _plannedDic = new Dictionary<Guid, PlannedPost>();

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            // хорошо что, не _plannedDick. Не надо укорачивать слова.
            _plannedDic.TryAdd(data.Id, data);
            return _plannedDic[data.Id];
        }
       
    }
}
