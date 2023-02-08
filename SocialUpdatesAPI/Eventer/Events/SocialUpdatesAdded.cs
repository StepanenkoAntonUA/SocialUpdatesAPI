using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Controllers;
using SocialUpdatesAPI.Models;

namespace Eventer.Events
{
    public class SocialUpdatesAdded : IEventAction
    {
        UpdatesController _updatesController;
        public SocialUpdatesAdded(UpdatesController updatesController)
        {
            _updatesController = updatesController;
        }

        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

        public async Task<ActionResult<SocialUpdateDTO>> AddSocialUpdatesItem(SocialUpdate socialUpdate)
        {
            var addedItem = await _updatesController.CreateUpdate(socialUpdate);
            return addedItem;
        }
    }
}
