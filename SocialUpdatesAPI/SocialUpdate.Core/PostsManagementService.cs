using DataAccess;
using Eventer.Common;
using Eventer.Events;
using Eventer.Events.Events;
using Models;


namespace Domain
{
    public class PostsManagementService : IPostsManagementService
    {
        private IPostsStore _postsStore;
        private IEventBus _eventBus;
        private ISerializer _serializer;

        public PostsManagementService(IPostsStore postsStore
                , IEventBus eventBus
                , ISerializer serializer)
        {
            _postsStore = postsStore;
            _eventBus = eventBus;
            _serializer = serializer;
        }

        public async Task<PlannedPost?> SaveAsync(PlannedPost data)
        {
            data.Id = Guid.NewGuid();

            var newEvent = new SocialPostCreatedEvent
            {
                EventId = Guid.NewGuid().ToString()
                ,
                EventTime = DateTime.UtcNow
                ,
                Payload = _serializer.Serialize(data)
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
