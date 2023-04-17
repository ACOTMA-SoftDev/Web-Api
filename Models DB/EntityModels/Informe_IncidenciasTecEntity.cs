using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Informe_IncidenciasTecEntity
    {
        /// <summary>
        /// Obtiene o establece el ID del informe de incidencias técnicas.
        /// </summary>
        public int ID_InformeIncidencias { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la incidencia técnica.
        /// </summary>
        public DateTime Fecha_incidencia { get; set; }

        /// <summary>
        /// Obtiene o establece el servicio relacionado con la incidencia técnica.
        /// </summary>
        public string Servicio { get; set; }

        /// <summary>
        /// Obtiene o establece el número de económico del vehículo relacionado con la incidencia técnica.
        /// </summary>
        public string VehiculoECO { get; set; }

        /// <summary>
        /// Obtiene o establece el equipo afectado por la incidencia técnica.
        /// </summary>
        public string Equipo_afectado { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del equipo afectado por la incidencia técnica.
        /// </summary>
        public string Id_equipo_afectado { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción de la falla en la incidencia técnica.
        /// </summary>
        public string Falla { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual de la incidencia técnica.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario que generó el informe de incidencias técnicas.
        /// </summary>
        public string Usuario { get; set; }
    }
}
