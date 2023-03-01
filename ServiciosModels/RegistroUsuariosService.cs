using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class RegistroUsuariosService
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();        
        public bool registerAccount(UsuariosEntity oUser)
        {
            bool response = false;
            try
            {
                usuarios addoUser = (new usuarios
                {
                    usuario = oUser.usuario,
                    nombre = oUser.nombre,
                    apellidoP = oUser.apellidoP,
                    apellidoM = oUser.apellidoM,
                    pass = oUser.pass,
                    fkPermiso = oUser.fkPermiso
                });
                DB.usuarios.Add(addoUser);
                DB.SaveChanges();
                response = true;
            }catch(Exception e)
            {
                e.Message.ToString();
            }
            return response;
        }        
    }
}