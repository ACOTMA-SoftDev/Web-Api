using Acotma_API.Token;  // Importa el espacio de nombres Acotma_API.Token, que contiene la implementación de la clase ValidationToken.
using System;  // Importa el espacio de nombres System, que contiene clases fundamentales del lenguaje C# y del Framework .NET.
using System.Collections.Generic;  // Importa el espacio de nombres System.Collections.Generic, que contiene clases para manejar colecciones genéricas.
using System.Linq;  // Importa el espacio de nombres System.Linq, que contiene clases para realizar consultas en colecciones.
using System.Web.Http;  // Importa el espacio de nombres System.Web.Http, que contiene clases para la creación de APIs Web en ASP.NET.
using System.Web.Http.Cors;  // Importa el espacio de nombres System.Web.Http.Cors, que contiene clases para habilitar la funcionalidad de CORS (Cross-Origin Resource Sharing) en APIs Web.

namespace Acotma_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);  // Remueve el formateador de XML del objeto de configuración de la API.

            var cors = new EnableCorsAttribute("*", "*", "*");  // Crea una nueva instancia de la clase EnableCorsAttribute con políticas de CORS permitiendo cualquier origen, método y encabezado.
            config.EnableCors(cors);  // Habilita la funcionalidad de CORS en la configuración de la API con las políticas creadas anteriormente.

            config.MapHttpAttributeRoutes();  // Mapea las rutas definidas a través de atributos en los controladores de la API.

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",  // Define la ruta predeterminada de la API en el formato "api/{controller}/{id}", donde {controller} y {id} son segmentos variables en la URL.
                defaults: new { id = RouteParameter.Optional }  // Define un valor predeterminado opcional para el parámetro {id}.
            );

            config.MessageHandlers.Add(new ValidationToken());  // Agrega un nuevo controlador de mensajes (handler) a la configuración de la API, que es una instancia de la clase ValidationToken.
        }
    }
}
