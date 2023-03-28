using Eventer.Events.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IStatisticService
    {
            Task<PlannedPostCreatedStatistic> UpdateStatisticAsync();
    }
}
