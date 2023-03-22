using Eventer.Events.DTO;
using Models;

namespace Domain
{
    public interface IPlannedPostService
    {
        Task<PlannedPostCreatedItem> HandleAsync(UploadEventRequestDto data);
    }
}
