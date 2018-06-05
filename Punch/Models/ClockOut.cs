using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Punch.Models
{
    public class ClockOut
    {
        public string Id { get; set; }
        public DateTime PunchOut { get; set; }
    }
}