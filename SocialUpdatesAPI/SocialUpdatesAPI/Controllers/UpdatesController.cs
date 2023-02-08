using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Service;

namespace SocialUpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly ISocialUpdatesService _service;

        public UpdatesController(
            ISocialUpdatesService service
            )
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<SocialUpdateDTO>> GetSocialUpdateItems()
        {
            var updateItems = await _service.GetSocialUpdateItems();

            var socialUpdateDTOItems = updateItems
                                    .Select(x => SocialUpdateAdapter.ToDTO(x))
                                    .ToList();

            return socialUpdateDTOItems;
        }

        [Route("update")]
        [HttpPost]
        public async Task<SocialUpdateDTO> CreateUpdate(SocialUpdate postItem)
        {
            var savedItem = await _service.SaveAsync(postItem);
            return SocialUpdateAdapter.ToDTO(savedItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialUpdateDTO>> GetSocialUpdate(Guid id)
        {
            var socialUpdate = await _service.GetSocialUpdateByIdAsync(id);
            if (socialUpdate == null)
            {
                return NotFound();
            }

            return SocialUpdateAdapter.ToDTO(socialUpdate);
        }

        [Route("SocialUpdate/{id}")]
        [HttpPost]
        public async Task<ActionResult<SocialUpdateDTO>> UpdateSocialUpdate(Guid id, SocialUpdate socialUpdate)
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

            try
            {
                var updatedItem = await _service.UpdateAsync(id, socialUpdate);
                return SocialUpdateAdapter.ToDTO(updatedItem);
            }
            catch (Exception) when (!SocialUpdateExists(id))
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialUpdateDTO>> DeleteUpdate(Guid id)
        {
            var deletedItem = await _service.DeleteAsync(id);
            return (deletedItem != null) ? Ok(SocialUpdateAdapter.ToDTO(deletedItem)) : NotFound();
        }

        private bool SocialUpdateExists(Guid id)
        {
            var isExist = _service.GetSocialUpdateByIdAsync(id);
            return !(isExist == null);
        }
    }
}
