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
        public string CantidadVerificadaUnidades()
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
                    .GroupBy(x => x.TipoUnidad)
                    .ToDictionary(g => g.Key, g => g.Sum(c => c.Cantidad));
            var jsonC= JsonConvert.SerializeObject(cantidad);
            jsonC=jsonC.Replace("nombre_carro", "\"nombre_carro\"").Replace("cantidad", "\"cantidad\"").Trim('[', ']');
            return jsonC;

        }
        public List<CronosListVerificacionEntity> ListLiberados()
        {
            var query = from a in DB.asignacion
                        join h in DB.horarioServicio
                        on new { a.fkCorrida, a.fkFecha } equals new { h.corrida, h.fecha }
                        join v in DB.verificacionSalida
                            on a.Id equals v.fkasignacion
                        where a.Estado == "Verificado"
                        select new { a, h, v };
        }
    }
}