using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models.EntityModels;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class usuariosController : ApiController
    {

        usuariosService servicio = new usuariosService();
        [HttpGet]
        [Route("api/ver_Registro_de_usuarios")]
        public List<UsuariosEntity> Usuarios()
        {
            return servicio.GetUsuariosEntities();
        }


        [HttpPost]
        [Route("api/agregar_usuarios")]
        public bool agregarUsuario(UsuariosEntity nuevoUsuario)
        {
            return servicio.agregarUsuario(nuevoUsuario);
        }

        [HttpPost]
        [Route("api/actualizarUsuarios")]

        public bool actualizarUsuario(UsuariosEntity updateUsuarios)
        {
            return servicio.actualizarUsuario(updateUsuarios);
        }


        [HttpPost]
        [Route("api/eliminarUsuario")]

        public bool eliminarUsuario(UsuariosEntity deleteUsuarios)
        {
            return servicio.eliminarUsuario(deleteUsuarios);
        }
    }
}
