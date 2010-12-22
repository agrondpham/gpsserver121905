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
            routes.Ignore("{resource}.js");
            //root page
            //routes.MapPageRoute("Default", "Pages/index.html", "~/Default.aspx",true);
            //
            //Routes Pages
            routes.MapPageRoute("Login_Page", "Pages/{pages}", "~/Default.aspx",true);
            routes.MapPageRoute("Admin_Page", "Admin/{pages}", "~/Default.aspx", true);
            routes.MapPageRoute("TestJQuery", "Jquery.html", "~/Test.aspx", true);
            //routes googlemaps page with action
            routes.MapPageRoute("Google_Maps", "Pages/GoogleMap/{action}", "~/Default.aspx",true);
        }
    }
}