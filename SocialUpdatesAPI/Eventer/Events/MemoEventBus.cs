using System.Collections.Concurrent;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private static ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> eventDictionary =
            new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();
        
        public void Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string eventTypeName, IIntegrationEventHandler<IEvent> eventHandler)
        {
            if (!eventDictionary.ContainsKey(eventTypeName))
            {
                eventDictionary.TryAdd(eventTypeName, new List<IIntegrationEventHandler<IEvent>> { eventHandler });
                return;
            }

            var allHandlers = eventDictionary[eventTypeName];
            if (!allHandlers.Contains(eventHandler)) 
            {
                eventDictionary[eventTypeName].Add(eventHandler);
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
