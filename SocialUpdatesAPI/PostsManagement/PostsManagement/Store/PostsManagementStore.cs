using PostsManagement.Models;

namespace PostsManagement.Store
{
    public class PostsManagementStore : IPostsManagementStore
    {
        private Dictionary<Guid, PlannedPost> _plannedDic = new Dictionary<Guid, PlannedPost>();

        public async Task<PlannedPost> GetPlannedPostByIdAsync(Guid id)
        {
            PlannedPost plannedPostItem = null;

            _plannedDic.TryGetValue(id, out plannedPostItem);

            return plannedPostItem;
        }

        public async Task<IEnumerable<PlannedPost>> GetPlannedPostItemsAsync()
        {
            return _plannedDic.Values.ToList();
        }

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            _plannedDic.TryAdd(data.Id, data);
            return _plannedDic[data.Id];
        }
    }
}
