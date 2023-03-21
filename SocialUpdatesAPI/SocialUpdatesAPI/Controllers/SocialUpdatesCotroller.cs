using Domain;
using Eventer.Events.Events;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // не совсем понятно почему контроллер называется SocialUpdatesCotroller, если его обязанность "принимать новые события" ИЛИ "принимать новые события об PlannetPost Item". Переименовать
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
        // переименовать метод API. При чем SocialGroup к событию PlannedPostCreatedEvent вообще?
        // принимать должен тот тип, который отправляется в PlannedPostCreatedHandler. А выходит, что в Handler какие-то преобразования в RequestDto и т.п. а сюда приходит все же Event. Приходить должен Event Wrapper вроде Event Grid Event - как пример
        public async Task<ActionResult> CreateSocialGroupAsync(PlannedPostCreatedEvent @event)
        {
            var plannedPostCreatedItem = new PlannedPostCreatedItem()
            {
                EventId = @event.EventId,
                EventTime = @event.EventTime,
                Payload = @event.Payload
            }; // тоже, зачем точная копия события. Передавать Wrapper 

            // метод лучше именовать не Save а Handle. Потом после доработки, если помимо сохранения будет еще что - по всему коду переименовывать на SaveИЕщеЧтото ?
            await _service.SaveAsync(plannedPostCreatedItem);
            return Ok();
        }
    }
}
