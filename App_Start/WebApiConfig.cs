using Acotma_API.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Acotma_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Configuración y servicios de API web
            //crea una variable para habilitar el acceso al api
            var cors = new EnableCorsAttribute("*", "*", "*");
            //brinda el acceso al api 
            config.EnableCors(cors);            
            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Configuracion de Authorization por Cabeceras
            config.MessageHandlers.Add(new ValidationToken());

        }
    }
}
