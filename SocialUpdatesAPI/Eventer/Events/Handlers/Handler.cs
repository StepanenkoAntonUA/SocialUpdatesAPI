using NuGet.Protocol;

namespace Eventer.Events.Handlers
{
    public class Handler : IIntegrationEventHandler<IEvent>
    {
        public async Task HandleAsync(IEvent value)
        {
            {
                var currentDir = Path.Combine(Directory.GetCurrentDirectory());
                var fileName = $"{currentDir}\\{value.EventTypeName}.txt";
                var message = value.ToJson();

                using (var sw = new StreamWriter(fileName, true))
                {
                    await sw.WriteLineAsync(message);
                }
            }
        }
    }
}
