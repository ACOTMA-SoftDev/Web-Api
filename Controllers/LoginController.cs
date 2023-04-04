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
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        readonly LoginService loginService = new LoginService();
        readonly GeneratorToken generatorToken = new GeneratorToken();
        [HttpPost]        
        public IHttpActionResult Login(UsuariosEntity usuario)
        {
            string[] rolUser = loginService.GetPermisos(usuario);
            var user = loginService.Usuarios(usuario);
            if (user != null)
            {
                usuario.rol = rolUser[0];
                return Ok(usuario);
            }
            else
            {
                return BadRequest("Credenciales Invalidas");
            }
        }
    }
}