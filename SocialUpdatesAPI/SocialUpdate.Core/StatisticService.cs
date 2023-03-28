using DataAccess.Stores;
using Models;

namespace Domain
{
    public class StatisticService : IStatisticService
    {
        private IPlannedPostStore _plannedPostStore;

        public StatisticService(IPlannedPostStore plannedPostStore)
        {
            _plannedPostStore = plannedPostStore;
        }

        public Task<PlannedPostCreatedStatistic> UpdateStatisticAsync()
        {
            return _plannedPostStore.UpdateStatisticAsync();
        }
    }
}
