using DataAccess;
using Eventer.Events;
using Eventer.Events.Events;
using Models;
using Newtonsoft.Json;


namespace Domain
{
    public class PostsManagementService : IPostsManagementService
    {
        private IPostsStore _postsStore;
        private IEventBus _eventBus;

        public PostsManagementService(IPostsStore postsStore, IEventBus eventBus)
        {
            _postsStore = postsStore;
            _eventBus = eventBus;
        }

        public async Task<PlannedPost?> SaveAsync(PlannedPost data)
        {
            data.Id = Guid.NewGuid();

            var newEvent = new SocialPostCreatedEvent { 
                EventId = Guid.NewGuid().ToString()
                , EventTime = DateTime.UtcNow
                // JsonConvert - это NewtonsoftJson. Это одна из самых медленных библиотек на net Core. Переделать сериализацию на System.Text JsonSerializer
                // и добавить интерфейс ISerializer, чтобы вся сериализация, по всему проекту (и в текстовые файлы тоже) была внедрена (IoC) через этот ISerializer (ISerializer.Serialize(...))
                , Payload = JsonConvert.SerializeObject(data)
            };

            var plannedPost = await _postsStore.SaveAsync(data);
            if (plannedPost != null)
            {
                await _eventBus.PublishAsync(newEvent);
            }

            return plannedPost;
        }
    }
}
