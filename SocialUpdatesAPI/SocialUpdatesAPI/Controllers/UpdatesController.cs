using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly SocialUpdatesContext _context;
        private readonly IUpdateStore _updateStore;

        public UpdatesController(
            SocialUpdatesContext context
            ,IUpdateStore updateStore
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

        // GET: api/SocialUpdateItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostItemDTO>> GetSocialUpdateItem(int id)
        {
            var socialUpdateItem = await _context.SocialUpdateItems.FindAsync(id);

            if (socialUpdateItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(socialUpdateItem);
        }

        // PUT: api/SocialUpdateItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialUpdateItem(int id, PostItemDTO postItemDTO)
        {
            if (id != postItemDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(postItemDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialUpdateItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SocialUpdateItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostItemDTO>> PostSocialUpdateItem(PostItemDTO postItemDTO)
        {
            var postItem = new PostItem
            {
                Title = postItemDTO.Title,
                Description = postItemDTO.Description,
                Photo = postItemDTO.Photo
            };

            _context.SocialUpdateItems.Add(postItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSocialUpdateItem),
                new { id = postItem.Id },
                ItemToDTO(postItem));
        }
       
        [HttpPost("{create}")]
        public async Task CreateUpdate(PostItem postItem)
        {
            await _updateStore.SaveAsync(postItem);
        }
       


        // DELETE: api/SocialUpdateItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialUpdateItem(int id)
        {
            var socialUpdateItem = await _context.SocialUpdateItems.FindAsync(id);
            if (socialUpdateItem == null)
            {
                return NotFound();
            }

            _context.SocialUpdateItems.Remove(socialUpdateItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocialUpdateItemExists(int id)
        {
            return _context.SocialUpdateItems.Any(e => e.Id == id);
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
