using DataAccess.Stores;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
