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
        public List<asignacion> getAsignacions()
        {            
            return DB.asignacion.ToList<asignacion>();
        }        
        public List<horarioServicio> getHorarioServicios()
        {
            return DB.horarioServicio.ToList<horarioServicio>();
        }        
        public List<matchAsignHorario> asignHorarios(DateTime fecha)
        {
            var horario = getHorarioServicios();
            var asignacion = getAsignacions();
            List<matchAsignHorario> asignaciones = new List<matchAsignHorario>();
            foreach(asignacion asignacions in asignacion.Where(x=>x.fkFecha==fecha))
            {
                foreach(horarioServicio horarioServ in horario.Where(x => x.fecha == fecha))
                {
                    asignaciones.Add(new matchAsignHorario
                    {
                        idAsignacion = asignacions.idAsignacion,
                        tipoUnidad = asignacions.tipoUnidad,
                        economico = (int)asignacions.economico,
                        tarjeton = (int)asignacions.economico,
                        nomChofer = asignacions.nomChofer,
                        fkCorrida = (int)asignacions.fkCorrida,
                        fkFecha = (DateTime)asignacions.fkFecha,
                        corrida = horarioServ.corrida,
                        fecha = horarioServ.fecha,
                        ruta = horarioServ.ruta,
                        
                    });
                }
            }
            return asignaciones;
        }                
    }
}