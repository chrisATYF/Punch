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
            var userId = User.Identity.GetUserId();
            var clockinsList = _context.PunchedClocks.OrderByDescending(c => c.ApplicationUserId == userId).Take(5).ToList();

            return View(clockinsList);
        }
        
        [Authorize]
        [Route("PunchClock", Name = "PunchClock")]
        public ActionResult PunchClock()
        {
            var userId = User.Identity.GetUserId();
            var model = _clockService.GetClockByUser(userId);

            if (model == null)
            {
                model = new PunchedClock
                {
                    PunchIn = DateTime.MinValue
                };

                ViewData["Message"] = "Clock In";

                return View(model);
            }
            
            ViewData["Message"] = "Clock Out";

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("PunchClockIn", Name = "PunchClockInPost")]
        public ActionResult PunchClockIn()
        {
            var userId = User.Identity.GetUserId();

            _clockService.ClockIn(userId, DateTime.UtcNow);

            return RedirectToRoute("Index");
        }

        [Authorize]
        [HttpPost]
        [Route("PunchClockOut", Name = "PunchClockOutPost")]
        public ActionResult PunchClockOut(PunchedClock model)
        {
            var userId = User.Identity.GetUserId();
            model = _clockService.ClockOut(model.Id, DateTime.UtcNow);

            return RedirectToRoute("Index");
        }
    }
}