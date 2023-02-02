﻿using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Store
{
    public interface IUpdateStore
    {
        Task SaveAsync(SocialUpdate data);
        Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id);
        Task UpdateAsync(SocialUpdate data);



    }
}
