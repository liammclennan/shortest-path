using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Services;
using ShortestPath.Web.Domain;

namespace ShortestPath.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDirectionsService directionsService;
        private readonly IGPXService gpx;

        public HomeController(IDirectionsService directionsService, IGPXService gpx, IThreadCache cache) : base(cache)
        {
            this.directionsService = directionsService;
            this.gpx = gpx;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindShortestPath(Point[] points)
        {
            var directions = directionsService.Optimize(points);
            return Json(new { directions= directions, gpx=gpx.GetGPX(directions) });
        }
  
    }
    
}
