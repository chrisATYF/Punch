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

        public PunchedClock ClockIn(ClockViewModel model)
        {
            var clockIn = new PunchedClock
            {
                Id = model.PunchClocks.Id,
                PunchIn = model.PunchClocks.PunchIn
            };

            _context.PunchedClocks.Add(clockIn);
            _context.SaveChanges();

            return clockIn;
        }

        public PunchedClock GetClockIn(int id)
        {
            throw new NotImplementedException();
        }

        public ClockViewModel GetClockList(int id)
        {
            throw new NotImplementedException();
        }

        //public PunchedClock ClockIn(ClockViewModel model)
        //{
        //    var clockIn = new PunchedClock
        //    {
        //        Id = model.PunchClocks.Id,
        //        PunchIn = model.PunchClocks.PunchIn
        //    };

        //    _context.PunchedClocks.Add(clockIn);
        //    _context.SaveChanges();

        //    return clockIn;
        //}

        //public PunchedClock GetClockIn(int id)
        //{
        //    var clockIn = _context.PunchedClocks.FirstOrDefault(c => c.Id == id);

        //    return clockIn;
        //}

        //public ClockViewModel GetClockList(int id)
        //{
        //    var clockInList = _context.PunchClocks.OrderByDescending(c => c.Id == id).ToList();
        //    var model = new ClockViewModel
        //    {
        //        PunchClockList = clockInList
        //    };

        //    return model;
        //}

    }
}