using Domain;
using Eventer.Events.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlannedPostController : ControllerBase
    {
        private readonly IPlannedPostService _service;

        public PlannedPostController(
            IPlannedPostService service)
        {
            _service = service;
        }

        //Добавил "заглушку" что бы при запуске проекта не было "Страница localhost не найдена"
        [HttpGet]
        public async Task<ActionResult> GetAllItems()
        {
            return Ok();
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> CreatePlannedPostAsync(UploadEventRequestDto requestDto)
        {
            await _service.HandleAsync(requestDto);
            return Ok();
        }
    }
}