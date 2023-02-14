namespace Eventer.Events
{
    public interface IEventBus
    {
        void Publish(IEvent @event);

        void Subscribe<T, TH>()
            where T : IEvent
            where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IEvent;
    }
}
