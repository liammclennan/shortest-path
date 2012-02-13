using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace ShortestPath.Web.MVCInfrastructure
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext context, string controllerName)
        {
            Type controllerType = base.GetControllerType(controllerName);
            if (controllerType != null) return ObjectFactory.GetInstance(controllerType) as IController;
            return null;
        }
    }
}