using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public interface ISocialUpdatesDao
    {
        Task<PlannedPostCreatedItem> SaveAsync(PlannedPostCreatedItem data);
    }
}
