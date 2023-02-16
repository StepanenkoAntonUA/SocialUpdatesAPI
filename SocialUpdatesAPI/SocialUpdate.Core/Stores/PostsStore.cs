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

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            data.Id = Guid.NewGuid();
            _plannedDictionary.TryAdd(data.Id, data);
            return _plannedDictionary[data.Id];
        }

    }
}
