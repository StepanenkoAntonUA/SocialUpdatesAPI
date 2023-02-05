using Microsoft.AspNetCore.Mvc.Filters;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;
using System.Diagnostics.CodeAnalysis;


namespace SocialUpdatesAPI.Service
{
    public class SocialUpdatesService : ISocialUpdatesService
    {

        /*
         + 1. заменить на IService. Создать ISocialUpdateService [1]
         + 2. IUpdateStore нельзя наследовать контексты от IStore [0]
         + 3. Не PostItem а SocialUpdate [0.5]
         + 4. В IUpdateStore сделать Dictionary, который хранит ключ-значение { GUID:SocialUpdate.Id, SocialUpdate:SocialUpdate } [3]
         + 5. Писать добавляемые SocialUpdate в Dictionary [2]
         + 6. Добавить GET by SocialUpdate.Id в контроллер [1.5]
         + 7. Добавить POST SocialUpdate для обновления SocialUpdate, в контроллер [2.5]
         + 8. Eventer добавить как проект этого Solution
         */
        IUpdateStore _updateStore;

        public SocialUpdatesService(IUpdateStore updateStore)
        {
            _updateStore = updateStore;
        }

        public async Task<SocialUpdate> SaveAsync(SocialUpdate data)
        {
            return await _updateStore.SaveAsync(data);

        }

        public async Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid Id)
        {
           var socialUpdate  = await _updateStore.GetSocialUpdateByIdAsync(Id);
           return socialUpdate;
        }

        public async Task<SocialUpdate> UpdateAsync(Guid Id, SocialUpdate data)
        {
            return await _updateStore.UpdateAsync(Id, data);
        }

        public Task<SocialUpdate> DeleteAsync(Guid Id)
        {
            return _updateStore.DeleteAsync(Id);
        }

        public async Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems()
        {
            return await _updateStore.GetSocialUpdateItems();
        }
    }
}



