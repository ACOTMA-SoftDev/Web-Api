using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Informe_IncidenciasTecEntity
    {
        public int ID_InformeIncidencias { get; set; }
        public DateTime Fecha_incidencia { get; set; }
        public string Servicio { get; set; }
        public string VehiculoECO { get; set; }
        public string Equipo_afectado { get; set; }
        public string Id_equipo_afectado { get; set; }
        public string Falla { get; set; }
        public string Estado { get; set; }
        public string usuario { get; set; }
    }
}