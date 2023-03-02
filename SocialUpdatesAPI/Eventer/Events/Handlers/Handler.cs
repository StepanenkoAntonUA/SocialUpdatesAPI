using Newtonsoft.Json;

namespace Eventer.Events.Handlers
{
    public class Handler : IIntegrationEventHandler<IEvent>
    {
        public async Task HandleAsync(IEvent value)
        {
            {
                var currentDir = Path.Combine(Directory.GetCurrentDirectory());
                var fileName = $"{currentDir}\\{value.EventTypeName}.txt";
                var message = JsonConvert.SerializeObject(value);


                using (var sw = new StreamWriter(fileName, true))
                {
                    await sw.WriteLineAsync(message);
                }
            }
        }
    }
}
