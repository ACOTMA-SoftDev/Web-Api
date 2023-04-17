using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Informe_accidenteEntity
    {
        public int Id_Percance { get; set; } // Propiedad que representa el ID del percance en el informe de accidente
        public DateTime Fecha_Percance { get; set; } // Propiedad que representa la fecha del percance en el informe de accidente
        public int NoEconomico { get; set; } // Propiedad que representa el número económico en el informe de accidente
        public string ServicioRuta { get; set; } // Propiedad que representa el servicio/ruta en el informe de accidente
        public string TipoUnidad { get; set; } // Propiedad que representa el tipo de unidad en el informe de accidente
        public string Ubicacion { get; set; } // Propiedad que representa la ubicación del accidente en el informe de accidente
        public string Sentido { get; set; } // Propiedad que representa el sentido del accidente en el informe de accidente
        public string Hora { get; set; } // Propiedad que representa la hora del accidente en el informe de accidente
        public string Marca { get; set; } // Propiedad que representa la marca del vehículo en el informe de accidente
        public string Submarca { get; set; } // Propiedad que representa la submarca del vehículo en el informe de accidente
        public string Color { get; set; } // Propiedad que representa el color del vehículo en el informe de accidente
        public string Placas { get; set; } // Propiedad que representa las placas del vehículo en el informe de accidente
        public string Anio { get; set; } // Propiedad que representa el año del vehículo en el informe de accidente
        public string Conductor { get; set; } // Propiedad que representa el nombre del conductor en el informe de accidente
        public string Credencial { get; set; } // Propiedad que representa la credencial del conductor en el informe de accidente
        public string Descripcion { get; set; } // Propiedad que representa la descripción del accidente en el informe de accidente
        public int Lesionados { get; set; } // Propiedad que representa el número de lesionados en el accidente en el informe de accidente
        public string Nombres { get; set; } // Propiedad que representa los nombres de los lesionados en el informe de accidente
        public string Ambulancia { get; set; } // Propiedad que representa la ambulancia involucrada en el accidente en el informe de accidente
        public string SeguridaPublica { get; set; } // Propiedad que representa la presencia de seguridad pública en el accidente en el informe de accidente
        public string PatrullaNumero { get; set; } // Propiedad que representa el número de patrulla en el accidente en el informe de accidente
        public string OficialAcargo { get; set; } // Propiedad que representa el oficial a cargo del accidente en el informe de accidente
        public string Seguro { get; set; } // Propiedad que representa el seguro involuc
        // Propiedades adicionales documentadas
        /// <summary>
        /// Obtiene o establece el nombre del supervisor a cargo del informe de accidente.
        /// </summary>
        public string Supervisor { get; set; }

        /// <summary>
        /// Obtiene o establece la foto del vehículo involucrado en el accidente en el informe de accidente.
        /// </summary>
        public string Foto_Eco { get; set; }

        /// <summary>
        /// Obtiene o establece la foto de la parte afectada del vehículo en el informe de accidente.
        /// </summary>
        public string Foto_Part { get; set; }

        /// <summary>
        /// Obtiene o establece la foto del tarjetón del vehículo en el informe de accidente.
        /// </summary>
        public string Foto_Tarjeton { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario que generó el informe de accidente.
        /// </summary>
        public string Usuario { get; set; }
    }

}