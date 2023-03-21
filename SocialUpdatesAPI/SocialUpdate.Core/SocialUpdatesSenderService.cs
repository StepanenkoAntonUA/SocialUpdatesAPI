using DataAccess.Stores;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SocialUpdatesSenderService : ISocialUpdatesSenderService
    {
        private ISocialUpdatesStore _store;
    public SocialUpdatesSenderService(ISocialUpdatesStore store)
        {
            _store = store;
        }

        public async Task<PlannedPostCreatedItem> SaveAsync(PlannedPostCreatedItem data)
        {
            return await _store.SaveAsync(data);
        }
    }
}
