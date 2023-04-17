using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para la información de registros vehiculares.
    /// </summary>
    public class RegistroVehicularEntity
    {
        /// <summary>
        /// Identificador del registro vehicular.
        /// </summary>
        public int Id_RegistroVeh { get; set; }

        /// <summary>
        /// Fecha del registro vehicular.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Nombre del solicitante del registro vehicular.
        /// </summary>
        public string Nombre_solicitante { get; set; }

        /// <summary>
        /// Marca del vehículo registrado.
        /// </summary>
        public string Marca_vehiculo { get; set; }

        /// <summary>
        /// Submarca del vehículo registrado.
        /// </summary>
        public string Submarca { get; set; }

        /// <summary>
        /// Placa del vehículo registrado.
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Tiempo del registro vehicular.
        /// </summary>
        public string Tiempo { get; set; }

        /// <summary>
        /// Área del solicitante del registro vehicular.
        /// </summary>
        public string Area_solicitante { get; set; }

        /// <summary>
        /// Actividades a realizar con el vehículo registrado.
        /// </summary>
        public string Actividades_a_realizar { get; set; }

        /// <summary>
        /// Registro de kilometraje del vehículo registrado.
        /// </summary>
        public string Registro_de_kilometraje { get; set; }
    }
}
