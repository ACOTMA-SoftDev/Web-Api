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
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();        
        public bool RegisterAccount(UsuariosEntity oUser)
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