using Domain;
using Eventer.Events.Events;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialUpdatesCotroller : ControllerBase
    {
        private readonly ISocialUpdatesSenderService _service;

        public SocialUpdatesCotroller(
            ISocialUpdatesSenderService service)
        {
            _service = service;
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> CreateSocialGroupAsync(PlannedPostCreatedEvent @event)
        {
            var plannedPostCreatedItem = new PlannedPostCreatedItem()
            {
                EventId = @event.EventId,
                EventTime = @event.EventTime,
                Payload = @event.Payload
            };

            await _service.SaveAsync(plannedPostCreatedItem);
            return Ok();

        }
    }
}
