using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplicationAPI
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

            config.Routes.MapHttpRoute(
                name: "NewBook",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { Controllers="NewBook", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "contants",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { Controllers = "contants", id = RouteParameter.Optional }

            );

            config.Routes.MapHttpRoute(
                name: "editcontant",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { Controllers= "editcontant", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "removecontant",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { Controllers="removecontant", id = RouteParameter.Optional }
            );
            
        }
    }
}
