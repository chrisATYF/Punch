using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punch.Models
{
    public class ClockViewModel
    {
        public int Id { get; set; }
        public PunchedClock PunchClocks { get; set; }
        public List<PunchedClock> PunchClockList { get; set; }
        public bool IsClockedIn { get; set; }
        public bool IsManager { get; set; }
    }
}