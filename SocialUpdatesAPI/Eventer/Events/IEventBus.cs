namespace Eventer.Events
{
    public interface IEventBus
    {
        Task PublishAsync(IEvent @event);

        void Subscribe(string eventTypeName);

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IEvent;
    }
}
