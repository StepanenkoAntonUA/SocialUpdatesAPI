using Eventer.Events.DTO;
using Models;

namespace DataAccess.Stores
{
    public interface IPlannedPostStore
    {
        Task<PlannedPostCreatedStatistic> UpdateStatisticAsync();
    }
}
