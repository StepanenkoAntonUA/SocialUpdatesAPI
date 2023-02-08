using Microsoft.AspNetCore.Mvc;
using PostsManagement.Models;
using PostsManagement.Service;

namespace PostsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsManagementService _service;

        public PostsController(
            IPostsManagementService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<PlannedPostDTO>> GetSocialUpdateItems()
        {
            var updateItems = await _service.GetPlannedPostItemsAsync();

            var socialUpdateDTOItems = updateItems
                                    .Select(x => PlannedPostAdapter.ToDTO(x))
                                    .ToList();

            return socialUpdateDTOItems;
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
