using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using Info;
using Info.Models;
namespace Info
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<research_application_tb>("research_application_tb");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
