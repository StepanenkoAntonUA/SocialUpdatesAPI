﻿using Eventer.Events.DTO;

namespace Eventer.Events.Services
{
    public interface ISocialUpdatesServiceClient
    {
        Task<SocialUpdatesRequestResultDto> UploadRequestBodyAsync(UploadEventRequestDto requestData);
    }
}
