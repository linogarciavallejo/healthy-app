using System;
using System.Collections.Generic;

namespace healthy_api.Models
{
    public partial class EventType
    {
        public EventType()
        {
            HealthyEvents = new HashSet<HealthyEvent>();
        }

        public byte EventTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HealthyEvent> HealthyEvents { get; set; }
    }
}
