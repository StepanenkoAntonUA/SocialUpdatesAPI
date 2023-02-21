namespace Eventer.Events
{
    public interface IEventBus
    {
        void Publish(IEvent @event);

        void Subscribe(string eventTypeName, IIntegrationEventHandler<IEvent> eventHandler);

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IEvent;
    }
}
