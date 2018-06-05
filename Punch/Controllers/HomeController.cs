using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Punch.Models;
using Punch.Services;

namespace Punch.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ClockService _clockService;
        
        public HomeController()
        {
            _context = new ApplicationDbContext();
            _clockService = new ClockService();
        }

        [Route("", Name = "Index")]
        public ActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        [Route("PunchClock/{id}", Name = "PunchClock")]
        public ActionResult PunchClock(string id)
        {
            
            
            ViewData["Message"] = "Clock In";

            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("PunchClock", Name = "PunchClockPost")]
        public ActionResult PunchClock(ClockViewModel model)
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}