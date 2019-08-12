using System;
using System.Collections.Generic;

namespace healthy_api.Models
{
    public partial class WeightMonitoring
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime Logged { get; set; }
        public decimal? WeightKgs { get; set; }

        public virtual User User { get; set; }
    }
}
