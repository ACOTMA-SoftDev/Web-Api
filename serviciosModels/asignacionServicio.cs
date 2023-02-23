using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Acotma_API.Models_DB.EntityModels;
using Acotma_API.Models_DB;

namespace Acotma_API.serviciosModels
{

   public class asignacionServicio
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();
        public bool UpdateAsignacion(asignacionEntity asigna)
        {
            bool response = false;
            try
            {
                asignacion newAsignacion = (new asignacion
                {
                    idAsignacion = asigna.idAsignacion
                });
                asignacion oldAsigancion = DB.asignacion.FirstOrDefault(a => a.idAsignacion == asigna.idAsignacion);
                oldAsigancion.idAsignacion = newAsignacion.idAsignacion;

                DB.SaveChanges();
                response = true;

            }

        catch(Exception e)
            {
                String mensaje = e.Message;
            }
            return response;
        }
        


    }

    

}