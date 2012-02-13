using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Domain.DB;
using ShortestPath.Web.Domain;
using ShortestPath.Web.MVCInfrastructure;

namespace ShortestPath.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterIoCContainer();
            RegisterModelBinders();
        }

        private void RegisterModelBinders()
        {
            ModelBinders.Binders[typeof(Point[])] = new PointsModelBinder();
        }

        private void RegisterIoCContainer()
        {
            Container.Configure();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }        
    }
}