using System;
using System.Collections.Generic;

namespace healthy_api.Models
{
    public partial class User
    {
        public User()
        {
            HealthyEvents = new HashSet<HealthyEvent>();
            WeightMonitoring = new HashSet<WeightMonitoring>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<HealthyEvent> HealthyEvents { get; set; }
        public virtual ICollection<WeightMonitoring> WeightMonitoring { get; set; }
    }
}
