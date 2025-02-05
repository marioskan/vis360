﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VIS360.App_Start;

namespace VIS360
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
            AutofacInitializer.Initialize(config);
        }

        
    }
}
