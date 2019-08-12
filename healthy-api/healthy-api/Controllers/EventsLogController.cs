using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using healthy_api.DataProvider;
using healthy_api.Models;
using Microsoft.AspNetCore.Cors;

namespace healthy_api.Controllers
{
    [Route("api/[controller]")]
    public class EventsLogController : Controller
    {
        private IHealthyEventsDataProvider healthyEventsDataProvider;

        public EventsLogController(IHealthyEventsDataProvider healthyEventsDataProvider)
        {
            this.healthyEventsDataProvider = healthyEventsDataProvider;
        }


        [HttpGet("{UserId}")]
        public async Task<IEnumerable<HealthyEvent>> GetEventsLog(int UserId)
        {
            return await this.healthyEventsDataProvider.GetEventsLog(UserId);
        }

    }
}
