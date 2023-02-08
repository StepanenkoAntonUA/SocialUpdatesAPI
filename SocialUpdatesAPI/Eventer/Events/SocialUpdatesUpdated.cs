using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Controllers;
using SocialUpdatesAPI.Models;

namespace Eventer.Events
{
    public class SocialUpdatesUpdated : IEventAction
    {
        UpdatesController _updatesController;

        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

        public SocialUpdatesUpdated(UpdatesController updatesController)
        {
            _updatesController = updatesController;
        }

        public async Task<ActionResult<SocialUpdateDTO>> UpdateSocialUpdatesItem(Guid id, SocialUpdate socialUpdate)
        {
            var updatedItem = await _updatesController.UpdateSocialUpdate(id, socialUpdate);
            return updatedItem;
        }
    }
}
