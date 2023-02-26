using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace Eventer.Events
{
    public class MemoEventBus : IEventBus
    {
        private ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>> _eventDictionary =
            new ConcurrentDictionary<string, List<IIntegrationEventHandler<IEvent>>>();
       
        public MemoEventBus()
        {
        }

        public void Publish(IEvent @event)
        {
            var eventTypeName = @event.EventTypeName;
            if (_eventDictionary.ContainsKey(eventTypeName))
            {
                foreach (var handler in _eventDictionary[eventTypeName])
                {
                    handler.HandleAsync(@event);
                    /*
                     * из-за того, что async метод вызывается как НЕ async - приложение работать не будет. Надо вызывать через await
                     * Есть 2 решения:
                     * 1. Publish должен быть тоже PublistAsync (учитывая все правила работы  async-await)
                     * 2. HandleAsync должен быть не async. Но этот вариант сильно хуже.
                     */

                }
            }
        }

        public void Subscribe(string eventTypeName) 
        {
            var _eventHandler = Activator.CreateInstance(typeof(IntegrationEventHandler)) as IIntegrationEventHandler<IEvent>;
            
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
