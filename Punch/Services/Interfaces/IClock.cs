using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Punch.Models;

namespace Punch.Services.Interfaces
{
    public interface IClock
    {
        PunchedClock GetClock(int id);
        PunchedClock GetClockByUser(string id);
        PunchedClock ClockIn(string userId, DateTime time);
        PunchedClock ClockOut(int id, DateTime time);
    }
}