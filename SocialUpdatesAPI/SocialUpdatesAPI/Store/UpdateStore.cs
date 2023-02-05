using SocialUpdatesAPI.Models;
using NuGet.Protocol;
using System.Globalization;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialUpdatesAPI.Store
{
    public class UpdateStore : IUpdateStore
    {
        private Dictionary<Guid, SocialUpdate> _socialUpdateDic =  new Dictionary<Guid, SocialUpdate>();

        public async Task<SocialUpdate> SaveAsync(SocialUpdate data)
        {
            _socialUpdateDic.TryAdd(data.Id, data);
            return _socialUpdateDic[data.Id];
        }

        public async Task<SocialUpdate> UpdateAsync(Guid Id, SocialUpdate data)
        {
            _socialUpdateDic[Id] = data;
            return _socialUpdateDic[Id];
        }

        public async Task<SocialUpdate> DeleteAsync(Guid Id)
        {
            var deletedItem = new SocialUpdate();

            if (GetSocialUpdateByIdAsync(Id) != null)
                _socialUpdateDic.Remove(Id, out deletedItem);
               
            return deletedItem;
            

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
