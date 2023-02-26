using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Adapters;
using SocialUpdatesAPI.DTO;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SocialGroupsController : ControllerBase
    {
        private readonly ISocialGroupService _service;

        public SocialGroupsController(
            ISocialGroupService service)
        {
            _service = service;
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> CreateSocialGroupAsync(SocialGroupItemDTO socialGroupDTO)
        {

            var socialGroup = SocialGroupAdapter.FromDTO(socialGroupDTO);
            await _service.SaveAsync(socialGroup);
            return Ok();
        }
    }
}
