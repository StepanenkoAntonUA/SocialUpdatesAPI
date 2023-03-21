using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Events.DTO
{
    public class UploadEventResponseDto
    {
        public string EventId { get; set; }
        public DateTime EventTime { get; set; }
        public string Payload { get; set; }
    }
}
