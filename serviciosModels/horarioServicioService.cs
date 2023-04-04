using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.serviciosModels
{
    public class HorarioServicioService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public bool AddHorarios(int corrida, string ruta, TimeSpan horarioSalida, DateTime fecha)
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
        public List<HorarioServicioEntity> GetHorarios()
        {
            var horarioEncrypt = DB.horarioServicio.ToList<horarioServicio>();
            List<HorarioServicioEntity> horarioDecrypt = new List<HorarioServicioEntity>();
            foreach (horarioServicio horario in horarioEncrypt)
            {
                horarioDecrypt.Add(new HorarioServicioEntity
                {
                    corrida = horario.corrida,
                    fecha = horario.fecha,
                    horarioSalida = (TimeSpan)horario.horarioSalida,
                    ruta = horario.ruta
                });
            }
            return horarioDecrypt;
        }
        public List<HorarioServicioEntity> ConsultarHorarioDay()
        {
            List<HorarioServicioEntity> conHora = new List<HorarioServicioEntity>();
            var datah = from hora in DB.horarioServicio
                        where (hora.fecha == DateTime.Today)
                        select new
                        {
                            hora.corrida,
                            hora.fecha,
                            hora.ruta,
                            hora.horarioSalida
                        };
            datah.ToList();
            foreach (var dataHora in datah)
            {
                var dataASi = dataHora;
                conHora.Add(new HorarioServicioEntity
                {

                    corrida = dataHora.corrida,
                    fecha = dataHora.fecha,
                    ruta = dataHora.ruta,
                    horarioSalida = (TimeSpan)dataHora.horarioSalida
                });
            }
            return conHora;
        }
        public List<HorarioServicioEntity> GetCorridaToday(int fkCorrida)
        {                        
                List<HorarioServicioEntity> conHora = new List<HorarioServicioEntity>();
                var datah = from hora in DB.horarioServicio
                            where ((hora.fecha == DateTime.Today)&&(hora.corrida==fkCorrida))
                            select new
                            {
                                hora.corrida,
                                hora.fecha,
                                hora.ruta,
                                hora.horarioSalida
                            };
                datah.ToList();
                foreach (var dataHora in datah)
                {
                    var dataASi = dataHora;
                    conHora.Add(new HorarioServicioEntity
                    {

                        corrida = dataHora.corrida,
                        fecha = dataHora.fecha,
                        ruta = dataHora.ruta,
                        horarioSalida = (TimeSpan)dataHora.horarioSalida
                    });
                }
                return conHora;
            }
        public bool DeleteHorarioServicio(eliminarHorarioServicio fecha)
        {
            bool response = false;
            try
            {
                var eliminarHoarios = DB.horarioServicio;
                var deletHorarioServicio = eliminarHoarios.Where(a => a.fecha == fecha.fechaDelete &&
                a.ruta==fecha.rutaDelete);
                DB.horarioServicio.RemoveRange(deletHorarioServicio);
                DB.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                String mensaje = e.Message;
            }
            return response;
        }
        public List<SelectIdFecha> GetFechaCorrida()
        {
            DateTime today = DateTime.Today;
            List<SelectIdFecha> selectHorario = new List<SelectIdFecha>();

            var selectData = DB.horarioServicio.
                Where(h => h.fecha >= today).
                GroupBy(h =>new { h.fecha,h.ruta}).
                ToList();
            foreach (var dataHora in selectData)
            {
                var dataASi = dataHora;
                selectHorario.Add(new SelectIdFecha
                {                    
                    fecha = dataHora.Key.fecha,
                    ruta = dataHora.Key.ruta                    
                });
            }
            return selectHorario;
        }
        public List<SelectIdFecha> GetFecha()
        {
            List<SelectIdFecha> selectHorario = new List<SelectIdFecha>();
            var datah = DB.horarioServicio                        
                        .Select(h => new { fecha = h.fecha })
                        .Distinct();
            datah.ToList();
            foreach (var dataHora in datah)
            {
                var dataASi = dataHora;
                selectHorario.Add(new SelectIdFecha
                {
                    fecha = dataHora.fecha,                    
                });
            }
            return selectHorario;
        }
        public bool DeleteAll()
        {
            bool response = false;
            DateTime time = DateTime.Today;
            try
            {
                var selectHorarios = DB.horarioServicio.Where(x => x.fecha>=time);
                DB.horarioServicio.RemoveRange(selectHorarios);
                DB.SaveChanges();
                response = true;
            }catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}