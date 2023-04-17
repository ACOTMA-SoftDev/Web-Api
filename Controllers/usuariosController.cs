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
        usuariosService servicio = new usuariosService(); // Servicio de usuarios

        // Método para obtener la lista de usuarios
        [HttpGet]
        [Route("api/ver_Registro_de_usuarios")]
        public List<UsuariosEntity> Usuarios()
        {
            return servicio.GetUsuariosEntities(); // Retorna una lista de entidades de usuarios
        }

        // Método para agregar un nuevo usuario
        [HttpPost]
        [Route("api/agregar_usuarios")]
        public bool agregarUsuario(UsuariosEntity nuevoUsuario)
        {
            return servicio.agregarUsuario(nuevoUsuario); // Retorna true si el usuario se agregó correctamente, false si no
        }

        // Método para actualizar un usuario existente
        [HttpPost]
        [Route("api/actualizarUsuarios")]
        public bool actualizarUsuario(UsuariosEntity updateUsuarios)
        {
            return servicio.actualizarUsuario(updateUsuarios); // Retorna true si el usuario se actualizó correctamente, false si no
        }

        // Método para eliminar un usuario existente
        [HttpPost]
        [Route("api/eliminarUsuario")]
        public bool eliminarUsuario(UsuariosEntity deleteUsuarios)
        {
            return servicio.eliminarUsuario(deleteUsuarios); // Retorna true si el usuario se eliminó correctamente, false si no
        }
    }
}
