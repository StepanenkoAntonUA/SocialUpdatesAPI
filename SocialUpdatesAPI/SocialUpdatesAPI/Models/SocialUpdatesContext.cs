using Microsoft.AspNetCore.Mvc.Filters;
using SocialUpdatesAPI.Store;
using System.Diagnostics.CodeAnalysis;


namespace SocialUpdatesAPI.Models
{
    public class SocialUpdatesContext
    {
        /*
         * 1. заменить на IService. Создать ISocialUpdateService [1]
         * 2. IUpdateStore нельзя наследовать контексты от IStore [0]
         * 3. Не PostItem а SocialUpdate [0.5]
         * 4. В IUpdateStore сделать Dictionary, который хранит ключ-значение { GUID:SocialUpdate.Id, SocialUpdate:SocialUpdate } [3]
         * 5. Писать добавляемые SocialUpdate в Dictionary [2]
         * 6. Добавить GET by SocialUpdate.Id в контроллер [1.5]
         * 7. Добавить POST SocialUpdate для обновления SocialUpdate, в контроллер [2.5]
         * 8. Eventer добавить как проект этого Solution
         */
        IUpdateStore _updateStore;

        public SocialUpdatesContext(IUpdateStore updateStore)
        {
            _updateStore = updateStore;
        }

        public async Task SaveAsync(PostItem postItem)
        {
            await _updateStore.SaveAsync(postItem);
        }
    }
}



