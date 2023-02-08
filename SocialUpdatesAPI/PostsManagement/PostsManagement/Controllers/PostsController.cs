using Microsoft.AspNetCore.Mvc;
using PostsManagement.Models;
using PostsManagement.Service;

namespace PostsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SocialGroupsController : ControllerBase
    {
        private readonly ISocialGroupsService _service;

        public SocialGroupsController(
            ISocialGroupsService service)
        {
            _service = service;
        }

        [Route("add")]
        [HttpPost]
        public async Task<PlannedPostDTO> CreateSocialPost(PlannedPost plannedPostItem)
        {
            var savedItem = await _service.SaveAsync(plannedPostItem);
            return PlannedPostAdapter.ToDTO(savedItem);
        }
    }
}
