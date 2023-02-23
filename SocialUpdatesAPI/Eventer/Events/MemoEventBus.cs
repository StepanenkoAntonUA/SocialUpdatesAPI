using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary =
            new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();
        private IIntegrationEventHandler<IEvent> _eventHandler;
/*
        public MemoEventBus(ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> eventDictionary, IIntegrationEventHandler<IEvent> handler)
        {
            _eventDictionary = eventDictionary;
            _handler = handler;
        }
*/
        public MemoEventBus()
        {
            _eventHandler = Activator.CreateInstance(typeof(IntegrationEventHandler)) as IIntegrationEventHandler<IEvent>;
        }

        public void Publish(IEvent @event)
        {
            var eventTypeName = @event.EventTypeName;// typeof().FullName
            if (_eventDictionary.ContainsKey(eventTypeName))
            {
                foreach (var handler in _eventDictionary[eventTypeName])
                {
                    handler.HandleAsync(@event);
                }
            }
        }

        public void Subscribe(string eventTypeName) //, IIntegrationEventHandler<IEvent> eventHandler
        {
           // var eventHandler = Activator.CreateInstance(typeof(IntegrationEventHandler)) as IIntegrationEventHandler<IEvent>;
            if (!_eventDictionary.ContainsKey(eventTypeName))
            {
                _eventDictionary.TryAdd(eventTypeName, new List<IIntegrationEventHandler<IEvent>> { _eventHandler });
                return;
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
