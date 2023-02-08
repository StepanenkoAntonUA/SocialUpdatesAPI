using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Controllers;
using SocialUpdatesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events
{
    public class SocialUpdatesDeleted : IEventAction
    {
        UpdatesController _updatesController;

        public SocialUpdatesDeleted(UpdatesController updatesController)
        {
            _updatesController = updatesController;
        }

        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

        public async Task<ActionResult<SocialUpdateDTO>> DeleteSocialUpdatesItem(Guid id)
        {
            var deletedItem = await _updatesController.DeleteUpdate(id);
            return deletedItem;
        }
    }
}
