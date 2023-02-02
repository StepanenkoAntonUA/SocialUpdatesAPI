using SocialUpdatesAPI.Models;
using NuGet.Protocol;
using System.Globalization;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private Dictionary<Guid, SocialUpdate> _socialUpdateDic =  new Dictionary<Guid, SocialUpdate>();

        public async Task SaveAsync(SocialUpdate data)
        {
            _socialUpdateDic.Add(data.Id, data);
        }

        public async Task UpdateAsync(SocialUpdate data)
        {
            _socialUpdateDic[data.Id] = data;
        }

        public async Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id)
        {
            try
            {
                var socialUpdate = _socialUpdateDic[Id];
                return socialUpdate;
            }
            catch (Exception) 
            {
                return null;
            }
        }
    }
}
