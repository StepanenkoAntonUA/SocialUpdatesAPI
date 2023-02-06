using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;


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

        public async Task<SocialUpdate> GetSocialUpdateByIdAsync(Guid id)
        {
            var socialUpdate = await _updateStore.GetSocialUpdateByIdAsync(id);
            return socialUpdate;
        }

        public async Task<SocialUpdate> UpdateAsync(Guid id, SocialUpdate data)
        {
            var socUpd = await GetSocialUpdateByIdAsync(id);
            socUpd.Description = data.Description;

            return await _updateStore.UpdateAsync(id, socUpd);
        }

        public Task<SocialUpdate> DeleteAsync(Guid id)
        {
            return _updateStore.DeleteAsync(id);
        }

        public async Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems()
        {
            return await _updateStore.GetSocialUpdateItems();
        }
    }
}



