using Models;

namespace DataAccess.Stores
{
    public interface ISocialUpdatesStore
    {
        Task<PlannedPostCreatedItem> SaveAsync(PlannedPostCreatedItem data);
    }
}
