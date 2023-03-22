using Eventer.Events.DTO;

namespace Eventer.Events.Services
{
    public interface ISocialUpdatesServiceClient
    {
        Task<SocialUpdatesRequestResult> CreatePlannedPostAsync(UploadEventRequestDto requestData);
    }
}
