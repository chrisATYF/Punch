using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punch.Models
{
    public class PunchedClock
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime? PunchOut { get; set; }
        public bool IsClockedIn = false;
    }
}