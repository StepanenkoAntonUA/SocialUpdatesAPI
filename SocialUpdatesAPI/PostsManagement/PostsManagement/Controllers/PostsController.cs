using Microsoft.AspNetCore.Mvc;
using PostsManagement.Models;
using PostsManagement.Service;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Service;

namespace PostsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsManagementService _servicePM;
        private readonly ISocialGroupService _serviceSG;

        public PostsController(IPostsManagementService servicePM, ISocialGroupService serviceSG)
        {
            _servicePM = servicePM;
            _serviceSG = serviceSG;
        }

        [HttpGet]
        public async Task<IEnumerable<SocialGroup>> GetAllItems()
        {
            var updateItems = await _serviceSG.GetAllAsync();
            /*
            var socialUpdateDTOItems = updateItems
                                   // .Select(x => PlannedPostAdapter.ToDTO(x))
                                    .ToList();
            */
            return updateItems;
        }

        [HttpGet("{id}")]
        public async Task<SocialGroup> GetByIdAsync(Guid id)
        { 
            return await _serviceSG.GetByIdAsync(id);
        }

        [Route("insert")]
        [HttpPost]
        public async Task<PlannedPostDTO> CreatePlannedPost(PlannedPost plannedPostItem)
        {
            var savedItem = await _servicePM.SaveAsync(plannedPostItem);
            return PlannedPostAdapter.ToDTO(savedItem);
        }
    }
}
