﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;

namespace WebApplication {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


            // Раскомментируйте следующую строку кода, чтобы включить поддержку запросов для действий с типом возвращаемого значения IQueryable или IQueryable<T>.
            // Чтобы избежать обработки неожиданных или вредоносных запросов, используйте параметры проверки в QueryableAttribute, чтобы проверять входящие запросы.
            // Дополнительные сведения см. по адресу http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}