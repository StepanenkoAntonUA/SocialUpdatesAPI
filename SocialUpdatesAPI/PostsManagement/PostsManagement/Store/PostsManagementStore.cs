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

        private Dictionary<Guid, PlannedPost> _plannedDic = new Dictionary<Guid, PlannedPost>();

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            _plannedDic.TryAdd(data.Id, data);
            return _plannedDic[data.Id];
        }
       
    }
}
