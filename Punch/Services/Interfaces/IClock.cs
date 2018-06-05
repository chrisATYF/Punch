using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Punch.Models;

namespace Punch.Services.Interfaces
{
    public interface IClock
    {
        ClockViewModel GetClockList(string id);
        ClockIn ClockIn(ClockViewModel model);
        ClockIn GetClockIn(string id);
        ClockOut ClockOut(ClockViewModel model);
        ClockOut GetClockOut(string id);
    }
}