using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.serviciosModels
{
    public class asignacionServicio
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();

        public bool addAsignacion(asignacionEntity newAsignacion)
        {
            bool response = false;
            try
            {
                asignacion insertAsignacion = (new asignacion
                {
                    tipoUnidad = newAsignacion.tipoUnidad,
                    economico = newAsignacion.economico,
                    tarjeton = newAsignacion.tarjeton,
                    nomChofer = newAsignacion.nomChofer,
                    
                });
                DB.asignacion.Add(insertAsignacion);
                DB.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                string ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;
        }
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

            catch (Exception e)
            {
                String mensaje = e.Message;
            }
            return response;
        }

    }
}