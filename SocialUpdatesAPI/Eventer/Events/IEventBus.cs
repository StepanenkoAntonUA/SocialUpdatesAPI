namespace Eventer.Events
{
    public interface IEventBus
    {
        void Publish(IEvent @event);

        void Subscribe(string eventTypeName);

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IEvent;
    }
}
