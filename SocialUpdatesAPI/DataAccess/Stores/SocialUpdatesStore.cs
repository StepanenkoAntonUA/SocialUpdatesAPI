using DataAccess.DAOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Stores
{
    
    public class SocialUpdatesStore : ISocialUpdatesStore
    {
        private ISocialUpdatesDao _dao;

        public SocialUpdatesStore(ISocialUpdatesDao dao)
        {
            _dao = dao;
        }

        public async Task<PlannedPostCreatedItem> SaveAsync(PlannedPostCreatedItem data)
        {
            return await _dao.SaveAsync(data);
        }
    }
}
