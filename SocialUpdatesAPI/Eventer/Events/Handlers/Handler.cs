using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events.Handlers
{
    public static class Handler
    {
        public static async Task HandleAsync(IEvent value)
        {
            {
                // переделать в наслеование с базовым классом
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
