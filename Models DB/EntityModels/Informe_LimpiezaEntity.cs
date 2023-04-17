using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    // Clase que representa el modelo de datos de un informe de limpieza.
    public class Informe_LimpiezaEntity
    {
        // Identificador del informe de limpieza.
        public int IdInformeLimpieza { get; set; }

        // Fecha de la limpieza.
        public DateTime Fecha_Limpieza { get; set; }

        // Estación de la limpieza.
        public string Estacion { get; set; }

        // Estado de limpieza del piso.
        public string LimpiezaPiso { get; set; }

        // Estado de limpieza de los vidrios.
        public string LimpiezaVidrio { get; set; }

        // Estado de limpieza del área de servicios.
        public string LimpiezaAreaServicios { get; set; }

        // Estado de limpieza del área de estructura.
        public string LimpiezaAreaEstructura { get; set; }

        // Estado de limpieza de los torniquetes.
        public string LimpiezaTorniquetes { get; set; }

        // Estado de limpieza de los sanitarios.
        public string LimpiezaSanitarios { get; set; }

        // Observaciones sobre la limpieza.
        public string Observaciones { get; set; }

        // Usuario que realizó el informe de limpieza.
        public string usuario { get; set; }
    }
}
