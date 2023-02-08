using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Service;

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
        public async Task<SocialGroupDTO> CreateSocialPost(SocialGroup socialPostItem)
        {
            var savedItem = await _service.SaveAsync(socialPostItem);
            return SocialGroupAdapter.ToDTO(savedItem);
        }
    }
}
