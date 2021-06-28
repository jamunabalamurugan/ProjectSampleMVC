using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Final_Lakshya
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["user_count"] = 0;
        
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        protected void Session_Start()
        {
            
           int i= Convert.ToInt32(Application["user_count"]);
            i += 1;
            i = i / 2;
            Application["user_count"] = i;
            Session["count_user"] = i;
        }
    }
}
