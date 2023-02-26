using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
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
        public List<horarioServicioEntity> GetHorarios()
        {
            var horarioEncrypt= DB.horarioServicio.ToList<horarioServicio>();
            List<horarioServicioEntity> horarioDecrypt = new List<horarioServicioEntity>();
            foreach(horarioServicio horario in horarioEncrypt)
            {
                horarioDecrypt.Add(new horarioServicioEntity
                {
                    corrida = horario.corrida,
                    fecha = horario.fecha,
                    horarioSalida = (TimeSpan)horario.horarioSalida,
                    ruta = horario.ruta
                });
            }
            return horarioDecrypt;
            
        }
    }
}