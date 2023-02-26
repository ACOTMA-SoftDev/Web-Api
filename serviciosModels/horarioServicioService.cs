using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.serviciosModels
{
    public class horarioServicioService
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();

        public bool addHorarios(int corrida, string ruta, TimeSpan horarioSalida, DateTime fecha)
        {
            bool response = false;
            try
            {
                horarioServicio addHorario = (new horarioServicio
                {
                    corrida = corrida,
                    fecha = fecha,
                    ruta = ruta,
                    horarioSalida = horarioSalida
                });
                DB.horarioServicio.Add(addHorario);
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