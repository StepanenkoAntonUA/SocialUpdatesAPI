using PostsManagement.Models;

namespace PostsManagement.Store
{
    public class SocialGroupsStore : ISocialGroupsStore
    {
        private Dictionary<Guid, PlannedPost> _socialGroupsDic = new Dictionary<Guid, PlannedPost>();

        public async Task<PlannedPost> GetPlannedPostByIdAsync(Guid id)
        {
            PlannedPost plannedPostItem = null;

            _socialGroupsDic.TryGetValue(id, out plannedPostItem);

            return plannedPostItem;
        }

        public async Task<IEnumerable<PlannedPost>> GetPlannedPostItemsAsync()
        {
            return _socialGroupsDic.Values.ToList();
        }

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            _socialGroupsDic.TryAdd(data.Id, data);
            return _socialGroupsDic[data.Id];
        }
    }
}
