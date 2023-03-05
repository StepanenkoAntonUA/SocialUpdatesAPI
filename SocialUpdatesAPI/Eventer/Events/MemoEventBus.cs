using Eventer.Events.Events;
using Eventer.Events.Handlers;
using System.Collections.Concurrent;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary = new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();

        public async Task PublishAsync(IEvent @event)
        {
            var eventTypeName = @event.EventTypeName;
            if (_eventDictionary.ContainsKey(eventTypeName))
            {
                foreach (var handler in _eventDictionary[eventTypeName])
                {
                    await handler.HandleAsync(@event);
                }
            }
        }

        public void Subscribe(string eventTypeName)
        {
            IIntegrationEventHandler<IEvent> eventHandler = null;

            if (typeof(SocialPostCommentedEvent).FullName.Equals(eventTypeName))
                eventHandler = new SocialPostCommentedHandler();

            if (typeof(SocialPostCreatedEvent).FullName.Equals(eventTypeName))
                eventHandler = new SocialPostCreatedHandler();

            if (typeof(SocialPostSentEvent).FullName.Equals(eventTypeName))
                eventHandler = new SocialPostSentHandler();

            if (!_eventDictionary.ContainsKey(eventTypeName) && eventHandler != null)
            {
                _eventDictionary.TryAdd(eventTypeName, new List<IIntegrationEventHandler<IEvent>> { eventHandler });
            }

            var allHandlers = _eventDictionary[eventTypeName];
            if (!allHandlers.Contains(eventHandler) && eventHandler != null)
            {
                _eventDictionary[eventTypeName].Add(eventHandler);
            };
        }

        public void Unsubscribe<T, TH>()
            where T : IEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
