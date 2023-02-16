﻿using SocialUpdateModule.Models;
using SocialUpdateModule.Stores;

namespace SocialUpdateModule.Services
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
        private IUpdateStore _updateStore;

        public SocialUpdatesService(IUpdateStore updateStore)
        {
            _updateStore = updateStore;
        }

        public async Task<SocialUpdateItem> SaveAsync(SocialUpdateItem data)
        {
            return await _updateStore.SaveAsync(data);
        }

        public async Task<SocialUpdateItem> GetSocialUpdateByIdAsync(Guid id)
        {
            var socialUpdate = await _updateStore.GetSocialUpdateByIdAsync(id);
            return socialUpdate;
        }

        public async Task<SocialUpdateItem> UpdateAsync(Guid id, SocialUpdateItem data)
        {
            var socUpd = await GetSocialUpdateByIdAsync(id);
            socUpd.Description = data.Description;

            return await _updateStore.UpdateAsync(id, socUpd);
        }

        public Task<SocialUpdateItem> DeleteAsync(Guid id)
        {
            return _updateStore.DeleteAsync(id);
        }

        public async Task<IEnumerable<SocialUpdateItem>> GetSocialUpdateItems()
        {
            return await _updateStore.GetSocialUpdateItems();
        }
    }
}


