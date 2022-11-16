using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace App1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //First Way of Routing
            System.Web.Routing.RouteTable.Routes.MapRoute("route1", "home", new { controller = "Controller1", action = "action1" });
            System.Web.Routing.RouteTable.Routes.MapRoute("route2", "about", new { controller = "Controller1", action = "action2" });
            System.Web.Routing.RouteTable.Routes.MapRoute("route3", "contact", new { controller = "Controller1", action = "action3" });
            System.Web.Routing.RouteTable.Routes.MapRoute("route4", "products", new { controller = "Controller2", action = "action1" });
            System.Web.Routing.RouteTable.Routes.MapRoute("route5", "services", new { controller = "Controller2", action = "action2" });

            //Second Way of Routing
            System.Web.Routing.RouteTable.Routes.MapRoute("route6", "{controller}/{action}");

            //Third Way of Routing with Parameters
            System.Web.Routing.RouteTable.Routes.MapRoute("route7", "{controller}/{action}/{category}");

            //Fourth Way of Routing with Optional Parameters
            System.Web.Routing.RouteTable.Routes.MapRoute("route8", "{controller}/{action}/{category}", new { category = UrlParameter.Optional });

            //Fifth Way of Routing with Default Parameters
            System.Web.Routing.RouteTable.Routes.MapRoute("route9", "{controller}/{action}/{category}", new { category = "Electronics" });

            //Sixth Way of Routing with Constaints Parameters
            System.Web.Routing.RouteTable.Routes.MapRoute("route10", "{controller}/{action}/{category}", new { }, new { category = @"^[a-zA-Z]*$" });
            System.Web.Routing.RouteTable.Routes.MapRoute("route11", "{controller}/{action}/{empid}", new { }, new { empid = @"^[0-9]*$" });


        }
    }
}