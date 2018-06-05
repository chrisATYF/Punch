using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punch.Models
{
    public class ClockIn
    {
        public string Id { get; set; }
        public DateTime PunchIn { get; set; }
    }
}