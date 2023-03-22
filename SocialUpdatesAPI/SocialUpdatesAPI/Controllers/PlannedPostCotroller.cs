using Domain;
using Eventer.Events.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // не совсем понятно почему контроллер называется SocialUpdatesCotroller, если его обязанность "принимать новые события" ИЛИ "принимать новые события об PlannetPost Item". Переименовать
    public class PlannedPostCotroller : ControllerBase
    {
        private readonly IPlannedPostService _service;

        public PlannedPostCotroller(
            IPlannedPostService service)
        {
            _service = service;
        }

        [Route("add")]
        [HttpPost]
        // ++ переименовать метод API. При чем SocialGroup к событию PlannedPostCreatedEvent вообще?
        // принимать должен тот тип, который отправляется в PlannedPostCreatedHandler. А выходит, что в Handler какие-то преобразования в RequestDto и т.п. а сюда приходит все же Event. Приходить должен Event Wrapper вроде Event Grid Event - как пример
        public async Task<ActionResult> CreatePlannedPostAsync(UploadEventRequestDto requestDto)
        {
            // тоже, зачем точная копия события. Передавать Wrapper 

            // метод лучше именовать не Save а Handle. Потом после доработки, если помимо сохранения будет еще что - по всему коду переименовывать на SaveИЕщеЧтото ?
            await _service.HandleAsync(requestDto);
            return Ok();
        }
    }
}
