using System.Collections.Concurrent;
using System.Data;
using System.Reflection;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary = new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();
        private readonly IServiceProvider _serviceProvider;

        public MemoEventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void Initialize(List<Assembly> eventsAssemblyList)
        {
            foreach (var eventsAssembly in eventsAssemblyList)
            {
                foreach (var @eventType in eventsAssembly
                        .GetExportedTypes()
                        .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IEvent)))
                    )
                {
                    var handlerType = typeof(IIntegrationEventHandler<>).MakeGenericType(@eventType);
                    var handler = _serviceProvider.GetService(handlerType);

                    var eventTypeName = @eventType.FullName;
                    var typedHandler = (IIntegrationEventHandler<IEvent>)handler;

                    if (!_eventDictionary.ContainsKey(eventTypeName) && @eventType != null && typedHandler != null)
                    {
                        _eventDictionary.TryAdd(
                                eventTypeName,
                                new List<IIntegrationEventHandler<IEvent>> { typedHandler }
                            );
                    }

                    if (_eventDictionary.ContainsKey(eventTypeName))
                    {
                        var allHandlers = _eventDictionary[eventTypeName];
                        if (!allHandlers.Contains(handler) && handler != null)
                        {
                            _eventDictionary[eventTypeName].Add(typedHandler);
                        };
                    }
                }
            }
        }
    }
}
