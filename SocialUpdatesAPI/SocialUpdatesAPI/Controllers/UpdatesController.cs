using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Service;
using System;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly SocialUpdatesService _service;

        public UpdatesController(
            SocialUpdatesService service
            )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialUpdates()
        {
           return NoContent();

        }

        [Route("update")]
        [HttpPost]
        public async Task CreateUpdate(SocialUpdate postItem)
        {
            await _service.SaveAsync(postItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialUpdateDTO>> GetSocialUpdate(Guid id)
        {
            var socialUpdate = await _service.GetSocialUpdateByIdAsync(id);
            if (socialUpdate == null)
            {
                return NotFound();
            }

            return ItemToDTO(socialUpdate);
        }
        
        [Route("SocialUpdate/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateTodoItem(Guid id, SocialUpdate socialUpdate)
        {
            if (id != socialUpdate.Id)
            {
                return BadRequest();
            }

            var socUpd = await _service.GetSocialUpdateByIdAsync(id);

            if (socUpd == null)
            {
                return NotFound();
            } 
            socUpd.Description = socialUpdate.Description;

            try
            {
                await _service.UpdateAsync(socUpd);
            }
            catch (Exception) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return Ok();
        }

        private bool TodoItemExists(Guid id)
        {
            var isExist = _service.GetSocialUpdateByIdAsync(id);
            return !(isExist == null);
        }

        private static SocialUpdateDTO ItemToDTO(SocialUpdate postItem) =>
            new SocialUpdateDTO
            {
                Id = postItem.Id,
                Description = postItem.Description,
                
            };
    }
}
