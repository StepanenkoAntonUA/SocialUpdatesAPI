using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events.Handlers
{
    public class SocialPostCommentedHandler : IIntegrationEventHandler<IEvent>
    {
        public async Task HandleAsync(IEvent value)
        {
           await Handler.HandleAsync(value);
        }
    }
}
