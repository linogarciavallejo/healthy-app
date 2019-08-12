using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using healthy_api.Models;

namespace healthy_api.DataProvider
{
    public interface IHealthyEventsDataProvider
    {
        Task<IEnumerable<HealthyEvent>> GetEventsLog(int UserId);
    }
}
