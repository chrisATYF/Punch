using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Punch.Models;
using Punch.Services.Interfaces;

namespace Punch.Services
{
    public class ClockService : IClock
    {
        protected readonly ApplicationDbContext _context;

        public ClockService()
        {
            _context = new ApplicationDbContext();
        }

        public PunchedClock GetClock(int id)
        {
            var model = _context.PunchedClocks.FirstOrDefault(c => c.Id == id);

            return model;
        }

        public PunchedClock GetClockByUser(string id)
        {
            var model = _context.PunchedClocks.FirstOrDefault(c => c.ApplicationUserId == id && !c.PunchOut.HasValue);

            return model;
        }

        public PunchedClock ClockIn(string userId, DateTime time)
        {
            var model = new PunchedClock
            {
                ApplicationUserId = userId,
                PunchIn = time
            };

            _context.PunchedClocks.Add(model);
            _context.SaveChanges();

            return model;
        }

        public PunchedClock ClockOut(int id, DateTime time)
        {
            var model = _context.PunchedClocks.FirstOrDefault(c => c.Id == id);
            model.PunchOut = time;

            _context.SaveChanges();

            return model;
        }
    }
}