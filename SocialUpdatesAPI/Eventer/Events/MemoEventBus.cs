using Eventer.Events.Events;
using Eventer.Events.Handlers;
using System.Collections.Concurrent;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary = new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();

        public MemoEventBus()
        {
            _eventDictionary = new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>(); ;
        }

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
             var _eventHandler = new Handler();
            if (!_eventDictionary.ContainsKey(eventTypeName))
            {
                _eventDictionary.TryAdd(eventTypeName, new List<IIntegrationEventHandler<IEvent>> { _eventHandler });
            }

            var allHandlers = _eventDictionary[eventTypeName];
            if (!allHandlers.Contains(_eventHandler))
            {
                _eventDictionary[eventTypeName].Add(_eventHandler);
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
