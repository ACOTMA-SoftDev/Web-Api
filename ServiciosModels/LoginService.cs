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
        public List<permisoUsuario> GetAllPermisoUsuario()
        {
            return DB.permisoUsuario.ToList();
        }
        public usuarios Usuarios(UsuariosEntity oUser)
        {
            return DB.usuarios.FirstOrDefault(x => x.usuario == oUser.usuario && x.pass == oUser.pass);
        }
        public string[] GetPermisos(UsuariosEntity oUser)
        {
            List<permisoUsuario> permisosUsuario = new List<permisoUsuario>();
            var GetAllPermisosUsuario = GetAllPermisoUsuario();
            for (int i = 0; i < GetAllPermisosUsuario.Count; i++)
            {
                if (GetAllPermisosUsuario[i].usuario == oUser.usuario)
                {
                    permisosUsuario.Add(GetAllPermisosUsuario[i]);
                }
            }
            string[] permisos = new string[permisosUsuario.Count];
            for (int i = 0; i < permisosUsuario.Count; i++)
            {
                permisos[i] = permisosUsuario[i].permiso;
            }
            return permisos;


        }

    }
}