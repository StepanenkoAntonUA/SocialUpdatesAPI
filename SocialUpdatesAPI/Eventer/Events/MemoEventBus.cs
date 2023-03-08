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

                    if (!_eventDictionary.ContainsKey(eventTypeName) && @eventType != null)
                    {
                        _eventDictionary.TryAdd(
                                eventTypeName,
                                new List<IIntegrationEventHandler<IEvent>> { typedHandler }
                            );
                    }

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
