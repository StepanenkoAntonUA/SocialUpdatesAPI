using Models;

namespace Domain
{
    public interface IStatisticService
    {
        Task<PlannedPostCreatedStatistic> UpdateStatisticAsync();
    }
}
