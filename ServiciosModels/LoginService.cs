using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class LoginService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        // Obtener todos los registros de permisoUsuario
        public List<permisoUsuario> GetAllPermisoUsuario()
        {
            return DB.permisoUsuario.ToList();
        }

        // Obtener un usuario por nombre de usuario y contraseña
        public usuarios Usuarios(UsuariosEntity oUser)
        {
            return DB.usuarios.FirstOrDefault(x => x.usuario == oUser.usuario && x.pass == oUser.pass);
        }

        // Obtener los permisos de un usuario específico
        public string[] GetPermisos(UsuariosEntity oUser)
        {
            List<permisoUsuario> permisosUsuario = new List<permisoUsuario>();

            var GetAllPermisosUsuario = GetAllPermisoUsuario();

            // Filtrar los permisos por el nombre de usuario
            permisosUsuario = GetAllPermisosUsuario.Where(p => p.usuario == oUser.usuario).ToList();

            string[] permisos = new string[permisosUsuario.Count];

            // Obtener los nombres de permisos en un arreglo
            for (int i = 0; i < permisosUsuario.Count; i++)
            {
                permisos[i] = permisosUsuario[i].permiso;
            }

            return permisos;
        }
    }
}
