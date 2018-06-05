using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punch.Models
{
    public class ClockViewModel
    {
        public int Id { get; set; }
        public ClockIn ClockIn { get; set; }
        public List<ClockIn> ClockInList { get; set; }
        public ClockOut ClockOut { get; set; }
        public List<ClockOut> ClockOutList { get; set; }
        public bool IsClockedIn { get; set; }
    }
}