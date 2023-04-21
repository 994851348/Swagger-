using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication
{
    /// <summary>
    ///  Web API路由
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        ///  注册路由规则
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "admin/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
