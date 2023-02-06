namespace Eventer.Events
{
    public interface IEventBus
    {
        void Publish(IEventAction @event);

        void Subscribe<T, TH>()
            where T : IEventAction
            where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IEventAction;
    }
}
