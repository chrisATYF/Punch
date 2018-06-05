using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HashidsNet;
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