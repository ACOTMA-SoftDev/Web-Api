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
    }
}