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
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();
        public bool AddAsignacion(AsignacionEntity newAsignacion)
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
                    fkCorrida = newAsignacion.fkCorrida,
                    fkFecha = DateTime.Now
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
                    tipoUnidad = asigna.tipoUnidad,
                    economico = asigna.economico,
                    tarjeton = asigna.tarjeton,
                    nomChofer = asigna.nomChofer
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
        public List<MatchAsignHorario> AsignHorarios(DateTime fecha)
        {
            List<MatchAsignHorario> hServ = new List<MatchAsignHorario>();
            var data = from asig in DB.asignacion
                       join horario in DB.horarioServicio
                       on asig.fkCorrida equals horario.corrida
                       where ((horario.fecha == fecha) && (asig.fkFecha == fecha))
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
                    idAsignacion = dataHS.idAsignacion,
                    tipoUnidad = dataHS.tipoUnidad,
                    economico = (int)dataHS.economico,
                    tarjeton = (int)dataHS.tarjeton,
                    nomChofer = dataHS.nomChofer,
                    fkCorrida = (int)dataHS.fkCorrida,
                    fkFecha = (DateTime)dataHS.fkFecha,
                    corrida = dataHS.corrida,
                    fecha = dataHS.fecha,
                    ruta = dataHS.ruta
                });
            }
            return hServ;
        }
        public List<AsignacionEntity> ConsultarAsignacionDay()
        {
            List<AsignacionEntity> conAsig = new List<AsignacionEntity>();
            var data = from cons in DB.asignacion
                       where (cons.fkFecha == DateTime.Today)
                       select new
                       {
                           cons.idAsignacion,
                           cons.tipoUnidad,
                           cons.economico,
                           cons.tarjeton,
                           cons.nomChofer,
                           cons.fkCorrida,
                           cons.fkFecha
                       };
            data.ToList();
            foreach (var dataASi in data)
            {
                var dataASi1 = dataASi;
                conAsig.Add(new AsignacionEntity
                {
                    idAsignacion = dataASi.idAsignacion,
                    tipoUnidad = dataASi.tipoUnidad,
                    economico = (int)dataASi.economico,
                    tarjeton = (int)dataASi.tarjeton,
                    nomChofer = dataASi.nomChofer,
                    fkCorrida = (int)dataASi.fkCorrida,
                    fkFecha = (DateTime)dataASi.fkFecha
                });
            }
            return conAsig;
        }
        public List<ServiciosIniciadosEntity> GetServiciosIniciados()
        {
            List<ServiciosIniciadosEntity> servStar = new List<ServiciosIniciadosEntity>();
            var data = from asig in DB.asignacion
                       join hor in DB.horarioServicio
                       on asig.fkCorrida equals hor.corrida
                       where (hor.fecha == DateTime.Today)
                       select new
                       {
                           idAsignacion = asig.idAsignacion,
                           tipoUnidad = asig.tipoUnidad,
                           economico = asig.economico,
                           tarjeton = asig.tarjeton,
                           nomChofer = asig.nomChofer,
                           fkCorrida = asig.fkCorrida,
                           fkFecha = asig.fkFecha,
                           corrida = hor.corrida,
                           fecha = hor.fecha,
                           ruta = hor.ruta,
                           horarioSalida = hor.horarioSalida,
                           horaLlegada = hor.horaLlegada
                       };
            data.ToList();
            foreach (var servicio in data)
            {
                var datosServ = servicio;
                servStar.Add(new ServiciosIniciadosEntity
                {
                    idAsignacion = servicio.idAsignacion,
                    tipoUnidad = servicio.tipoUnidad,
                    economico = (int)servicio.economico,
                    tarjeton = (int)servicio.tarjeton,
                    nomChofer = servicio.nomChofer,
                    fkCorrida = (int)servicio.fkCorrida,
                    fkFecha = (DateTime)servicio.fkFecha,
                    corrida = servicio.corrida,
                    fecha = servicio.fecha,
                    ruta = servicio.ruta,
                    horarioSalida = (TimeSpan)servicio.horarioSalida,
                    horaLlegada = servicio.horaLlegada
                });
            }
            return servStar;
        }
        public List<ServiciosIniciadosEntity> GetServiciosIniciadosById(int idAsignacion)
        {
            List<ServiciosIniciadosEntity> servStar = new List<ServiciosIniciadosEntity>();
            var data = from asig in DB.asignacion
                       join hor in DB.horarioServicio
                       on asig.fkCorrida equals hor.corrida
                       where ((hor.fecha == DateTime.Today)&&(asig.idAsignacion==idAsignacion))
                       select new
                       {
                           idAsignacion = asig.idAsignacion,
                           tipoUnidad = asig.tipoUnidad,
                           economico = asig.economico,
                           tarjeton = asig.tarjeton,
                           nomChofer = asig.nomChofer,
                           fkCorrida = asig.fkCorrida,
                           fkFecha = asig.fkFecha,
                           corrida = hor.corrida,
                           fecha = hor.fecha,
                           ruta = hor.ruta,
                           horarioSalida = hor.horarioSalida,
                           horaLlegada = hor.horaLlegada
                       };
            data.ToList();
            foreach (var servicio in data)
            {
                var datosServ = servicio;
                servStar.Add(new ServiciosIniciadosEntity
                {
                    idAsignacion = servicio.idAsignacion,
                    tipoUnidad = servicio.tipoUnidad,
                    economico = (int)servicio.economico,
                    tarjeton = (int)servicio.tarjeton,
                    nomChofer = servicio.nomChofer,
                    fkCorrida = (int)servicio.fkCorrida,
                    fkFecha = (DateTime)servicio.fkFecha,
                    corrida = servicio.corrida,
                    fecha = servicio.fecha,
                    ruta = servicio.ruta,
                    horarioSalida = (TimeSpan)servicio.horarioSalida,
                    horaLlegada = servicio.horaLlegada
                });
            }
            return servStar;
        }
    }
}