using System;
using System.Collections.Generic;

namespace healthy_api.Models
{
    public partial class HealthyEvent
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime Logged { get; set; }
        public byte EventTypeId { get; set; }
        public short? Milliliters { get; set; }
        public decimal? WalkingDistance { get; set; }
        public decimal? TimeElapsed { get; set; }
        public short? Calories { get; set; }
        public byte Score { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual User User { get; set; }
    }
}
