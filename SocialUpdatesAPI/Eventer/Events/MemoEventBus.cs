using Eventer.Events.Events;
using Eventer.Events.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary = new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();

        public MemoEventBus()
        {
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

        public void Subscribe(Type eventType, Type handlerType)
        {
            if (typeof(IIntegrationEventHandler<IEvent>).IsAssignableFrom(handlerType))
                throw new ArgumentException($"Received handler not implements {nameof(IIntegrationEventHandler<IEvent>)}");

            var eventHandler = (IIntegrationEventHandler<IEvent>)Activator.CreateInstance(handlerType.AssemblyQualifiedName, handlerType.FullName);

            var eventTypeName = eventType.FullName;

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
