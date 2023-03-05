using Eventer.Common;
using System.Text.Unicode;

namespace Eventer.Events.Handlers
{
    public class Handler : IIntegrationEventHandler<IEvent>
    {
        private readonly ISerializer _serializer;

        public Handler()
        {
            _serializer = new Serializer();
        }

        public async Task HandleAsync(IEvent value)
        {
            {
                var currentDir = Path.Combine(Directory.GetCurrentDirectory());
                var fileName = $"{currentDir}\\{value.EventTypeName}.txt";
                var message = _serializer.Serialize(value);

                using (var sw = new StreamWriter(fileName, true))
                {
                    await sw.WriteLineAsync(message);
                }
            }
        }
    }
}
