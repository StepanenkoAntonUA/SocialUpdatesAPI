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
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            var @event = new SocialPostCreatedEvent { EventId = Guid.NewGuid().ToString()
                , EventTime = DateTime.UtcNow
                , Payload = JsonConvert.SerializeObject(data)
            };

            var plannedPost = await _postsStore.SaveAsync(data);
            if (plannedPost != null)
            {
                await _eventBus.PublishAsync(@event);
            }
            return plannedPost;
        }
    }
}
