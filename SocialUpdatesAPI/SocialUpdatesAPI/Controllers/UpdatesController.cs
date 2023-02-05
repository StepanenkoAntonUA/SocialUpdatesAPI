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
        public async Task<IEnumerable<SocialUpdate>> GetSocialUpdateItems()
        {
            return await _service.GetSocialUpdateItems();
        }

        [Route("update")]
        [HttpPost]
        public async Task<SocialUpdate> CreateUpdate(SocialUpdate postItem)
        {
            return await _service.SaveAsync(postItem);

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
        public async Task<ActionResult<SocialUpdate>> UpdateSocialUpdate(Guid id, SocialUpdate socialUpdate)
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
                await _service.UpdateAsync(id, socUpd);
            }
            catch (Exception) when (!SocialUpdateExists(id))
            {
                return NotFound();
            }

            return socUpd;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialUpdate>> DeleteUpdate(Guid id)
        {
            return await _service.DeleteAsync(id);
        }

        private bool SocialUpdateExists(Guid id)
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
