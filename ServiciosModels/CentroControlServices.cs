using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class CentroControlServices
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();
        public List<UnidadesCantidadEntity> CantidadAsignacionHoy()
        {
            List<UnidadesCantidadEntity> unidades = new List<UnidadesCantidadEntity>();
            DateTime getToday = DateTime.Today;
            var Cantidad= DB.asignacion
                        .Where(a => a.fkFecha == getToday)
                        .GroupBy(a => a.tipoUnidad)
                        .Select(g => new { TipoUnidad = g.Key, Cantidad = g.Count() })
                        .ToList();
            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadEntity
                {
                    cantidad = CantidadUnidad.Cantidad,
                    tipoUnidad = CantidadUnidad.TipoUnidad
                });
            }
            return unidades;
        }        
        public List<UnidadesCantidadLiberadoEntity> CantidadVerificadaUnidades()
        {
            List<UnidadesCantidadLiberadoEntity> unidades = new List<UnidadesCantidadLiberadoEntity>();
            DateTime getToday = DateTime.Today;
            var query = "select tipoUnidad,COUNT(tipoUnidad) as cantidadLiberado from asignacion inner join verificacionSalida on asignacion.idAsignacion = verificacionSalida.fkasignacion where asignacion.fkFecha = CONVERT(varchar(10), GETDATE(), 111) and verificacionSalida.estado = 'Verificado' group by tipoUnidad";
            var Cantidad = DB.Database.SqlQuery<UnidadesCantidadLiberadoEntity>(query, 1).ToList();
            DB.Database.Connection.Close();
            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadLiberadoEntity
                {
                    cantidadLiberado = CantidadUnidad.cantidadLiberado,
                    tipoUnidad = CantidadUnidad.tipoUnidad,
                });
            }
            return unidades;
            
        }
        public List<CronosListVerificacionEntity> ListLiberados()
        {
            DateTime todayDate = DateTime.Today;
            List<CronosListVerificacionEntity> verificacion = new List<CronosListVerificacionEntity>();
            var query = from a in DB.asignacion
                        join h in DB.horarioServicio
                        on a.fkCorrida equals h.corrida
                        join v in DB.verificacionSalida
                            on a.idAsignacion equals v.fkasignacion
                        where ((a.fkFecha==todayDate)&&(h.fecha==todayDate)
                        &&(v.estado=="Verificado")
                        ) orderby a.fkCorrida
                        select new
                        {
                            a.idAsignacion,
                            a.tipoUnidad,
                            a.economico,
                            a.tarjeton,
                            a.nomChofer,
                            a.fkCorrida,
                            a.fkFecha,
                            h.corrida,
                            h.fecha,
                            h.ruta,
                            h.horarioSalida,
                            h.horaLlegada,
                            v.idVerificacionSalida,
                            v.estado,
                            v.observaciones,
                            v.horaSalida,
                            v.fkusuario,
                            v.fkasignacion
                        };
            query.ToList();
            foreach (var data in query)
            {
                verificacion.Add(new CronosListVerificacionEntity
                {
                    idAsignacion = data.idAsignacion,
                    tipoUnidad = data.tipoUnidad,
                    economico = (int)data.economico,
                    tarjeton = (int)data.tarjeton,
                    nomChofer = data.nomChofer,
                    fkCorrida = (int)data.fkCorrida,
                    fkFecha = (DateTime)data.fkFecha,
                    corrida = data.corrida,
                    fecha = data.fecha,
                    ruta = data.ruta,
                    horarioSalida = (TimeSpan)data.horarioSalida,
                    horaLlegada = data.horaLlegada,
                    idVerificacionSalida = data.idVerificacionSalida,
                    estado = data.estado,
                    observaciones = data.observaciones,
                    horaSalida = (TimeSpan)data.horaSalida,
                    fkusuario = data.fkusuario,
                    fkAsignacion = (int)data.fkasignacion
                });                
            }
            return verificacion;
        }
        public bool insertarImagen(UnidadesImagenEntitySendImage unidades)
        {
            bool response = false;
            try
            {
                UnidadesImagen insertUnidad = (new UnidadesImagen
                {
                    ImagenUnidad = unidades.ImagenUnidad,
                    NombreUnidad = unidades.NombreUnidad
                });
                DB.UnidadesImagen.Add(insertUnidad);
                DB.SaveChanges();
                response = true;

            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public List<UnidadesCantidadEntity> GetImagenUnidadCantidad()
        {
            List<UnidadesCantidadEntity> unidades = new List<UnidadesCantidadEntity>();
            DateTime getToday = DateTime.Today;
            var query = "select ImagenUnidad,tipoUnidad,count(tipoUnidad) as cantidad from asignacion inner join UnidadesImagen on asignacion.tipoUnidad = UnidadesImagen.NombreUnidad where fkfecha = CONVERT(varchar(10), GETDATE(), 111) group by tipoUnidad,ImagenUnidad";
            var Cantidad = DB.Database.SqlQuery<UnidadesCantidadEntity>(query, 1).ToList();
            DB.Database.Connection.Close();
            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadEntity
                {
                    cantidad = CantidadUnidad.cantidad,
                    tipoUnidad = CantidadUnidad.tipoUnidad,
                    ImagenUnidad = CantidadUnidad.ImagenUnidad

                });
            }
            return unidades;        
    }
        public List<CiclosPerdidosEntity> GetCiclosPerdidos()
        {
            List<CiclosPerdidosEntity> ciclos = new List<CiclosPerdidosEntity>();
            DateTime getToday = DateTime.Today;

            var datos = from a in DB.asignacion
                        join h in DB.horarioServicio
                        on a.fkCorrida equals h.corrida
                        join v in DB.verificacionSalida
                        on a.idAsignacion equals v.fkasignacion
                        where (a.fkFecha == getToday) && (h.fecha == getToday) && (v.CiclosPerdidos != null)
                        select new
                        {
                            a.economico,
                            h.ruta,
                            h.corrida,
                            v.CiclosPerdidos,
                            v.observaciones
                        };
            datos.ToList();
            foreach (var getDatos in datos)
            {
                ciclos.Add(new CiclosPerdidosEntity
                {
                    economico = (int)getDatos.economico,
                    ruta = getDatos.ruta,
                    corrida = getDatos.corrida,
                    CiclosPerdidos = getDatos.CiclosPerdidos,
                    observaciones = getDatos.observaciones
                });
            }
            return ciclos;
        }
    }
}