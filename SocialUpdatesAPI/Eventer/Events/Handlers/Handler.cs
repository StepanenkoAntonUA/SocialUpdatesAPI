﻿using Eventer.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Eventer.Events.Handlers
{
    public class Handler : IIntegrationEventHandler<IEvent>
    {
        private ISerializer _serializer;

        public Handler(IServiceProvider _services)
        {
            _serializer = _services.GetService<ISerializer>();
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
