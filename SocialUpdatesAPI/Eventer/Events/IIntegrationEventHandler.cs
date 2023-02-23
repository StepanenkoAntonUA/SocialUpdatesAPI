namespace Eventer.Events
{
    public interface IIntegrationEventHandler<T>
    {
        Task HandleAsync(T value);
    }
}
