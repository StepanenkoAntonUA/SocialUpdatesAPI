﻿using Eventer.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events
{
    public class IntegrationEventHandler : IIntegrationEventHandler<IEvent>
    {
        public async Task HandleAsync(IEvent value)
        {
            await Handler.HandleAsync(value);
        }
    }
}
