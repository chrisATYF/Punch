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
            return View();
        }
        
        [Authorize]
        [Route("PunchClock", Name = "PunchClock")]
        public ActionResult PunchClock()
        {
            var userId = User.Identity.GetUserId();
            var model = _context.PunchedClocks.FirstOrDefault(c => c.ApplicationUserId == userId && !c.PunchOut.HasValue);
            if (model == null)
            {
                ViewData["Message"] = "Clock In";
                return View();
            }

            ViewData["Message"] = "Clock Out";

            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("PunchClock", Name = "PunchClockPost")]
        public ActionResult PunchClock(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _context.PunchedClocks.FirstOrDefault(c => c.ApplicationUserId == userId && !c.PunchOut.HasValue);
            if (model == null)
            {
                model.PunchOut = DateTime.UtcNow;
            }

            model.PunchIn = DateTime.UtcNow;

            _context.PunchedClocks.Add(model);
            _context.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}