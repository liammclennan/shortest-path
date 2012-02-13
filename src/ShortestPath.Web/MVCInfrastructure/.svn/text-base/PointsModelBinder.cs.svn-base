using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ShortestPath.Core.Domain;
using ShortestPath.Web.Domain;

namespace ShortestPath.Web.MVCInfrastructure
{
    public class PointsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Point[] points = new JavaScriptSerializer().Deserialize<Point[]>(bindingContext.ValueProvider["pointsJSON"].AttemptedValue);
            return points;
        }
    }
}
