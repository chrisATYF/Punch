using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HashidsNet;
using Punch.Models;
using Punch.Services;
using Microsoft.AspNet.Identity;

namespace Punch.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ClockService _clockService;
        protected readonly Hashids _hashIds;
        
        public HomeController()
        {
            _context = new ApplicationDbContext();
            _clockService = new ClockService();
            _hashIds = new Hashids("PunchUrl", 4);
        }

        [Route("", Name = "Index")]
        public ActionResult Index()
        {
            // Get logged in user id
            var userId = User.Identity.GetUserId();

            // Get top 5 of the user's clocks
            var clockinsList = _context.PunchedClocks.OrderByDescending(c => c.ApplicationUserId == userId).Take(5).ToList();

            return View(clockinsList);
        }
        
        [Authorize]
        [Route("PunchClock", Name = "PunchClock")]
        public ActionResult PunchClock()
        {
            // Get logged in user id
            var userId = User.Identity.GetUserId();

            // Get model if model has no punch out
            var model = _clockService.GetClockByUser(userId);

            // See if the model has a punch out, if so it is null
            if (model == null || !model.IsClockedIn)
            {
                // Create new model and set userId and IsClockedIn to false
                model = new PunchedClock();

                // Set button to read Clock In
                ViewData["Message"] = "Clock In";

                // Pass the new model to the view to clock in
                return View(model);
            }
            
            ViewData["Message"] = "Clock Out";

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("PunchClock", Name = "PunchClockPost")]
        public ActionResult PunchClock(int id)
        {
            // Get logged in user id
            var userId = User.Identity.GetUserId();

            // Get model by the id
            var model = _clockService.GetClock(id);

            // If model.punchOut has a value enter statement
            if (model == null || model.PunchOut.HasValue)
            {
                // If model has a punch out create new punch
                model = _clockService.ClockIn(userId, DateTime.UtcNow);

                _context.PunchedClocks.Add(model);
                _context.SaveChanges();

                return RedirectToRoute("Index");
            }

            // Set models punch out
            model = _clockService.ClockOut(id, DateTime.UtcNow);
            
            _context.PunchedClocks.Add(model);
            _context.SaveChanges();

            return RedirectToRoute("Index");
        }
    }
}