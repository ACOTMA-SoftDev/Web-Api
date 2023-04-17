using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad de usuarios.
    /// </summary>
    public class UsuariosEntity
    {
        /// <summary>
        /// Nombre de usuario del usuario.
        /// </summary>
        public string usuario { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Apellido paterno del usuario.
        /// </summary>
        public string apellidoP { get; set; }

        /// <summary>
        /// Apellido materno del usuario.
        /// </summary>
        public string apellidoM { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string pass { get; set; }

        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public string rol { get; set; }
    }
}
