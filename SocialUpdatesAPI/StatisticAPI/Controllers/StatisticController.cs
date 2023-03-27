using Domain;
using Microsoft.AspNetCore.Mvc;
using StatisticAPI.DTO;

namespace StatisticAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IPlannedPostService _service;

        public StatisticController(
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
        public async Task<ActionResult> IncreaseCounterAsync(PlannedPostCreatedEventDTO plannedPostDTO)
        {
            return Ok();
        }

    }
}
