using DataAccess.Stores;
using Eventer.Events.DTO;
using Models;
using System.Text.Json;


namespace Domain
{
    public class PlannedPostService : IPlannedPostService
    {
        private ISocialUpdatesStore _store;
        public PlannedPostService(ISocialUpdatesStore store)
        {
            _store = store;
        }

        public async Task<PlannedPostCreatedItem> HandleAsync(UploadEventRequestDto requestDto)
        {
            var plannedPostCreatedItem = new PlannedPostCreatedItem
            {
                EventId = Guid.NewGuid().ToString(),
                EventTime = DateTime.UtcNow,
                Payload = JsonSerializer.Serialize(requestDto)
            };
            return await _store.SaveAsync(plannedPostCreatedItem);
        }
    }
}
