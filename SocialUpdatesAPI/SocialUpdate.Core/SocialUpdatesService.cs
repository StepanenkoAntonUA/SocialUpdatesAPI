using DataAccess.Stores;
using Models;

namespace Domain
{
    public class SocialUpdatesService : ISocialUpdatesService
    {

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



