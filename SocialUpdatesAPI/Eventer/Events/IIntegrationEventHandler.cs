namespace Eventer.Events
{
    public interface IIntegrationEventHandler<T>
    {
       public Task HandleAsync(T value);
    }
}
