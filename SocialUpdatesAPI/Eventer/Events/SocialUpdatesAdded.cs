using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Controllers;
using SocialUpdatesAPI.Models;

namespace Eventer.Events
{
    public class SocialUpdatesAdded : IEventAction
    {
        UpdatesController _updatesController;
        // экземпляр контроллера вообще внутри левой библиотеки????? Это суровое наружение правила отношений между слоями
        public SocialUpdatesAdded(UpdatesController updatesController)
        {
            _updatesController = updatesController;
        }

        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

        public async Task<ActionResult<SocialUpdateDTO>> AddSocialUpdatesItem(SocialUpdate socialUpdate)
        {
            // почему внутри IEvent какая-то логика вообще? Это должен быть просто контейнер для данных события
            var addedItem = await _updatesController.CreateUpdate(socialUpdate);
            return addedItem;
        }
    }
}
