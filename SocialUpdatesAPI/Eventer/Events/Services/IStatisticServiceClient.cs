using Eventer.Events.DTO;

namespace Eventer.Events.Services
{
    public interface IStatisticServiceClient
    {
        Task<SocialUpdatesRequestResult> UpdateStatisticAsync(UploadEventRequestDto requestData);
    }
}
