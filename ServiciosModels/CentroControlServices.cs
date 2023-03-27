using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
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
        public List<UnidadesCantidadEntity> CantidadVerificadaUnidades()
        {
            List<UnidadesCantidadEntity> unidades = new List<UnidadesCantidadEntity>();
            DateTime getToday = DateTime.Today;
            var cantidad = DB.asignacion
                    .Join(DB.verificacionSalida,
                          a => a.idAsignacion,
                          v => v.fkasignacion,
                          (a, v) => new { Asignacion = a, VerificacionSalida = v })
                    .Where(av => av.Asignacion.fkFecha == getToday && av.VerificacionSalida.estado == "Verificado")
                    .GroupBy(av => av.Asignacion.tipoUnidad)
                    .Select(g => new { TipoUnidad = g.Key, Cantidad = g.Count() })
                    .ToList();
            foreach (var CantidadUnidad in cantidad)
            {
                unidades.Add(new UnidadesCantidadEntity
                {
                    cantidad = CantidadUnidad.Cantidad,
                    tipoUnidad = CantidadUnidad.TipoUnidad
                });
            }
            return unidades;
        }
    }
}