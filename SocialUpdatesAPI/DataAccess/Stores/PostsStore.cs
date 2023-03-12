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
    }
}
