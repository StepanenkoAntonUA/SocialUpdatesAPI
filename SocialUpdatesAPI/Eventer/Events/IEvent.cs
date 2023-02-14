using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events
{
    public interface IEvent 
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
    }
}
