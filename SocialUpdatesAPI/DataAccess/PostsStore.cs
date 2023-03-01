using Models;

namespace DataAccess
{
    public class PostsStore : IPostsStore
    {
        private ISocialGroupStore _store;
        private Dictionary<Guid, PlannedPost> _plannedDictionary = new Dictionary<Guid, PlannedPost>();
        public PostsStore(ISocialGroupStore store)
        {
            _store = store;
        }
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            _plannedDictionary.TryAdd(data.Id, data);
            return _plannedDictionary[data.Id];
        }

    }
}
