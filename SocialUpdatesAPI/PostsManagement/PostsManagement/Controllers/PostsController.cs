using Microsoft.AspNetCore.Mvc;
using PostsManagement.Adapters;
using PostsManagement.DTO;
using SocialUpdateModule.Models;
using SocialUpdateModule.Services;

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
            // вот эти все PM, SG, HF, AA, BB, CC, JGDHJGHDJD и подобное - это полный бред выдуманный начинающими разработчиками. В реальности это все потом сильно усложняет восприятие кода. Писать нормально, полными словами. Чтобы потом никто не пытался догадаться на 100500 строке кода, что такое абревиатура AA, Ab и подобное.
        }

        /*
         * Задание было: Добавить контроллер Posts в PostsManagement с Insert нового PlannedPost точно так же в Store с Dictionary
         * Вопрос:  зачем здесь GetAll, GetById?
         * НЕ надо делать лишнего!
         * 
         * И не надо контроллер Posts  использовать для CRUD SocialGroup. Этот контролер только для Posts
         */
        /*
        [HttpGet]
        public async Task<IEnumerable<SocialGroupItem>> GetAllItems()
        {
            var updateItems = await _serviceSocialGroup.GetAllAsync();
            //var socialUpdateDTOItems = updateItems
                                   // .Select(x => PlannedPostAdapter.ToDTO(x))
                                    .ToList();
            
            //return updateItems;
        }

        [HttpGet("{id}")]
        public async Task<SocialGroupItem> GetByIdAsync(Guid id)
        {
            return await _serviceSocialGroup.GetByIdAsync(id);
        }
        */


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
