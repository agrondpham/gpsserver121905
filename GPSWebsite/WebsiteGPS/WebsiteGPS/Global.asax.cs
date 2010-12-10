using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Routing;

namespace WebsiteGPS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void RegisterRoutes(RouteCollection routes) {
            //ignore
            routes.Ignore("{resource}.xml");
            //root page
            routes.MapPageRoute("Default", "", "~/Default.aspx");
            //
            //Routes Pages
            routes.MapPageRoute("Login Page", "Pages/{pages}", "~/Default.aspx",true);
            //routes googlemaps page with action
            routes.MapPageRoute("Google Maps", "Pages/GoogleMap/{action}", "~/Default.aspx",true);
        }
    }
}