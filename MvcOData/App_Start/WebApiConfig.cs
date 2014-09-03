﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MvcOData.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
namespace MvcOData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataModelBuilder();
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute(routeName: "ODataRoute", routePrefix: null, model: builder.GetEdmModel());
        }
    }
}
