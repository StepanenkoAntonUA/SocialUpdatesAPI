using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Models;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly SocialUpdatesContext _context;

        public UpdatesController(
            SocialUpdatesContext context
            )
        {
            _context = context;
        }

        [HttpGet]
        public async Task GetSocialUpdates()
        {
            var postItem = new PostItem();
            await _context.SaveAsync(postItem);

        }

        [Route("update")]
        [HttpPost]
        public async Task CreateUpdate(PostItem postItem)
        {
            await _context.SaveAsync(postItem);
        }

        private static PostItemDTO ItemToDTO(PostItem postItem) =>
            new PostItemDTO
            {
                Id = postItem.Id,
                Title = postItem.Title,
                Description = postItem.Description,
                Photo = postItem.Photo
            };

    }
}
