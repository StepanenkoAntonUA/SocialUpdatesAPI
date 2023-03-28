using Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Stores
{
    public class PlannedPostStore : IPlannedPostStore
    {
        public async Task<PlannedPostCreatedStatistic> UpdateStatisticAsync()
        {
            string filePath = "statistic.txt";
            PlannedPostCreatedStatistic statistic;

            try
            {
                string jsonString = await File.ReadAllTextAsync(filePath);
                statistic = JsonSerializer.Deserialize<PlannedPostCreatedStatistic>(jsonString);
            }
            catch
            {
                statistic = new PlannedPostCreatedStatistic { ItemsCount = 0 };
            }

            statistic.ItemsCount = statistic.ItemsCount + 1;

            string newJsonString = JsonSerializer.Serialize(statistic);
            await File.WriteAllTextAsync(filePath, newJsonString);

            return statistic;
        }
    }
}
