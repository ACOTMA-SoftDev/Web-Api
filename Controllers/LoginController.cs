using Acotma_API.Models_DB.EntityModels;
using Acotma_API.ServiciosModels;
using Acotma_API.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{
    [AllowAnonymous] // Permite el acceso anónimo a este controlador
    public class LoginController : ApiController
    {
        readonly LoginService loginService = new LoginService(); // Servicio de login
        readonly GeneratorToken generatorToken = new GeneratorToken(); // Generador de tokens

        // Método de inicio de sesión
        [HttpPost]
        public IHttpActionResult Login(UsuariosEntity usuario)
        {
            string[] rolUser = loginService.GetPermisos(usuario); // Obtiene los permisos del usuario
            var user = loginService.Usuarios(usuario); // Obtiene los datos del usuario

            if (user != null) // Si el usuario existe
            {
                usuario.rol = rolUser[0]; // Asigna el rol del usuario
                return Ok(usuario); // Retorna una respuesta 200 OK con los datos del usuario
            }
            else
            {
                return BadRequest("Credenciales Invalidas"); // Retorna una respuesta 400 Bad Request con un mensaje de error
            }
        }
    }
}
