using DataAccess.DAOs;
using Models;

namespace DataAccess.Stores
{
    public class PostsStore : IPostsStore
    {
        private IPostsDao _dao;

        public PostsStore(IPostsDao dao) 
        {
            _dao = dao;
        }


        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            await _dao.SaveAsync(data);
            return data;
        }

        public async Task<IEnumerable<PlannedPost>> GetPostsAsync(int delay)
        { 
            return await _dao.GetPostsAsync(delay);
        }

        public async Task SetIsPostedAsync(Guid id)
        {
            await _dao.SetIsPostedAsync(id);
        }

    }
}
