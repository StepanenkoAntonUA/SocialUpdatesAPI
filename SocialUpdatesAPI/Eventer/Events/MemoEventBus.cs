using System.Collections.Concurrent;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> eventDictionary =
            new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();

        public void Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>(IEvent @event, IIntegrationEventHandler<IEvent> eventHandler)
            where T : IEvent
            where TH : IIntegrationEventHandler<T>
        {
            if (eventDictionary.ContainsKey(@event.EventTypeName))
            {
                var allValues = eventDictionary[@event.EventTypeName];
                var checkValues = allValues.Contains(eventHandler);
                if (!checkValues) eventDictionary[@event.EventTypeName].Add(eventHandler);
            }
            else
            {
                eventDictionary.TryAdd(@event.EventTypeName, new List<IIntegrationEventHandler<IEvent>> { eventHandler });
            }
        }

        public void Unsubscribe<T, TH>()
            where T : IEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
