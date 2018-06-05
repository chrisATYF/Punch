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

        public ClockIn ClockIn(ClockViewModel model)
        {
            var clockIn = new ClockIn
            {
                Id = model.ClockIn.Id,
                PunchIn = model.ClockIn.PunchIn
            };

            _context.ClockIn.Add(clockIn);
            _context.SaveChanges();

            return clockIn;
        }

        public ClockIn GetClockIn(string id)
        {
            var clockIn = _context.ClockIn.FirstOrDefault(c => c.Id == id);

            return clockIn;
        }

        public ClockOut ClockOut(ClockViewModel model)
        {
            var clockOut = new ClockOut
            {
                Id = model.ClockOut.Id,
                PunchOut = model.ClockOut.PunchOut
            };

            _context.ClockOut.Add(clockOut);
            _context.SaveChanges();

            return clockOut;
        }

        public ClockOut GetClockOut(string id)
        {
            var clockOut = _context.ClockOut.FirstOrDefault(c => c.Id == id);

            return clockOut;
        }

        public ClockViewModel GetClockList(string id)
        {
            var clockInList = _context.ClockIn.OrderByDescending(c => c.Id == id).ToList();
            var clockOutList = _context.ClockOut.OrderByDescending(c => c.Id == id).ToList();
            var model = new ClockViewModel
            {
                ClockInList = clockInList,
                ClockOutList = clockOutList
            };

            return model;
        }
    }
}