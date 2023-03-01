using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.serviciosModels
{
    public class AsignacionServicio
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();
        public bool addAsignacion(AsignacionEntity newAsignacion)
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
                    fkCorrida=newAsignacion.fkCorrida,
                    fkFecha=DateTime.Now
                    
                    
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
        public bool UpdateAsignacion(AsignacionEntity asigna)
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
        public List<asignacion> getAsignacions()
        {            
            return DB.asignacion.ToList<asignacion>();
        }        
        public List<horarioServicio> getHorarioServicios()
        {
            return DB.horarioServicio.ToList<horarioServicio>();
        }        
        public List<MatchAsignHorario> asignHorarios(DateTime fecha)
        {
            List<MatchAsignHorario> hServ = new List<MatchAsignHorario>();
            var data = from asig in DB.asignacion
                       join horario in DB.horarioServicio
                       on asig.fkCorrida equals horario.corrida
                       where (horario.fecha == fecha)
                       select new
                       {
                           asig.idAsignacion,
                           asig.tipoUnidad,
                           asig.economico,
                           asig.tarjeton,
                           asig.nomChofer,
                           asig.fkCorrida,
                           asig.fkFecha,
                           horario.corrida,
                           horario.fecha,
                           horario.ruta
                       };
            data.ToList();
            foreach (var dataHS in data)
            {
                hServ.Add(new MatchAsignHorario
                {
                    idAsignacion=dataHS.idAsignacion,
                    tipoUnidad=dataHS.tipoUnidad,
                    economico= (int)dataHS.economico,
                    tarjeton= (int)dataHS.tarjeton,
                    nomChofer=dataHS.nomChofer,
                    fkCorrida= (int)dataHS.fkCorrida,
                    fkFecha= (DateTime)dataHS.fkFecha,
                    corrida=dataHS.corrida,
                    fecha=dataHS.fecha,
                    ruta=dataHS.ruta                    
                });
            }
            return hServ;
        }                
    }
}