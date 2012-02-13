using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ShortestPath.Core.Domain;

namespace ShortestPath.Web.Controllers
{
    public class GPXController : BaseController
    {
        public GPXController(IThreadCache threadCache) : base(threadCache)
        {}

        [ValidateInput(false)]
        public ActionResult Download(string toDownload)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(toDownload);
            return File(new MemoryStream(byteArray), "text/plain", "path.gpx");
        }

    }
}
