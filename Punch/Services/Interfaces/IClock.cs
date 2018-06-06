using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Punch.Models;

namespace Punch.Services.Interfaces
{
    public interface IClock
    {
        ClockViewModel GetClockList(int id);
        PunchedClock ClockIn(ClockViewModel model);
        PunchedClock GetClockIn(int id);
    }
}