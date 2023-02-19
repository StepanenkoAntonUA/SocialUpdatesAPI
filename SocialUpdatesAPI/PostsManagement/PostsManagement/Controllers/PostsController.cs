using Domain;
using Microsoft.AspNetCore.Mvc;
using Models;
using PostsManagement.Adapters;
using PostsManagement.DTO;

namespace PostsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsManagementService _postsManagmentService;

        public PostsController(IPostsManagementService postsManagmentService)
        {
            _postsManagmentService = postsManagmentService;
        }

        //Добавил "заглушку" что бы при запуске проекта не было "Страница localhost не найдена"
        [HttpGet]
        public async Task<ActionResult> GetAllItems()
        {
            return Ok();
        }

        [Route("insert")]
        [HttpPost]
        public async Task<PlannedPostDTO> CreatePlannedPost(PlannedPost plannedPostItem)
        {
            var savedItem = await _postsManagmentService.SaveAsync(plannedPostItem);
            return PlannedPostAdapter.ToDTO(savedItem);
        }
    }
}
