using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Punch.Models;

namespace Punch.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly ApplicationDbContext _context;
        
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("", Name = "SplashPage")]
        public ActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult PunchClock()
        {
            
            
            ViewData["Message"] = "Clock In";

            return View();
        }

        [Authorize]
        [HttpPost]
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