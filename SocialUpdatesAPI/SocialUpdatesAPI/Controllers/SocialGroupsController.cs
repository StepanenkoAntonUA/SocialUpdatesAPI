using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Service;

namespace SocialUpdatesAPI.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    
    public class SocialGroupsController : ControllerBase
    {
        private readonly ISocialGroupService _service;

        public SocialGroupsController(
            ISocialGroupService service)
        {
            _service = service;
        }

        [Route("add")]
        [HttpPost]
        public async Task<SocialGroupDTO> CreateSocialPost(SocialGroup socialPostItem)
        {
            /*
             * 1. CreateSocialPost сам action async но в наименовании async не добавлен. Добавить.
             * 2. (SocialGroup socialPostItem) - принимать DTO
             * 3. Принимать похоже то надо SocialPostDto а не SocialGroup
             * 4. возвращать только статус Created в ответе, без body
             * 
             * ГЛАВНОЕ - судя по самой задаче - здесь должно быть добавление именно SocialGroup а не SocialPost. Потому похоже что наименование метода не правильное
             */
            var savedItem = await _service.SaveAsync(socialPostItem);
            return SocialGroupAdapter.ToDTO(savedItem);
        }
    }
}
