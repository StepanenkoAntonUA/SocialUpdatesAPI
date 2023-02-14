using Microsoft.AspNetCore.Mvc;
using SocialUpdatesAPI.Controllers;
using SocialUpdatesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events
{
    public class SocialUpdatesDeleted : IEvent
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }

        public SocialUpdatesDeleted(string eventId, DateTime eventTime)
        {
            EventId = eventId;
            EventTime = eventTime;
        }
    }
}
