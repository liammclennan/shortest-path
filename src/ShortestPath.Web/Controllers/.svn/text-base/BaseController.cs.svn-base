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
    public class BaseController : Controller
    {
        IThreadCache cache;

        public BaseController(IThreadCache cache)
        {
            this.cache = cache;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ip = filterContext.HttpContext.Request.ServerVariables["remote_addr"];
            cache.IP = ip;
        }
    }
}
