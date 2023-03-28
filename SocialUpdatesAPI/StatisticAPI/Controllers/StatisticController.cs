using Domain;
using Microsoft.AspNetCore.Mvc;
using Models;
using StatisticAPI.DTO;

namespace StatisticAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _service;

        public StatisticController(
            IStatisticService service)
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
        public async Task<ActionResult<PlannedPostCreatedStatistic>> IncreaseCounterAsync(PlannedPostCreatedEventDTO plannedPostDTO)
        {
            return await _service.UpdateStatisticAsync();
        }

    }
}
