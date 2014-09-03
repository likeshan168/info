using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Info
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //SqlCacheDependency
            //必须在Application_Start方法中通过SqlCacheDependencyAdmin类的EnableTableForNotifications方法为每个需要缓存的表添加监听功能。
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ToString();

            //string connStr = "data source=.;initial catalog=zhdy;user id=sa;password=cosen;";
            
            SqlCacheDependencyAdmin.EnableNotifications(connStr);
            SqlCacheDependencyAdmin.EnableTableForNotifications(connStr, "research_application_tb");

            //cd %windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql.exe -S . -ed -d zhdy -et -t research_application_tb -E  
        }
    }
}
