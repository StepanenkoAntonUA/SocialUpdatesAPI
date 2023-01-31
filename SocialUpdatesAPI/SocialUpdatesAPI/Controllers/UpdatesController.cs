using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/SocialUpdateItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostItemDTO>>> GetSocialUpdates()
        {
            return await _context.SocialUpdateItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
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
                Description= postItem.Description,
                Photo = postItem.Photo
            };

    }
}
