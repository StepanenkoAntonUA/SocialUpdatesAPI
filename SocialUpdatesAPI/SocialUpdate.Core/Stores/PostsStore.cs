using SocialUpdateModule.Models;

namespace SocialUpdateModule.Stores
{
    public class PostsStore : IPostsStore
    {
        private ISocialGroupStore _store;
        private Dictionary<Guid, PlannedPost> _plannedDictionary = new Dictionary<Guid, PlannedPost>();
        public PostsStore(ISocialGroupStore store)
        {
            _store = store;
        }

        // обьявление переменных в одном месте должно быть. Dictinary почему-о тут а _store выше конструктора
        
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            // хорошо что, не _plannedDick. Не надо укорачивать слова.
            data.Id = Guid.NewGuid();
            _plannedDictionary.TryAdd(data.Id, data);
            return _plannedDictionary[data.Id];
        }

    }
}
